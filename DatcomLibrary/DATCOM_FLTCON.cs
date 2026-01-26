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
        private CAD_Parameter _NumMachNumbers = CAD_Parameter.CreateIntegerParameter("NMACH");  //  - NMACH
        private List<CAD_Parameter> _MachNumbers = new();  //  - MACH
        //
        //  Freestream Conditions
        private List<CAD_Parameter> _FreestreamVelocity = new();  //  - VINF
        private List<CAD_Parameter> _FreestreamStaticPressure = new();  //  - PS
        private List<CAD_Parameter> _FreestreamStaticTemperature = new();  //  - TS

        //
        //  Angle of Attack
        private CAD_Parameter _NumAnglesOfAttack = CAD_Parameter.CreateIntegerParameter("NALPHA");  //  - NALPHA
        private List<CAD_Parameter> _AnglesOfAttack = new();  //  - ALSCHD
        //
        //  Reynolds Number per Unit Length
        private List<CAD_Parameter> _ReynoldsNumberPerLength = new();  //  - RNNUB
        //
        //  Altitudes
        private CAD_Parameter _NumAltitudes = CAD_Parameter.CreateIntegerParameter("NALT");  //  - NALT
        private List<CAD_Parameter> _Altitudes = new();  //  - ALT
        //
        //  Flow Condition Input Type
        private FlowConditionInputEnum _FlowConditionInputType;        
        //
        //  Hypersonic
        private CAD_Parameter _Hypersonic = CAD_Parameter.CreateBooleanParameter("BHYPE", false);  //  - BHYPE
        //
        //  Transonic Conditions
        private CAD_Parameter _SubsonicUpperLimit = CAD_Parameter.CreateDoubleParameter("SUBLIM");  //  - SUBLIM
        private CAD_Parameter _SupersonicLowerLimit = CAD_Parameter.CreateDoubleParameter("SUPLIM");  //  - SUPLIM
        private CAD_Parameter _TransitionDragFlag = CAD_Parameter.CreateBooleanParameter("BTRANS", false);  //  - BTRANS
        //
        //  Weight
        private CAD_Parameter _Weight = CAD_Parameter.CreateDoubleParameter("WT");  //  - WT
        //
        //  Flight Path Angle
        private CAD_Parameter _FlightPathAngle = CAD_Parameter.CreateDoubleParameter("GAMMA");  //  - GAMMA
        //
        //  Looping
        private CAD_Parameter _Loop = CAD_Parameter.CreateIntegerParameter("LOOP");  //  - LOOP

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  INITIALIZATIONS
        //
        //  ************************************************************

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  ENUMERATIONS
        //
        //  ************************************************************
        public enum FlowConditionInputEnum
        {
            MachReynolds,
            MachAltitude,
            VelocityAltitude,
            PressureTemperatureVelocity,
            PressureTemperatureMach

        }
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
        public List<CAD_Parameter> FreestreamVelocity
        {
            get => _FreestreamVelocity;
            set => _FreestreamVelocity = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Freestream Static Pressure
        public List<CAD_Parameter> FreestreamStaticPressure
        {
            get => _FreestreamStaticPressure;
            set => _FreestreamStaticPressure = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Freestream Static Temperature
        public List<CAD_Parameter> FreestreamStaticTemperature
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
        public List<CAD_Parameter> ReynoldsNumberPerLength
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

        //  *******  Add Mach Number
        public void AddMachNumber(double machNumber)
        {
            if (_MachNumbers.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 Mach numbers can be specified.");
            }

            var nextIndex = _MachNumbers.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter($"MACH{nextIndex}");
            parameter.Value = new CAD_ParameterValue(machNumber, parameter);
            _MachNumbers.Add(parameter);
            _NumMachNumbers.Value = new CAD_ParameterValue(_MachNumbers.Count, _NumMachNumbers);
        }

        //  *******  Add Free Stream Velocity
        public void AddFreestreamVelocity(double velocity)
        {
            if (_FreestreamVelocity.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 Free Stream Velocities can be specified.");
            }

            var nextIndex = _FreestreamVelocity.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter($"VINF{nextIndex}");
            parameter.Value = new CAD_ParameterValue(velocity, parameter);
            _FreestreamVelocity.Add(parameter);
        }

        //  *******  Add Angle of Attack
        public void AddAngleOfAttack(double alpha)
        {
            if (_AnglesOfAttack.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 angles of attack can be specified.");
            }

            var nextIndex = _AnglesOfAttack.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter($"ALPHA{nextIndex}");
            parameter.Value = new CAD_ParameterValue(alpha, parameter);
            _AnglesOfAttack.Add(parameter);
            _NumAnglesOfAttack.Value = new CAD_ParameterValue(_AnglesOfAttack.Count, _NumAnglesOfAttack);
        }   

        //  *******  Add Altitude
        public void AddAltitude(double altitude)
        {
            if (_Altitudes.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 altitudes can be specified.");
            }

            var nextIndex = _Altitudes.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter($"ALT{nextIndex}");
            parameter.Value = new CAD_ParameterValue(altitude, parameter);
            _Altitudes.Add(parameter);
            _NumAltitudes.Value = new CAD_ParameterValue(_Altitudes.Count, _NumAltitudes);
        }

        //  *******  Add Freestream Static Pressure
        public void AddFreestreamStaticPressure(double pressure)
        {
            if (_FreestreamStaticPressure.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 free-stream static pressures can be specified.");
            }

            var nextIndex = _FreestreamStaticPressure.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter(nextIndex == 1 ? "PS" : $"PS{nextIndex}");
            parameter.Value = new CAD_ParameterValue(pressure, parameter);
            _FreestreamStaticPressure.Add(parameter);
        }

        //  *******  Add Freestream Static Temperature
        public void AddFreestreamStaticTemperature(double temperature)
        {
            if (_FreestreamStaticTemperature.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 free-stream static temperatures can be specified.");
            }

            var nextIndex = _FreestreamStaticTemperature.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter(nextIndex == 1 ? "TS" : $"TS{nextIndex}");
            parameter.Value = new CAD_ParameterValue(temperature, parameter);
            _FreestreamStaticTemperature.Add(parameter);
        }

        //  *******  Add Reynolds Number per Unit Length
        public void AddReynoldsNumberPerLength(double reynoldsNumber)
        {
            if (_ReynoldsNumberPerLength.Count >= 20)
            {
                throw new InvalidOperationException("Maximum of 20 Reynolds numbers per unit length can be specified.");
            }

            var nextIndex = _ReynoldsNumberPerLength.Count + 1;
            var parameter = CAD_Parameter.CreateDoubleParameter(nextIndex == 1 ? "RNNUB" : $"RNNUB{nextIndex}");
            parameter.Value = new CAD_ParameterValue(reynoldsNumber, parameter);
            _ReynoldsNumberPerLength.Add(parameter);
        }

        //  Set the type of Flow Condition Input
        public void SetFlowConditionInputType(FlowConditionInputEnum inputType)
        {
            _FlowConditionInputType = inputType;
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  EVENTS
        //
        //  ************************************************************

        //  *****************************************************************************************



    }
}
