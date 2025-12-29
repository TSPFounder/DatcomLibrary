using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_PROPWR : DATCOM_Namelist
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
        private CAD_Parameter _NumberEngines = CreateIntegerParameter("NENGSP");  // - NENGSP - Max of 2
        //
        //  Angle of Incidence of the Engine Thrust Axis
        private CAD_Parameter _EngineThrustAxisAngle = CreateDoubleParameter("AIETLP");  // - AIETLP
        //
        //  Lateral Location of Engine
        private CAD_Parameter _LateralEngineLocation = CreateDoubleParameter("YP");  // - YP
        // 
        //  Is Counter Rotating
        private CAD_Parameter _CounterRotating = CreateBooleanParameter("CROT", false);  // - CROT
        //
        //  Thrust
        //
        //  Thrust Coefficient
        private CAD_Parameter _ThrustCoefficient = CreateDoubleParameter("THSTCP");  // - THSTCP
        //
        //  Impirical Normal Force Factor
        private CAD_Parameter _EmpiricalNormalForceFactor = CreateDoubleParameter("ENGFCT");  // - ENGFCT
        //
        //  Propellers
        //
        //  Number of Propellers per Engine
        private CAD_Parameter _NumberPropellersPerEngine = CreateIntegerParameter("NOPBPE");  // - NOPBPE
        //
        //  Propeller Hub Axial Location
        private CAD_Parameter _PropellerHubAxialLocation = CreateDoubleParameter("PHALOC");  // - PHALOC
        //
        //  Propeller Hub Vertical Location
        private CAD_Parameter _PropellerHubVerticalLocation = CreateDoubleParameter("PHVLOC");  // - PHVLOC
        //
        //  Propeller Radius
        private CAD_Parameter _PropellerRadius = CreateDoubleParameter("PRPRAD");  // - PRPRAD
        //
        //  Propeller Blade Width at 0.3 Times the Propeller Radius
        private CAD_Parameter _BladeWidthAt03Radius = CreateDoubleParameter("BWAPR3");  // - BWAPR3
        //
        //  Propeller Blade Width at 0.6 Times the Propeller Radius
        private CAD_Parameter _BladeWidthAt06Radius = CreateDoubleParameter("BWAPR6");  // - BWAPR6
        //
        //  Propeller Blade Width at 0.9 Times the Propeller Radius
        private CAD_Parameter _BladeWidthAt09Radius = CreateDoubleParameter("BWAPR9");  // - BWAPR9
        //
        //  Propeller Blade Angle at 0.75 Times the Propeller Radius
        private CAD_Parameter _BladeAngleAt075Radius = CreateDoubleParameter("BAPR75");  // - BAPR75

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
        //  DATCOM_PROPWR CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_PROPWR()
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
        //  Is Counter Rotating
        public CAD_Parameter CounterRotating
        {
            get => _CounterRotating;
            set => _CounterRotating = value ?? throw new ArgumentNullException(nameof(value));
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
        //  Impirical Normal Force Factor
        public CAD_Parameter EmpiricalNormalForceFactor
        {
            get => _EmpiricalNormalForceFactor;
            set => _EmpiricalNormalForceFactor = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propellers
        //
        //  Number of Propellers per Engine
        public CAD_Parameter NumberPropellersPerEngine
        {
            get => _NumberPropellersPerEngine;
            set => _NumberPropellersPerEngine = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Hub Axial Location
        public CAD_Parameter PropellerHubAxialLocation
        {
            get => _PropellerHubAxialLocation;
            set => _PropellerHubAxialLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Hub Vertical Location
        public CAD_Parameter PropellerHubVerticalLocation
        {
            get => _PropellerHubVerticalLocation;
            set => _PropellerHubVerticalLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Radius
        public CAD_Parameter PropellerRadius
        {
            get => _PropellerRadius;
            set => _PropellerRadius = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Blade Width at 0.3 Times the Propeller Radius
        public CAD_Parameter BladeWidthAt03Radius
        {
            get => _BladeWidthAt03Radius;
            set => _BladeWidthAt03Radius = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Blade Width at 0.6 Times the Propeller Radius
        public CAD_Parameter BladeWidthAt06Radius
        {
            get => _BladeWidthAt06Radius;
            set => _BladeWidthAt06Radius = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Blade Width at 0.9 Times the Propeller Radius
        public CAD_Parameter BladeWidthAt09Radius
        {
            get => _BladeWidthAt09Radius;
            set => _BladeWidthAt09Radius = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Propeller Blade Angle at 0.75 Times the Propeller Radius
        public CAD_Parameter BladeAngleAt075Radius
        {
            get => _BladeAngleAt075Radius;
            set => _BladeAngleAt075Radius = value ?? throw new ArgumentNullException(nameof(value));
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
