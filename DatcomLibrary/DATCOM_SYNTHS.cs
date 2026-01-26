using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;


namespace DATCOM
{
    public class DATCOM_SYNTHS : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Body
        private CAD_Parameter _LongitudinalCG = CreateDoubleParameter("LONGCG");
        private CAD_Parameter _VerticalCG = CreateDoubleParameter("VERTCG");
        //
        //  Wing
        private CAD_Parameter _LongitudinalWingApex = CreateDoubleParameter("WINGX");
        private CAD_Parameter _VerticalWingApex = CreateDoubleParameter("WINGZ");
        private CAD_Parameter _RootWingChordIncidenceAngle = CreateDoubleParameter("WINGINC");
        //
        //  Horizontal Tail
        private CAD_Parameter _LongitudinalHorizontalTailApex = CreateDoubleParameter("HTAILX");
        private CAD_Parameter _VerticalHorizontalTailApex = CreateDoubleParameter("HTAILZ");
        private CAD_Parameter _RootHorizontalTailChordIncidenceAngle = CreateDoubleParameter("HTAILINC");
        private CAD_Parameter _LongitudinalHorizontalTailHingeAxis = CreateDoubleParameter("HTHINGE");
        //
        //  Vertical Tail
        private CAD_Parameter _LongitudinalVerticalTailApex = CreateDoubleParameter("VTAILX");
        private CAD_Parameter _VerticalVerticalTailApex = CreateDoubleParameter("VTAILZ");
        //
        //  Ventral Fin
        private CAD_Parameter _LongitudinalVentralFinApex = CreateDoubleParameter("VENTRALX");
        private CAD_Parameter _VerticalVentralFinApex = CreateDoubleParameter("VENTRALZ");
        //
        //  Other 
        private CAD_Parameter _ScaleFactor = CreateDoubleParameter("SCALE", 1d);
        private CAD_Parameter _VerticalPanelAbove = CreateBooleanParameter("VPANEL", false);
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
        //  DATCOM_SYNTHS CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_SYNTHS()
        {
            this.NamelistGroupNumber = 2;
            RegisterParametersFromFields();
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Body
        //
        //  Longitudinal Center of Gravity
        public CAD_Parameter LongitudinalCG
        {
            get => _LongitudinalCG;
            set => _LongitudinalCG = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Center of Gravity
        public CAD_Parameter VerticalCG
        {
            get => _VerticalCG;
            set => _VerticalCG = value ?? throw new ArgumentNullException(nameof(value));
        }
        //  Wing
        //
        //  Longitudinal Wing Apex Location
        public CAD_Parameter LongitudinalWingApex
        {
            get => _LongitudinalWingApex;
            set => _LongitudinalWingApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Wing Apex Location
        public CAD_Parameter VerticalWingApex
        {
            get => _VerticalWingApex;
            set => _VerticalWingApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Root Wing Chord Incidence Angle
        public CAD_Parameter RootWingChordIncidenceAngle
        {
            get => _RootWingChordIncidenceAngle;
            set => _RootWingChordIncidenceAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //  Horizontal Tail
        //
        //  Longitudinal Horizontal Tail Apex Location
        public CAD_Parameter LongitudinalHorizontalTailApex
        {
            get => _LongitudinalHorizontalTailApex;
            set => _LongitudinalHorizontalTailApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Horizontal Tail Apex Location
        public CAD_Parameter VerticalHorizontalTailApex
        {
            get => _VerticalHorizontalTailApex;
            set => _VerticalHorizontalTailApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Root Horizontal Tail Chord Incidence Angle
        public CAD_Parameter RootHorizontalTailChordIncidenceAngle
        {
            get => _RootHorizontalTailChordIncidenceAngle;
            set => _RootHorizontalTailChordIncidenceAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Longitudinal Horizontal Tail Hinge Axis Location
        public CAD_Parameter LongitudinalHorizontalTailHingeAxis
        {
            get => _LongitudinalHorizontalTailHingeAxis;
            set => _LongitudinalHorizontalTailHingeAxis = value ?? throw new ArgumentNullException(nameof(value));
        }
        //  Vertical Tail
        //
        //  Longitudinal Vertical Tail Apex Location
        public CAD_Parameter LongitudinalVerticalTailApex
        {
            get => _LongitudinalVerticalTailApex;
            set => _LongitudinalVerticalTailApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Vertical Tail Apex Location
        public CAD_Parameter VerticalVerticalTailApex
        {
            get => _VerticalVerticalTailApex;
            set => _VerticalVerticalTailApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //  Ventral Fin
        //
        //  Longitudinal Ventral Fin Apex Location
        public CAD_Parameter LongitudinalVentralFinApex
        {
            get => _LongitudinalVentralFinApex;
            set => _LongitudinalVentralFinApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Ventral Fin Apex Location
        public CAD_Parameter VerticalVentralFinApex
        {
            get => _VerticalVentralFinApex;
            set => _VerticalVentralFinApex = value ?? throw new ArgumentNullException(nameof(value));
        }
        //  Other 
        //
        //  Scale Factor
        public CAD_Parameter ScaleFactor
        {
            get => _ScaleFactor;
            set => _ScaleFactor = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Panel is Above the Reference Plane
        public CAD_Parameter VerticalPanelAbove
        {
            get => _VerticalPanelAbove;
            set => _VerticalPanelAbove = value ?? throw new ArgumentNullException(nameof(value));
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
