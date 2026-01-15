using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DATCOM;

public sealed class DATCOM_File
{
    public string FileName { get; set; } = string.Empty;

    public DATCOM_Model? CurrModel { get; private set; }

    public IList<DATCOM_Model> DATCOM_Models { get; } = new List<DATCOM_Model>();

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

    public void ExecuteDATCOM(string executablePath )
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

    public void ReadInputDeck(string inputDirectory)
    {
        if (string.IsNullOrWhiteSpace(inputDirectory))
        {
            throw new ArgumentException("A valid input directory is required.", nameof(inputDirectory));
        }

        var deckPath = Path.Combine(inputDirectory, "for005.dat");
        if (!File.Exists(deckPath))
        {
            throw new FileNotFoundException("Unable to locate the input deck.", deckPath);
        }

        InputPath = inputDirectory;
        FirstCase = true;
        NamelistEnd = false;

        using var reader = new StreamReader(deckPath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line is null)
            {
                continue;
            }

            CurrentLine = line;
            ReadCase(line);
        }
    }

    private void ReadCase(string currentLine)
    {
        if (string.IsNullOrWhiteSpace(currentLine))
        {
            return;
        }

        if (currentLine.Contains("NEXT CASE", StringComparison.OrdinalIgnoreCase))
        {
            FirstCase = false;
            return;
        }

        if (currentLine.Contains("NAMELIST", StringComparison.OrdinalIgnoreCase))
        {
            NamelistEnd = true;
        }
    }
}
