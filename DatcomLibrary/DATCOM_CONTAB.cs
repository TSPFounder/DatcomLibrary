using System;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_CONTAB : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Flap Enumerations
        //
        //  Flap Type
        private CAD_Parameter _TabType = CreateIntegerParameter("TTYPE", (int)TabTypeEnum.Tab);  // - TTYPE
        //
        //  Control Tab Geometry
        //
        //  Control Tab Inboard Chord Length
        private CAD_Parameter _ControlTabInboardChordLength = CreateDoubleParameter("CFITC");  // - CFITC
        //
        //  Control Tab Outboard Chord Length
        private CAD_Parameter _ControlTabOutboardChordLength = CreateDoubleParameter("CFOTC");  // - CFOTC
        //
        //  Control Tab Inboard Span Location
        private CAD_Parameter _ControlTabInboardSpanLocation = CreateDoubleParameter("BITC");  // - BITC
        //
        //  Control Tab Outboard Span Location
        private CAD_Parameter _ControlTabOutboardSpanLocation = CreateDoubleParameter("BOTC");  // - BOTC
        //
        //  Trim Tab Geometry
        //
        //  Trim Tab Inboard Chord Length
        private CAD_Parameter _TrimTabInboardChordLength = CreateDoubleParameter("CFITT");  // - CFITT
        //
        //  Trim Tab Outboard Chord Length
        private CAD_Parameter _TrimTabOutboardChordLength = CreateDoubleParameter("CFOTT");  // - CFOTT
        //
        //  Trim Tab Inboard Span Location
        private CAD_Parameter _TrimTabInboardSpanLocation = CreateDoubleParameter("BITT");  // - BITT
        //
        //  Trim Tab Outboard Span Location
        private CAD_Parameter _TrimTabOutboardSpanLocation = CreateDoubleParameter("BOTT");  // - BOTT
        //  *****************************************************************************************


        //  ****************************************************************************************
        //  INITIALIZATIONS
        //
        //  ************************************************************

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        public enum TabTypeEnum
        {
            Tab = 1,
            Trim,
            Both
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  DATCOM_CONTAB CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_CONTAB()
        {
            this.NamelistGroupNumber = 3;
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        #region
        //
        //  Namelist Data
        //
        //  Flap Enumerations
        //
        //  Flap Type - TTYPE
        public CAD_Parameter TabType
        {
            get => _TabType;
            set => _TabType = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Control Tab Geometry
        //
        //  Control Tab Inboard Chord Length - CFITC
        public CAD_Parameter ControlTabInboardChordLength
        {
            get => _ControlTabInboardChordLength;
            set => _ControlTabInboardChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Control Tab Outboard Chord Length - CFOTC
        public CAD_Parameter ControlTabOutboardChordLength
        {
            get => _ControlTabOutboardChordLength;
            set => _ControlTabOutboardChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Control Tab Inboard Span Location - BITC
        public CAD_Parameter ControlTabInboardSpanLocation
        {
            get => _ControlTabInboardSpanLocation;
            set => _ControlTabInboardSpanLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Control Tab Outboard Span Location - BOTC
        public CAD_Parameter ControlTabOutboardSpanLocation
        {
            get => _ControlTabOutboardSpanLocation;
            set => _ControlTabOutboardSpanLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Trim Tab Geometry
        //
        //  Trim Tab Inboard Chord Length - CFITT
        public CAD_Parameter TrimTabInboardChordLength
        {
            get => _TrimTabInboardChordLength;
            set => _TrimTabInboardChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Trim Tab Outboard Chord Length - CFOTT
        public CAD_Parameter TrimTabOutboardChordLength
        {
            get => _TrimTabOutboardChordLength;
            set => _TrimTabOutboardChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Trim Tab Inboard Span Location - BITT
        public CAD_Parameter TrimTabInboardSpanLocation
        {
            get => _TrimTabInboardSpanLocation;
            set => _TrimTabInboardSpanLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Trim Tab Outboard Span Location - BOTT
        public CAD_Parameter TrimTabOutboardSpanLocation
        {
            get => _TrimTabOutboardSpanLocation;
            set => _TrimTabOutboardSpanLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        #endregion
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  METHODS
        //
        //  ************************************************************

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  EVENTS
        //
        //  ************************************************************

        //  *****************************************************************************************

        private static CAD_Parameter CreateIntegerParameter(string name, int initialValue = 0)
        {
            var parameter = new CAD_Parameter(name, CAD_Parameter.ParameterType.Integer);
            parameter.Value = new CAD_ParameterValue(initialValue, parameter);
            return parameter;
        }

        private static CAD_Parameter CreateDoubleParameter(string name, double initialValue = 0d)
        {
            var parameter = new CAD_Parameter(name, CAD_Parameter.ParameterType.Double);
            parameter.Value = new CAD_ParameterValue(initialValue, parameter);
            return parameter;
        }
    }
}
