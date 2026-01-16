using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_HTPLNF : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Planform Type
        private CAD_Parameter _PlanformType = CAD_Parameter.CreateIntegerParameter("TYPE", (int)PlanformTypeEnum.StraightTapered);
        //
        //  Chords
        //
        //  Tip Chord Length - (CHRDTP)
        private CAD_Parameter _TipChordLength = CAD_Parameter.CreateDoubleParameter("CHRDTP");
        //
        //  Chord Length at Breakpoint - (CHRDBP)
        private CAD_Parameter _BreakpointChordLength = CAD_Parameter.CreateDoubleParameter("CHRDBP");
        //
        //  Root Chord Length - (CHRDR)
        private CAD_Parameter _RootChordLength = CAD_Parameter.CreateDoubleParameter("CHRDR");
        //
        //  Semi-Spans
        //
        //  Outboard Panel Semi-Span Length - (SSNOP)
        private CAD_Parameter _OutboardPanelSemiSpanLength = CAD_Parameter.CreateDoubleParameter("SSNOP");
        //
        //  Exposed Panel Semi-Span Length - (SSNEP)
        private CAD_Parameter _ExposedPanelSemiSpanLength = CAD_Parameter.CreateDoubleParameter("SSNEP");
        //
        //  Theoretical Panel Semi-Span Length at Root Chord - (SSPN)
        private CAD_Parameter _TheoreticalPanelSemiSpanLength = CAD_Parameter.CreateDoubleParameter("SSPN");
        //
        //  Outboard Panel Semi-Span Length with Dihedral - (SSNDD)
        private CAD_Parameter _OutboardPanelSemiSpanLength_Dihedral = CAD_Parameter.CreateDoubleParameter("SSNDD");
        //
        //  Sweep Angles
        //
        //  Inboard Panel Sweep Angle - (SAVSI)
        private CAD_Parameter _InboardPanelSweepAngle = CAD_Parameter.CreateDoubleParameter("SAVSI");
        //
        //  Outboard Panel Sweep Angle - (SAVSO)
        private CAD_Parameter _OutboardPanelSweepAngle = CAD_Parameter.CreateDoubleParameter("SAVSO");
        //
        //  Dihedral Angles
        //
        //  Inboard Panel Dihedral Angle - (DHDADI)
        private CAD_Parameter _InboardPanelDihedralAngle = CAD_Parameter.CreateDoubleParameter("DHDADI");
        //
        //  Outboard Panel Dihedral Angle - (DHDADO)
        private CAD_Parameter _OutboardPanelDihedralAngle = CAD_Parameter.CreateDoubleParameter("DHDADO");
        //
        //  Twist Angle - (TWISTA)
        private CAD_Parameter _TwistAngle = CAD_Parameter.CreateDoubleParameter("TWISTA");
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
        public enum PlanformTypeEnum
        {
            StraightTapered = 0,
            DoubleDelta,
            Cranked
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  DATCOM_HTPLNF CONSTRUCTOR
        //
        //  ************************************************************

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Planform Type - (TYPE)
        public CAD_Parameter PlanformType
        {
            get => _PlanformType;
            set => _PlanformType = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Chords
        //
        //  Tip Chord Length - (CHRDTP)
        public CAD_Parameter TipChordLength
        {
            get => _TipChordLength;
            set => _TipChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Chord Length at Breakpoint - (CHRDBP)
        public CAD_Parameter BreakpointChordLength
        {
            get => _BreakpointChordLength;
            set => _BreakpointChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Root Chord Length - (CHRDR)
        public CAD_Parameter RootChordLength
        {
            get => _RootChordLength;
            set => _RootChordLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Semi-Spans
        //
        //  Outboard Panel Semi-Span Length - (SSNOP)
        public CAD_Parameter OutboardPanelSemiSpanLength
        {
            get => _OutboardPanelSemiSpanLength;
            set => _OutboardPanelSemiSpanLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Exposed Panel Semi-Span Length - (SSNEP)
        public CAD_Parameter ExposedPanelSemiSpanLength
        {
            get => _ExposedPanelSemiSpanLength;
            set => _ExposedPanelSemiSpanLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Theoretical Panel Semi-Span Length at Root Chord - (SSPN)
        public CAD_Parameter TheoreticalPanelSemiSpanLength
        {
            get => _TheoreticalPanelSemiSpanLength;
            set => _TheoreticalPanelSemiSpanLength = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Outboard Panel Semi-Span Length with Dihedral - (SSNDD)
        public CAD_Parameter OutboardPanelSemiSpanLength_Dihedral
        {
            get => _OutboardPanelSemiSpanLength_Dihedral;
            set => _OutboardPanelSemiSpanLength_Dihedral = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Sweep Angles
        //
        //  Inboard Panel Sweep Angle - (SAVSI)
        public CAD_Parameter InboardPanelSweepAngle
        {
            get => _InboardPanelSweepAngle;
            set => _InboardPanelSweepAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Outboard Panel Sweep Angle - (SAVSO)
        public CAD_Parameter OutboardPanelSweepAngle
        {
            get => _OutboardPanelSweepAngle;
            set => _OutboardPanelSweepAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Dihedral Angles
        //
        //  Inboard Panel Dihedral Angle - (DHDADI)
        public CAD_Parameter InboardPanelDihedralAngle
        {
            get => _InboardPanelDihedralAngle;
            set => _InboardPanelDihedralAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Outboard Panel Dihedral Angle - (DHDADO)
        public CAD_Parameter OutboardPanelDihedralAngle
        {
            get => _OutboardPanelDihedralAngle;
            set => _OutboardPanelDihedralAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Twist Angle - (TWISTA)
        public CAD_Parameter TwistAngle
        {
            get => _TwistAngle;
            set => _TwistAngle = value ?? throw new ArgumentNullException(nameof(value));
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
