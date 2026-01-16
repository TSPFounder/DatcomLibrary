using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_TVTPAN : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Vertical Panel
        //
        //  Vertical Panel Span Above Lifting Surface
        private CAD_Parameter _VerticalPanelSpanAboveLiftingSurface = CAD_Parameter.CreateDoubleParameter("BVP");  // - BVP
        //
        //  Vertical Panel Span
        private CAD_Parameter _VerticalPanelSpan = CAD_Parameter.CreateDoubleParameter("BV");  // - BV
        //
        //  Distance Between Vertical Panels
        private CAD_Parameter _DistanceBetweenVerticalPanels = CAD_Parameter.CreateDoubleParameter("BH");  // - BH
        //
        //  Vertical Panel Plan Form Area
        private CAD_Parameter _VerticalPanelPlanFormArea = CAD_Parameter.CreateDoubleParameter("SV");  // - SV
        //
        //  Total Trailing Edge Angle of Vertical Panel Airfoil Section
        private CAD_Parameter _VerticalPanelAirfoilSection_TE_Angle = CAD_Parameter.CreateDoubleParameter("VPHITE");  // - VPHITE
        //
        //  Chord Locations Relative to CG
        //
        //  Longitudinal Distance Between CG and Panel Quarter Chord Point
        private CAD_Parameter _CG_LongitudinalDistanceToQuarterChordPoint = CAD_Parameter.CreateDoubleParameter("VLP");  // - VLP
        //
        //  Vertical Distance Between CG and Mean Average Chord
        private CAD_Parameter _CG_VerticalDistanceToMeanAvgChord = CAD_Parameter.CreateDoubleParameter("ZP");  // - ZP
        //
        //  Chord Locations Relative to Fuselage
        //
        //  Fuselage Depth at MAC Quarter Chord Point
        private CAD_Parameter _FuselageDepthAtMAC_QuarterChordPoint = CAD_Parameter.CreateDoubleParameter("BDV");  // - BDV
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
        //  DATCOM_TVTPAN CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_TVTPAN()
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
        //  Vertical Panel
        //
        //  Vertical Panel Span Above Lifting Surface
        public CAD_Parameter VerticalPanelSpanAboveLiftingSurface
        {
            get => _VerticalPanelSpanAboveLiftingSurface;
            set => _VerticalPanelSpanAboveLiftingSurface = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Panel Span
        public CAD_Parameter VerticalPanelSpan
        {
            get => _VerticalPanelSpan;
            set => _VerticalPanelSpan = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Distance Between Vertical Panels
        public CAD_Parameter DistanceBetweenVerticalPanels
        {
            get => _DistanceBetweenVerticalPanels;
            set => _DistanceBetweenVerticalPanels = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Panel Plan Form Area
        public CAD_Parameter VerticalPanelPlanFormArea
        {
            get => _VerticalPanelPlanFormArea;
            set => _VerticalPanelPlanFormArea = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Total Trailing Edge Angle of Vertical Panel Airfoil Section
        public CAD_Parameter VerticalPanelAirfoilSection_TE_Angle
        {
            get => _VerticalPanelAirfoilSection_TE_Angle;
            set => _VerticalPanelAirfoilSection_TE_Angle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Chord Locations Relative to CG
        //
        //  Longitudinal Distance Between CG and Panel Quarter Chord Point
        public CAD_Parameter CG_LongitudinalDistanceToQuarterChordPoint
        {
            get => _CG_LongitudinalDistanceToQuarterChordPoint;
            set => _CG_LongitudinalDistanceToQuarterChordPoint = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Vertical Distance Between CG and Mean Average Chord
        public CAD_Parameter CG_VerticalDistanceToMeanAvgChord
        {
            get => _CG_VerticalDistanceToMeanAvgChord;
            set => _CG_VerticalDistanceToMeanAvgChord = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Chord Locations Relative to Fuselage
        //
        //  Fuselage Depth at MAC Quarter Chord Point
        public CAD_Parameter FuselageDepthAtMAC_QuarterChordPoint
        {
            get => _FuselageDepthAtMAC_QuarterChordPoint;
            set => _FuselageDepthAtMAC_QuarterChordPoint = value ?? throw new ArgumentNullException(nameof(value));
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
