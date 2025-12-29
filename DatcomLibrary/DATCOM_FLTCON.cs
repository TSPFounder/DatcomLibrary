using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_FLTCON : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Mach Number 
        private CAD_Parameter _NumMachNumbers = CreateIntegerParameter("NMACH");  //  - NMACH
        private List<CAD_Parameter> _MachNumbers = new();  //  - MACH
        //
        //  Freestream Conditions
        private CAD_Parameter _FreestreamVelocity = CreateDoubleParameter("VEL");  //  - VEL
        private CAD_Parameter _FreestreamStaticPressure = CreateDoubleParameter("PS");  //  - PS
        private CAD_Parameter _FreestreamStaticTemperature = CreateDoubleParameter("TS");  //  - TS
        //
        //  Angle of Attack
        private CAD_Parameter _NumAnglesOfAttack = CreateIntegerParameter("NALPHA");  //  - NALPHA
        private List<CAD_Parameter> _AnglesOfAttack = new();  //  - ALPHA
        //
        //  Reynolds Number per Unit Length
        private CAD_Parameter _ReynoldsNumberPerLength = CreateDoubleParameter("RE");  //  - RE
        //
        //  Altitudes
        private CAD_Parameter _NumAltitudes = CreateIntegerParameter("NALT");  //  - NALT
        private List<CAD_Parameter> _Altitudes = new();  //  - ALT
        //
        //  Hypersonic
        private CAD_Parameter _Hypersonic = CreateBooleanParameter("BHYPE", false);  //  - BHYPE
        //
        //  Transonic Conditions
        private CAD_Parameter _SubsonicUpperLimit = CreateDoubleParameter("SUBLIM");  //  - SUBLIM
        private CAD_Parameter _SupersonicLowerLimit = CreateDoubleParameter("SUPLIM");  //  - SUPLIM
        private CAD_Parameter _TransitionDragFlag = CreateBooleanParameter("BTRANS", false);  //  - BTRANS
        //
        //  Weight
        private CAD_Parameter _Weight = CreateDoubleParameter("WT");  //  - WT
        //
        //  Flight Path Angle
        private CAD_Parameter _FlightPathAngle = CreateDoubleParameter("GAMMA");  //  - GAMMA
        //
        //  Looping
        private CAD_Parameter _Loop = CreateIntegerParameter("LOOP");  //  - LOOP

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
        //  DATCOM_FLTCON CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_FLTCON()
        {
            this.NamelistGroupNumber = 1;
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Mach Number 
        //
        //  Number of Mach Numbers
        public CAD_Parameter NumMachNumber
        {
            get => _NumMachNumbers;
            set => _NumMachNumbers = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Mach Numbers
        public List<CAD_Parameter> MachNumbers
        {
            get => _MachNumbers;
            set => _MachNumbers = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Freestream Conditions 
        //
        //  Freestream Velocity
        public CAD_Parameter FreestreamVelocity
        {
            get => _FreestreamVelocity;
            set => _FreestreamVelocity = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Freestream Static Pressure
        public CAD_Parameter FreestreamStaticPressure
        {
            get => _FreestreamStaticPressure;
            set => _FreestreamStaticPressure = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Freestream Static Temperature
        public CAD_Parameter FreestreamStaticTemperature
        {
            get => _FreestreamStaticTemperature;
            set => _FreestreamStaticTemperature = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Angles of Attack 
        //
        //  Number of Angles of Attack
        public CAD_Parameter NumAnglesOfAttack
        {
            get => _NumAnglesOfAttack;
            set => _NumAnglesOfAttack = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Angles Of Attack
        public List<CAD_Parameter> AnglesOfAttack
        {
            get => _AnglesOfAttack;
            set => _AnglesOfAttack = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Reynolds Number per Unit Length
        public CAD_Parameter ReynoldsNumberPerLength
        {
            get => _ReynoldsNumberPerLength;
            set => _ReynoldsNumberPerLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Altitudes 
        //
        //  Number of Altitudes
        public CAD_Parameter NumAltitudes
        {
            get => _NumAltitudes;
            set => _NumAltitudes = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Altitudes
        public List<CAD_Parameter> Altitudes
        {
            get => _Altitudes;
            set => _Altitudes = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Hypersonic Conditions
        public CAD_Parameter Hypersonic
        {
            get => _Hypersonic;
            set => _Hypersonic = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Transonic Conditions
        //
        //  Subsonic Upper Limit
        public CAD_Parameter SubsonicUpperLimit
        {
            get => _SubsonicUpperLimit;
            set => _SubsonicUpperLimit = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Supersonic Lower Limit
        public CAD_Parameter SupersonicLowerLimit
        {
            get => _SupersonicLowerLimit;
            set => _SupersonicLowerLimit = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Transition Drag Flag
        public CAD_Parameter TransitionDragFlag
        {
            get => _TransitionDragFlag;
            set => _TransitionDragFlag = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Weight
        public CAD_Parameter Weight
        {
            get => _Weight;
            set => _Weight = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Flight Path Angle
        public CAD_Parameter FlightPathAngle
        {
            get => _FlightPathAngle;
            set => _FlightPathAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Looping Setting
        public CAD_Parameter Loop
        {
            get => _Loop;
            set => _Loop = value ?? throw new ArgumentNullException(nameof(value));
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
