using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DatcomLibrary;

namespace DATCOM;

public sealed class DATCOM_File
{
    private static readonly Dictionary<string, Func<DATCOM_Namelist?>> NamelistFactories = BuildNamelistFactories();

    public string FileName { get; set; } = string.Empty;

    public DATCOM_Model? CurrModel { get; private set; }

    public IList<DATCOM_Model> DATCOM_Models { get; } = new List<DATCOM_Model>();

    public IList<DatcomWing> Wings { get; } = new List<DatcomWing>();

    private DatcomWing? _lastParsedWing;

    public IList<DatcomHorizontalStabilizer> HorizontalStabilizers { get; } = new List<DatcomHorizontalStabilizer>();

    public IList<DatcomVerticalStabilizer> VerticalStabilizers { get; } = new List<DatcomVerticalStabilizer>();

    public double CurrentAltitude { get; private set; }

    public double CurrentDeflection { get; private set; }

    public string InputPath { get; set; } = string.Empty;

    public string CurrentLine { get; private set; } = string.Empty;

    public bool NamelistEnd { get; private set; }

    public bool FirstCase { get; private set; } = true;

    public void SetCurrentModel(DATCOM_Model model)
    {
        CurrModel = model ?? throw new ArgumentNullException(nameof(model));
    }

    public void SetFlightConditions(double altitude, double deflection)
    {
        CurrentAltitude = altitude;
        CurrentDeflection = deflection;
    }

    public void ConfigureFlowConditions(
        DATCOM_FLTCON fltcon,
        DATCOM_FLTCON.FlowConditionInputEnum flowConditionInput,
        IEnumerable<double>? machNumbers = null,
        IEnumerable<double>? reynoldsNumbers = null,
        IEnumerable<double>? altitudes = null,
        IEnumerable<double>? velocities = null,
        IEnumerable<double>? staticPressures = null,
        IEnumerable<double>? staticTemperatures = null)
    {
        if (fltcon is null)
        {
            throw new ArgumentNullException(nameof(fltcon));
        }

        fltcon.SetFlowConditionInputType(flowConditionInput);

        switch (flowConditionInput)
        {
            case DATCOM_FLTCON.FlowConditionInputEnum.MachReynolds:
                AddValues(fltcon.AddMachNumber, machNumbers, nameof(machNumbers));
                AddValues(fltcon.AddReynoldsNumberPerLength, reynoldsNumbers, nameof(reynoldsNumbers));
                break;
            case DATCOM_FLTCON.FlowConditionInputEnum.MachAltitude:
                AddValues(fltcon.AddMachNumber, machNumbers, nameof(machNumbers));
                AddValues(fltcon.AddAltitude, altitudes, nameof(altitudes));
                break;
            case DATCOM_FLTCON.FlowConditionInputEnum.VelocityAltitude:
                AddValues(fltcon.AddFreestreamVelocity, velocities, nameof(velocities));
                AddValues(fltcon.AddAltitude, altitudes, nameof(altitudes));
                break;
            case DATCOM_FLTCON.FlowConditionInputEnum.PressureTemperatureVelocity:
                AddValues(fltcon.AddFreestreamStaticPressure, staticPressures, nameof(staticPressures));
                AddValues(fltcon.AddFreestreamStaticTemperature, staticTemperatures, nameof(staticTemperatures));
                AddValues(fltcon.AddFreestreamVelocity, velocities, nameof(velocities));
                break;
            case DATCOM_FLTCON.FlowConditionInputEnum.PressureTemperatureMach:
                AddValues(fltcon.AddFreestreamStaticPressure, staticPressures, nameof(staticPressures));
                AddValues(fltcon.AddFreestreamStaticTemperature, staticTemperatures, nameof(staticTemperatures));
                AddValues(fltcon.AddMachNumber, machNumbers, nameof(machNumbers));
                break;
            default:
                throw new ArgumentException("Unsupported flow condition input.", nameof(flowConditionInput));
        }
    }

    public void ExecuteDATCOM(string executablePath)
    {
        var workingDirectory = string.IsNullOrWhiteSpace(InputPath) ? Environment.CurrentDirectory : InputPath;
        var startInfo = new ProcessStartInfo
        {
            FileName = executablePath,
            WorkingDirectory = workingDirectory,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(startInfo);
        process?.WaitForExit();
    }

    public void ReadInputDeck(string inputFullPath)
    {
        if (string.IsNullOrWhiteSpace(inputFullPath))
        {
            throw new ArgumentException("A valid input directory is required.", nameof(inputFullPath));
        }

        if (!File.Exists(inputFullPath))
        {
            throw new FileNotFoundException("Unable to locate the input deck.", inputFullPath);
        }

        FirstCase = true;
        NamelistEnd = false;
        CurrModel = null;

        using var reader = new StreamReader(inputFullPath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line is null)
            {
                continue;
            }

            CurrentLine = line;
            var trimmedLine = line.Trim();

            if (trimmedLine.StartsWith("CASEID", StringComparison.OrdinalIgnoreCase))
            {
                CurrModel = CreateModelFromCaseId(trimmedLine);
                _lastParsedWing = null;
                continue;
            }

            if (trimmedLine.StartsWith("NACA-W-", StringComparison.OrdinalIgnoreCase))
            {
                var code = trimmedLine["NACA-W-".Length..].Trim();
                var datcomWing = DatcomWing.CreateForNacaCode(code);
                Wings.Add(datcomWing);
                CurrModel?.Wings.Add(datcomWing);
                _lastParsedWing = datcomWing;
                continue;
            }

            if (trimmedLine.StartsWith("NACA-H-", StringComparison.OrdinalIgnoreCase))
            {
                var code = trimmedLine["NACA-H-".Length..].Trim();
                var stabilizer = DatcomHorizontalStabilizer.CreateForNacaCode(code);
                HorizontalStabilizers.Add(stabilizer);
                CurrModel?.HorizontalStabilizers.Add(stabilizer);
                continue;
            }

            if (trimmedLine.StartsWith("NACA-V-", StringComparison.OrdinalIgnoreCase))
            {
                var code = trimmedLine["NACA-V-".Length..].Trim();
                var stabilizer = DatcomVerticalStabilizer.CreateForNacaCode(code);
                VerticalStabilizers.Add(stabilizer);
                CurrModel?.VerticalStabilizers.Add(stabilizer);
                continue;
            }

            if (trimmedLine.StartsWith("$", StringComparison.OrdinalIgnoreCase))
            {
                var card = ReadCompleteNamelistCard(reader, trimmedLine);
                if (CurrModel is not null)
                {
                    ProcessNamelistCard(card, CurrModel);
                }

                continue;
            }

            if (trimmedLine.Contains("NEXT CASE", StringComparison.OrdinalIgnoreCase))
            {
                FirstCase = false;
                CurrModel = null;
                _lastParsedWing = null;
                continue;
            }

            if (trimmedLine.Contains("NAMELIST", StringComparison.OrdinalIgnoreCase))
            {
                NamelistEnd = true;
            }
        }
    }

    private static string ReadCompleteNamelistCard(StreamReader reader, string firstLine)
    {
        var builder = new StringBuilder(firstLine.Trim());
        while (!builder.ToString().TrimEnd().EndsWith("$", StringComparison.OrdinalIgnoreCase))
        {
            var nextLine = reader.ReadLine();
            if (nextLine is null)
            {
                break;
            }

            builder.Append(' ');
            builder.Append(nextLine.Trim());
        }

        return builder.ToString();
    }

    private void ProcessNamelistCard(string card, DATCOM_Model model)
    {
        if (TryCreateNamelistFromCard(card, out var namelist) && namelist is not null)
        {
            model.Namelists.Add(namelist);
            AttachWingPlanformNamelist(namelist);
        }
    }

    private void AttachWingPlanformNamelist(DATCOM_Namelist namelist)
    {
        if (_lastParsedWing is null)
        {
            return;
        }

        if (namelist is DATCOM_WGPLNF planform)
        {
            _lastParsedWing.AttachPlanformNamelist(planform);
        }
    }

    private static bool TryCreateNamelistFromCard(string card, out DATCOM_Namelist? namelist)
    {
        namelist = null;
        var trimmed = card.Trim().TrimStart('$').TrimEnd('$').Trim();
        if (string.IsNullOrWhiteSpace(trimmed))
        {
            return false;
        }

        var firstChunk = trimmed.Split(new[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
        if (firstChunk.Length == 0)
        {
            return false;
        }

        var key = firstChunk[0];
        if (!NamelistFactories.TryGetValue(key, out var factory))
        {
            return false;
        }

        namelist = factory.Invoke();
        return namelist is not null;
    }

    private DATCOM_Model CreateModelFromCaseId(string trimmedLine)
    {
        var remainder = trimmedLine.Substring("CASEID".Length).Trim();
        var model = new DATCOM_Model
        {
            Name = remainder
        };

        model.AddModelDataToFile(this);
        SetCurrentModel(model);
        _lastParsedWing = null;

        return model;
    }

    private static Dictionary<string, Func<DATCOM_Namelist?>> BuildNamelistFactories()
    {
        var assembly = typeof(DATCOM_File).Assembly;
        return assembly.GetTypes()
            .Where(type => typeof(DATCOM_Namelist).IsAssignableFrom(type) && !type.IsAbstract)
            .Where(type => type.GetConstructor(Type.EmptyTypes) is not null)
            .ToDictionary(type => type.Name.StartsWith("DATCOM_", StringComparison.OrdinalIgnoreCase)
                ? type.Name["DATCOM_".Length..]
                : type.Name,
                type => new Func<DATCOM_Namelist?>(() => Activator.CreateInstance(type) as DATCOM_Namelist),
                StringComparer.OrdinalIgnoreCase);
    }

    private static void AddValues(Action<double> addValue, IEnumerable<double>? values, string parameterName)
    {
        var list = GetValues(values, parameterName);
        foreach (var value in list)
        {
            addValue(value);
        }
    }

    private static IReadOnlyList<double> GetValues(IEnumerable<double>? values, string parameterName)
    {
        if (values is null)
        {
            throw new ArgumentException($"Values for {parameterName} must be provided.", parameterName);
        }

        var arr = values as IReadOnlyList<double> ?? values.ToArray();
        if (arr.Count == 0)
        {
            throw new ArgumentException($"At least one value for {parameterName} is required.", parameterName);
        }

        return arr;
    }
}
