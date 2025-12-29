using System;
using SE_Library;
using SystemsEngineeringLibrary;

namespace DATCOM;

public abstract class DATCOM_Namelist
{
    protected DATCOM_Namelist()
    {
    }

    protected DATCOM_Namelist(
        string namelistName,
        int namelistGroupNumber,
        Group1_DATCOM_NamelistEnum group1 = Group1_DATCOM_NamelistEnum.None,
        Group2_DATCOM_NamelistEnum group2 = Group2_DATCOM_NamelistEnum.None,
        Group3_DATCOM_NamelistEnum group3 = Group3_DATCOM_NamelistEnum.None,
        Group4_DATCOM_NamelistEnum group4 = Group4_DATCOM_NamelistEnum.None)
    {
        NamelistName = namelistName ?? throw new ArgumentNullException(nameof(namelistName));
        NamelistGroupNumber = namelistGroupNumber;
        Group1_NamelistEnum = group1;
        Group2_NamelistEnum = group2;
        Group3_NamelistEnum = group3;
        Group4_NamelistEnum = group4;
    }

    public string NamelistName { get; protected set; } = string.Empty;

    public int NamelistGroupNumber { get; protected set; }

    public Group1_DATCOM_NamelistEnum Group1_NamelistEnum { get; protected set; } = Group1_DATCOM_NamelistEnum.None;

    public Group2_DATCOM_NamelistEnum Group2_NamelistEnum { get; protected set; } = Group2_DATCOM_NamelistEnum.None;

    public Group3_DATCOM_NamelistEnum Group3_NamelistEnum { get; protected set; } = Group3_DATCOM_NamelistEnum.None;

    public Group4_DATCOM_NamelistEnum Group4_NamelistEnum { get; protected set; } = Group4_DATCOM_NamelistEnum.None;

    public override string ToString() => $"{NamelistName} (Group {NamelistGroupNumber})";

    public enum Group1_DATCOM_NamelistEnum
    {
        FLTCON = 0,
        OPTINS,
        None
    }

    public enum Group2_DATCOM_NamelistEnum
    {
        SYNTHS = 0,
        BODY,
        WGPLNF,
        HTPLNF,
        VTPLNF,
        VFPLNF,
        WGSCHR,
        HTSCHR,
        VTSCHR,
        VFSCHR,
        EXPR,
        None
    }

    public enum Group3_DATCOM_NamelistEnum
    {
        PROPWR = 0,
        JETPWR,
        GRNDEF,
        TVTPAN,
        SYMFLP,
        ASYFLP,
        LARWB,
        TRNJET,
        HYPEFF,
        CONTAB,
        None
    }

    public enum Group4_DATCOM_NamelistEnum
    {
        NAMELIST = 0,
        SAVE,
        DIM,
        NEXTCASE,
        TRIM,
        DAMP,
        NACA,
        CASEID,
        DUMP,
        DERIV,
        PART,
        BUILD,
        PLOT,
        None
    }
}
