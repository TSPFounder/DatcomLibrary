using System;
using System.Collections.Generic;
using System.Reflection;
using CAD;
using SE_Library;
using SystemsEngineeringLibrary;

namespace DATCOM;

public abstract class DATCOM_Namelist
{
    private readonly List<CAD_Parameter> _namelistParameters = new();
    private bool _parametersRegistered;

    protected DATCOM_Namelist()
    {
        List<CAD_Parameter> NamelistParameters = new List<CAD_Parameter>();
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

    public List<CAD_Parameter> NamelistParameters
    {
        get
        {
            if (!_parametersRegistered)
            {
                RegisterParametersFromFields();
            }

            return _namelistParameters;
        }
    }

    public Group1_DATCOM_NamelistEnum Group1_NamelistEnum { get; protected set; } = Group1_DATCOM_NamelistEnum.None;

    public Group2_DATCOM_NamelistEnum Group2_NamelistEnum { get; protected set; } = Group2_DATCOM_NamelistEnum.None;

    public Group3_DATCOM_NamelistEnum Group3_NamelistEnum { get; protected set; } = Group3_DATCOM_NamelistEnum.None;

    public Group4_DATCOM_NamelistEnum Group4_NamelistEnum { get; protected set; } = Group4_DATCOM_NamelistEnum.None;

    public override string ToString() => $"{NamelistName} (Group {NamelistGroupNumber})";

    protected void RegisterParametersFromFields()
    {
        if (_parametersRegistered)
        {
            return;
        }

        var type = GetType();
        while (type is not null && type != typeof(DATCOM_Namelist))
        {
            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                var value = field.GetValue(this);
                if (value is CAD_Parameter parameter)
                {
                    RegisterParameter(parameter);
                }
                else if (value is IEnumerable<CAD_Parameter> parameterList)
                {
                    RegisterParameterRange(parameterList);
                }
            }

            type = type.BaseType;
        }

        _parametersRegistered = true;
    }

    private void RegisterParameter(CAD_Parameter? parameter)
    {
        if (parameter is null)
        {
            return;
        }

        if (!_namelistParameters.Contains(parameter))
        {
            _namelistParameters.Add(parameter);
        }
    }

    private void RegisterParameterRange(IEnumerable<CAD_Parameter>? parameters)
    {
        if (parameters is null)
        {
            return;
        }

        foreach (var parameter in parameters)
        {
            RegisterParameter(parameter);
        }
    }

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
