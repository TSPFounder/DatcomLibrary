using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DATCOM
{
    public class DATCOM_VFPLNF : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Planform Type
        private (PlanformTypeEnum Value, string TYPE) _PlanformType = (PlanformTypeEnum.StraightTapered, "TYPE");
        //
        //  Chords
        //
        //  Tip Chord Length - (CHRDTP)
        private (double Value, string CHRDTP) _TipChordLength = (0d, "CHRDTP");
        //
        //  Chord Length at Breakpoint - (CHRDBP)
        private (double Value, string CHRDBP) _BreakpointChordLength = (0d, "CHRDBP");
        //
        //  Root Chord Length - (CHRDR)
        private (double Value, string CHRDR) _RootChordLength = (0d, "CHRDR");
        //
        //  Semi-Spans
        //
        //  Outboard Panel Semi-Span Length - (SSNOP)
        private (double Value, string SSNOP) _OutboardPanelSemiSpanLength = (0d, "SSNOP");
        //
        //  Exposed Panel Semi-Span Length - (SSNEP)
        private (double Value, string SSNEP) _ExposedPanelSemiSpanLength = (0d, "SSNEP");
        //
        //  Theoretical Panel Semi-Span Length at Root Chord - (SSPN)
        private (double Value, string SSPN) _TheoreticalPanelSemiSpanLength = (0d, "SSPN");
        //
        //  Outboard Panel Semi-Span Length with Dihedral - (SSNDD)
        private (double Value, string SSNDD) _OutboardPanelSemiSpanLength_Dihedral = (0d, "SSNDD");
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
        //  DATCOM_VFPLNF CONSTRUCTOR
        //
        //  ************************************************************

        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //  Namelist Data
        //
        //  Planform Type - (TYPE)
        public (PlanformTypeEnum Value, string TYPE) PlanformType
        {
            get => _PlanformType;
            set => _PlanformType = value;
        }
        //
        //  Chords
        //
        //  Tip Chord Length - (CHRDTP)
        public (double Value, string CHRDTP) TipChordLength
        {
            get => _TipChordLength;
            set => _TipChordLength = value;
        }
        //
        //  Chord Length at Breakpoint - (CHRDBP)
        public (double Value, string CHRDBP) BreakpointChordLength
        {
            get => _BreakpointChordLength;
            set => _BreakpointChordLength = value;
        }
        //
        //  Root Chord Length - (CHRDR)
        public (double Value, string CHRDR) RootChordLength
        {
            get => _RootChordLength;
            set => _RootChordLength = value;
        }
        //
        //  Semi-Spans
        //
        //  Outboard Panel Semi-Span Length - (SSNOP)
        public (double Value, string SSNOP) OutboardPanelSemiSpanLength
        {
            get => _OutboardPanelSemiSpanLength;
            set => _OutboardPanelSemiSpanLength = value;
        }
        //
        //  Exposed Panel Semi-Span Length - (SSNEP)
        public (double Value, string SSNEP) ExposedPanelSemiSpanLength
        {
            get => _ExposedPanelSemiSpanLength;
            set => _ExposedPanelSemiSpanLength = value;
        }
        //
        //  Theoretical Panel Semi-Span Length at Root Chord - (SSPN)
        public (double Value, string SSPN) TheoreticalPanelSemiSpanLength
        {
            get => _TheoreticalPanelSemiSpanLength;
            set => _TheoreticalPanelSemiSpanLength = value;
        }
        //
        //  Outboard Panel Semi-Span Length with Dihedral - (SSNDD)
        public (double Value, string SSNDD) OutboardPanelSemiSpanLength_Dihedral
        {
            get => _OutboardPanelSemiSpanLength_Dihedral;
            set => _OutboardPanelSemiSpanLength_Dihedral = value;
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
