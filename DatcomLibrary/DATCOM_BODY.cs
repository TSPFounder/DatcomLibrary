using System;
using System.Collections.Generic;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_BODY : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Stations 
        private CAD_Parameter _NumberStations = CreateIntegerParameter("NX");  //  - NX
        private List<CAD_Parameter> _LongitudinalStationLocation = new();  //  - X
        private List<CAD_Parameter> _AreaAtStation = new();  //  - S
        private List<CAD_Parameter> _PeripheryAtStation = new();  //  - P
        private List<CAD_Parameter> _UpperZ_ValueAtStationLocation = new();  //  - ZU
        private List<CAD_Parameter> _LowerZ_ValueAtStationLocation = new();  //  - ZL
        //
        //  Nose
        private CAD_Parameter _ConicalNose = CreateBooleanParameter("BNOSE", false);  //  - BNOSE
        private CAD_Parameter _NoseLength = CreateDoubleParameter("BLN");  //  - BLN
        private CAD_Parameter _NoseBluntnessDiameter = CreateDoubleParameter("DS");  //  - DS
        //
        //  Planform Half Width
        private List<CAD_Parameter> _PlanformHalfWidth = new();  //  - R**
        //
        //  Tail
        private CAD_Parameter _ConicalTail = CreateBooleanParameter("BTAIL", false);  //  - BTAIL
        private CAD_Parameter _TailLength = CreateDoubleParameter("BLA");  //  - BLA
        //
        //  Wing Sweep & Area Rule
        //
        //  1 = Straight Wing, No Area Rule
        //  2 = Swept Wing, No Area Rule - Default
        //  3 = Swept Wing, Area Rule
        private CAD_Parameter _ITYPE = CreateIntegerParameter("ITYPE");  //  - ITYPE
        //
        //  Coefficient Calculation Method
        private CAD_Parameter _JorgensonMethod = CreateBooleanParameter("METHOD", false);  //  - METHOD
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

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  DATCOM_BODY CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_BODY()
        {
            this.NamelistGroupNumber = 2;
            this.Group1_NamelistEnum = Group1_DATCOM_NamelistEnum.None;
            this.Group2_NamelistEnum = Group2_DATCOM_NamelistEnum.BODY;
            this.Group3_NamelistEnum = Group3_DATCOM_NamelistEnum.None;
            this.Group4_NamelistEnum = Group4_DATCOM_NamelistEnum.None;
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Stations 
        //
        //  Number of Stations
        public CAD_Parameter NumberStations
        {
            get => _NumberStations;
            set => _NumberStations = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Longitudinal Station Location
        public List<CAD_Parameter> LongitudinalStationLocation
        {
            get => _LongitudinalStationLocation;
            set => _LongitudinalStationLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Area at Station
        public List<CAD_Parameter> AreaAtStation
        {
            get => _AreaAtStation;
            set => _AreaAtStation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Periphery at Station
        public List<CAD_Parameter> PeripheryAtStation
        {
            get => _PeripheryAtStation;
            set => _PeripheryAtStation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Upper Z Value At Station Location
        public List<CAD_Parameter> UpperZ_ValueAtStationLocation
        {
            get => _UpperZ_ValueAtStationLocation;
            set => _UpperZ_ValueAtStationLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Lower Z Value At Station Location
        public List<CAD_Parameter> LowerZ_ValueAtStationLocation
        {
            get => _LowerZ_ValueAtStationLocation;
            set => _LowerZ_ValueAtStationLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Nose
        //
        //  Is the Nose Conical or Ogive
        public CAD_Parameter ConicalNose
        {
            get => _ConicalNose;
            set => _ConicalNose = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Nose Length
        public CAD_Parameter NoseLength
        {
            get => _NoseLength;
            set => _NoseLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Nose Bluntness Diameter
        public CAD_Parameter NoseBluntnessDiameter
        {
            get => _NoseBluntnessDiameter;
            set => _NoseBluntnessDiameter = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Planform Half Width
        public List<CAD_Parameter> PlanformHalfWidth
        {
            get => _PlanformHalfWidth;
            set => _PlanformHalfWidth = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Tail
        //
        //  Is the Tail Conical or Ogive
        public CAD_Parameter ConicalTail
        {
            get => _ConicalTail;
            set => _ConicalTail = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Tail Length
        public CAD_Parameter TailLength
        {
            get => _TailLength;
            set => _TailLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Wing Sweep & Area Rule
        public CAD_Parameter ITYPE
        {
            get => _ITYPE;
            set => _ITYPE = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Coefficient Calculation Method
        public CAD_Parameter JorgensonMethod
        {
            get => _JorgensonMethod;
            set => _JorgensonMethod = value ?? throw new ArgumentNullException(nameof(value));
        }
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

        private static CAD_Parameter CreateBooleanParameter(string name, bool initialValue)
        {
            var parameter = new CAD_Parameter(name, CAD_Parameter.ParameterType.Other);
            parameter.Value = new CAD_ParameterValue(initialValue, parameter);
            return parameter;
        }
    }
}