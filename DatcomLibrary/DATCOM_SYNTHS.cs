using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        private (double Value, string LONGCG) _LongitudinalCG = (0d, "LONGCG");
        private (double Value, string VERTCG) _VerticalCG = (0d, "VERTCG");
        //
        //  Wing
        private (double Value, string WINGX) _LongitudinalWingApex = (0d, "WINGX");
        private (double Value, string WINGZ) _VerticalWingApex = (0d, "WINGZ");
        private (double Value, string WINGINC) _RootWingChordIncidenceAngle = (0d, "WINGINC");
        //
        //  Horizontal Tail
        private (double Value, string HTAILX) _LongitudinalHorizontalTailApex = (0d, "HTAILX");
        private (double Value, string HTAILZ) _VerticalHorizontalTailApex = (0d, "HTAILZ");
        private (double Value, string HTAILINC) _RootHorizontalTailChordIncidenceAngle = (0d, "HTAILINC");
        private (double Value, string HTHINGE) _LongitudinalHorizontalTailHingeAxis = (0d, "HTHINGE");
        //
        //  Vertical Tail
        private (double Value, string VTAILX) _LongitudinalVerticalTailApex = (0d, "VTAILX");
        private (double Value, string VTAILZ) _VerticalVerticalTailApex = (0d, "VTAILZ");
        //
        //  Ventral Fin
        private (double Value, string VENTRALX) _LongitudinalVentralFinApex = (0d, "VENTRALX");
        private (double Value, string VENTRALZ) _VerticalVentralFinApex = (0d, "VENTRALZ");
        //
        //  Other 
        private (double Value, string SCALE) _ScaleFactor = (1d, "SCALE");
        private (bool Value, string VPANEL) _VerticalPanelAbove = (false, "VPANEL");
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
        public (double Value, string LONGCG) LongitudinalCG
        {
            get => _LongitudinalCG;
            set => _LongitudinalCG = value;
        }
        //
        //  Vertical Center of Gravity
        public (double Value, string VERTCG) VerticalCG
        {
            get => _VerticalCG;
            set => _VerticalCG = value;
        }
        //  Wing
        //
        //  Longitudinal Wing Apex Location
        public (double Value, string WINGX) LongitudinalWingApex
        {
            get => _LongitudinalWingApex;
            set => _LongitudinalWingApex = value;
        }
        //
        //  Vertical Wing Apex Location
        public (double Value, string WINGZ) VerticalWingApex
        {
            get => _VerticalWingApex;
            set => _VerticalWingApex = value;
        }
        //
        //  Root Wing Chord Incidence Angle
        public (double Value, string WINGINC) RootWingChordIncidenceAngle
        {
            get => _RootWingChordIncidenceAngle;
            set => _RootWingChordIncidenceAngle = value;
        }
        //  Horizontal Tail
        //
        //  Longitudinal Horizontal Tail Apex Location
        public (double Value, string HTAILX) LongitudinalHorizontalTailApex
        {
            get => _LongitudinalHorizontalTailApex;
            set => _LongitudinalHorizontalTailApex = value;
        }
        //
        //  Vertical Horizontal Tail Apex Location
        public (double Value, string HTAILZ) VerticalHorizontalTailApex
        {
            get => _VerticalHorizontalTailApex;
            set => _VerticalHorizontalTailApex = value;
        }
        //
        //  Root Horizontal Tail Chord Incidence Angle
        public (double Value, string HTAILINC) RootHorizontalTailChordIncidenceAngle
        {
            get => _RootHorizontalTailChordIncidenceAngle;
            set => _RootHorizontalTailChordIncidenceAngle = value;
        }
        //
        //  Longitudinal Horizontal Tail Hinge Axis Location
        public (double Value, string HTHINGE) LongitudinalHorizontalTailHingeAxis
        {
            get => _LongitudinalHorizontalTailHingeAxis;
            set => _LongitudinalHorizontalTailHingeAxis = value;
        }
        //  Vertical Tail
        //
        //  Longitudinal Vertical Tail Apex Location
        public (double Value, string VTAILX) LongitudinalVerticalTailApex
        {
            get => _LongitudinalVerticalTailApex;
            set => _LongitudinalVerticalTailApex = value;
        }
        //
        //  Vertical Vertical Tail Apex Location
        public (double Value, string VTAILZ) VerticalVerticalTailApex
        {
            get => _VerticalVerticalTailApex;
            set => _VerticalVerticalTailApex = value;
        }
        //  Ventral Fin
        //
        //  Longitudinal Ventral Fin Apex Location
        public (double Value, string VENTRALX) LongitudinalVentralFinApex
        {
            get => _LongitudinalVentralFinApex;
            set => _LongitudinalVentralFinApex = value;
        }
        //
        //  Vertical Ventral Fin Apex Location
        public (double Value, string VENTRALZ) VerticalVentralFinApex
        {
            get => _VerticalVentralFinApex;
            set => _VerticalVentralFinApex = value;
        }
        //
        //  Other 
        //
        //  Scale Factor
        public (double Value, string SCALE) ScaleFactor
        {
            get => _ScaleFactor;
            set => _ScaleFactor = value;
        }
        //
        //  Vertical Panel is Above the Reference Plane
        public (bool Value, string VPANEL) VerticalPanelAbove
        {
            get => _VerticalPanelAbove;
            set => _VerticalPanelAbove = value;
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
    }
}
