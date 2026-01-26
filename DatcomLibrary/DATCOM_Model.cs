using System;
using System.Collections.Generic;
using DatcomLibrary;

namespace DATCOM;

public sealed class DATCOM_Model
{
    public DATCOM_Model()
    {
    }

    public DATCOM_Model(
        string name,
        string version,
        string id,
        string description,
        UnitOptionsEnum units)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Version = version ?? throw new ArgumentNullException(nameof(version));
        ID = id ?? throw new ArgumentNullException(nameof(id));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Units = units;
    }

    public string Name { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string ID { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool HasBody { get; set; }

    public bool HasHorizontalStabilizer { get; set; }

    public bool HasVerticalStabilizer { get; set; }

    public bool HasWing { get; set; }

    public bool HasVentralFin { get; set; }

    public bool HasTwinVerticalTail { get; set; }

    public bool HasPropellerPower { get; set; }

    public bool HasJetPower { get; set; }

    public bool SymmetricalFlapOnWing { get; set; }

    public bool SymmetricalFlapOnHorTail { get; set; }

    public bool SymmetricalFlapOnVertTail { get; set; }

    public bool AsymmetricalFlapOnWing { get; set; }

    public bool AsymmetricalFlapOnHorTail { get; set; }

    public bool JetFlapOnWing { get; set; }

    public bool HighLiftOrControlDevicesNeutral { get; set; }

    public bool CleanBodies { get; set; }

    public bool NACA_ControlCardUsed { get; set; }

    public bool IncludeGroundEffects { get; set; }

    public bool LowAspectRatio { get; set; }

    public BasicConfigurationEnum BasicConfiguration { get; set; } = BasicConfigurationEnum.BodyAlone;

    public List<SpecialConfigurationEnum> SpecialConfigurations { get; } = new();

    public UnitOptionsEnum Units { get; set; } = UnitOptionsEnum.FootPoundSec;

    public DATCOM_File? ModelFile { get; set; }

    public DATCOM_Namelist? CurrentNamelist { get; private set; }

    public List<DATCOM_Namelist> Namelists { get; } = new();

    public List<string> SpeedRegimes { get; set; }

    public List<DatcomWing> Wings { get; } = new();

    public List<DatcomHorizontalStabilizer> HorizontalStabilizers { get; } = new();

    public List<DatcomVerticalStabilizer> VerticalStabilizers { get; } = new();

    public void AssignNamelists()
    {
        var namelist = CreateNamelistForConfiguration(BasicConfiguration);
        if (namelist is null)
        {
            return;
        }

        CurrentNamelist = namelist;
        Namelists.Add(namelist);
    }

    private static DATCOM_Namelist? CreateNamelistForConfiguration(BasicConfigurationEnum configuration) => configuration switch
    {
        BasicConfigurationEnum.BodyAlone => new DATCOM_BODY(),
        _ => null
    };

    public void AddModelDataToFile(DATCOM_File file)
    {
        if (file is null)
        {
            throw new ArgumentNullException(nameof(file));
        }
        ModelFile = file;
        file.DATCOM_Models.Add(this);
    }

    public void AddRequiredBasicConfigurationNamelists()
    {
        var factories = GetRequiredNamelistFactories(BasicConfiguration);
        foreach (var factory in factories)
        {
            Namelists.Add(factory());
        }
    }

    private static IReadOnlyList<Func<DATCOM_Namelist>> GetRequiredNamelistFactories(BasicConfigurationEnum configuration)
    {
        var core = new Func<DATCOM_Namelist>[]
        {
            () => new DATCOM_FLTCON(),
            () => new DATCOM_OPTINS(),
            () => new DATCOM_SYNTHS()
        };

        return configuration switch
        {
            BasicConfigurationEnum.BodyAlone => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_BODY()
            },
            BasicConfigurationEnum.WingAlone => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_WGPLNF(),
                () => new DATCOM_WGSCHR()
            },
            BasicConfigurationEnum.VerticalTail_and_VerticalFinAlone => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_VTPLNF(),
                () => new DATCOM_VFPLNF(),
                () => new DATCOM_VTSCHR(),
                () => new DATCOM_VFSCHR()
            },
            BasicConfigurationEnum.BodyWing => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_BODY(),
                () => new DATCOM_WGPLNF(),
                () => new DATCOM_WGSCHR()
            },
            BasicConfigurationEnum.BodyHorizontal => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_BODY(),
                () => new DATCOM_HTPLNF(),
                () => new DATCOM_HTSCHR()
            },
            BasicConfigurationEnum.BodyVerticalVentral => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_BODY(),
                () => new DATCOM_VTPLNF(),
                () => new DATCOM_VFPLNF(),
                () => new DATCOM_VTSCHR(),
                () => new DATCOM_VFSCHR()
            },
            BasicConfigurationEnum.BodyWingVerticalVentral => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_BODY(),
                () => new DATCOM_WGPLNF(),
                () => new DATCOM_VTPLNF(),
                () => new DATCOM_VFPLNF(),
                () => new DATCOM_WGSCHR(),
                () => new DATCOM_VTSCHR(),
                () => new DATCOM_VFSCHR()
            },
            BasicConfigurationEnum.BodyWingHorizontalVerticalVentral => new Func<DATCOM_Namelist>[]
            {
                () => new DATCOM_FLTCON(),
                () => new DATCOM_OPTINS(),
                () => new DATCOM_SYNTHS(),
                () => new DATCOM_BODY(),
                () => new DATCOM_WGPLNF(),
                () => new DATCOM_HTPLNF(),
                () => new DATCOM_VTPLNF(),
                () => new DATCOM_VFPLNF(),
                () => new DATCOM_WGSCHR(),
                () => new DATCOM_HTSCHR(),
                () => new DATCOM_VTSCHR(),
                () => new DATCOM_VFSCHR()
            },
            _ => core
        };
    }

    public enum BasicConfigurationEnum
    {
        BodyAlone = 1,
        WingAlone,
        VerticalTail_and_VerticalFinAlone,
        BodyWing,
        BodyHorizontal,
        BodyVerticalVentral,
        BodyWingVerticalVentral,
        BodyWingHorizontalVerticalVentral
    }

    public enum SpecialConfigurationEnum
    {
        PROPWR = 1,
        JETPWR,
        GRNDEF,
        TVTPAN,
        SYMFLP,
        ASYFLP,
        LARWB,
        TRNJET,
        HYPEFF,
        CONTAB
    }

    public enum UnitOptionsEnum
    {
        FootPoundSec = 1,
        InchPoundSec,
        MeterNewtonSec,
        CentimeterNewtonSec
    }
}
