using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_JETPWR : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Engine
        //
        //  Number of Engines
        private CAD_Parameter _NumberEngines = CreateIntegerParameter("NENGSJ");  // - NENGSJ - Max of 2
        //
        //  Angle of Incidence of the Engine Thrust Axis
        private CAD_Parameter _EngineThrustAxisAngle = CreateDoubleParameter("AIETLJ");  // - AIETLJ
        //
        //  Lateral Location of Engine
        private CAD_Parameter _LateralEngineLocation = CreateDoubleParameter("JELLOC");  // - JELLOC
        //
        //  Axial Location of Engine Inlet
        private CAD_Parameter _AxialEngineInletLocation = CreateDoubleParameter("JIALOC");  // - JIALOC
        //
        //  Axial Location of Engine Exit
        private CAD_Parameter _AxialEngineExitLocation = CreateDoubleParameter("JEALOC");  // - JEALOC
        //
        //  Vertical Location of Engine Exit
        private CAD_Parameter _VerticalEngineExitLocation = CreateDoubleParameter("JEVLOC");  // - JEVLOC
        //
        //  Jet Engine Inlet Area
        private CAD_Parameter _EngineInletArea = CreateDoubleParameter("JINLTA");  // - JINLTA
        //
        //  Jet Engine Exit Radius
        private CAD_Parameter _EngineExitRadius = CreateDoubleParameter("JERAD");  // - JERAD
        //
        //  Jet Engine Exit Angle
        private CAD_Parameter _EngineExitAngle = CreateDoubleParameter("JEANGL");  // - JEANGL
        //
        //  Thrust
        //
        //  Thrust Coefficient
        private CAD_Parameter _ThrustCoefficient = CreateDoubleParameter("THSTCJ");  // - THSTCJ
        //
        //  Jet Engine Exit Velocity
        private CAD_Parameter _EngineExitVelocity = CreateDoubleParameter("JEVELO");  // - JEVELO
        //
        //  Jet Engine Exit Static Temperature
        private CAD_Parameter _EngineExitStaticTemperature = CreateDoubleParameter("JESTMP");  // - JESTMP
        //
        //  Jet Engine Exit Total Pressure
        private CAD_Parameter _EngineExitTotalPressure = CreateDoubleParameter("JETOTP");  // - JETOTP
        //
        //  Freestream Conditions
        //
        //  Ambient Temperature
        private CAD_Parameter _AmbientTemperature = CreateDoubleParameter("AMBTMP");  // - AMBTMP
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
        //  DATCOM_JETPWR CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_JETPWR()
        {
            this.NamelistGroupNumber = 3;
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Engine
        //
        //  Number of Engines
        public CAD_Parameter NumberEngines
        {
            get => _NumberEngines;
            set => _NumberEngines = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Angle of Incidence of the Engine Thrust Axis
        public CAD_Parameter EngineThrustAxisAngle
        {
            get => _EngineThrustAxisAngle;
            set => _EngineThrustAxisAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Lateral Location of Engine
        public CAD_Parameter LateralEngineLocation
        {
            get => _LateralEngineLocation;
            set => _LateralEngineLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Axial Location of Engine Inlet
        public CAD_Parameter AxialEngineInletLocation
        {
            get => _AxialEngineInletLocation;
            set => _AxialEngineInletLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Axial Location of Engine Exit
        public CAD_Parameter AxialEngineExitLocation
        {
            get => _AxialEngineExitLocation;
            set => _AxialEngineExitLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Location of Engine Exit
        public CAD_Parameter VerticalEngineExitLocation
        {
            get => _VerticalEngineExitLocation;
            set => _VerticalEngineExitLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Engine Inlet Area
        public CAD_Parameter EngineInletArea
        {
            get => _EngineInletArea;
            set => _EngineInletArea = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Engine Exit Radius
        public CAD_Parameter EngineExitRadius
        {
            get => _EngineExitRadius;
            set => _EngineExitRadius = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Engine Exit Angle
        public CAD_Parameter EngineExitAngle
        {
            get => _EngineExitAngle;
            set => _EngineExitAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Thrust
        //
        //  Thrust Coefficient
        public CAD_Parameter ThrustCoefficient
        {
            get => _ThrustCoefficient;
            set => _ThrustCoefficient = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Engine Exit Velocity
        public CAD_Parameter EngineExitVelocity
        {
            get => _EngineExitVelocity;
            set => _EngineExitVelocity = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Engine Exit Static Temperature
        public CAD_Parameter EngineExitStaticTemperature
        {
            get => _EngineExitStaticTemperature;
            set => _EngineExitStaticTemperature = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Engine Exit Total Pressure
        public CAD_Parameter EngineExitTotalPressure
        {
            get => _EngineExitTotalPressure;
            set => _EngineExitTotalPressure = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Freestream Conditions
        //
        //  Ambient Temperature
        public CAD_Parameter AmbientTemperature
        {
            get => _AmbientTemperature;
            set => _AmbientTemperature = value ?? throw new ArgumentNullException(nameof(value));
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
    }
}
