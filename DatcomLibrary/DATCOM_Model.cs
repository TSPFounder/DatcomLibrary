using System;
using System.Collections.Generic;

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
