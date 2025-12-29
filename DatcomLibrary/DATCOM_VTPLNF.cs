using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_VTPLNF : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Planform Type
        private CAD_Parameter _PlanformType = CreateIntegerParameter("TYPE", (int)PlanformTypeEnum.StraightTapered);
        //
        //  Chords
        //
        //  Tip Chord Length - (CHRDTP)
        private CAD_Parameter _TipChordLength = CreateDoubleParameter("CHRDTP");
        //
        //  Chord Length at Breakpoint - (CHRDBP)
        private CAD_Parameter _BreakpointChordLength = CreateDoubleParameter("CHRDBP");
        //
        //  Root Chord Length - (CHRDR)
        private CAD_Parameter _RootChordLength = CreateDoubleParameter("CHRDR");
        //
        //  Semi-Spans
        //
        //  Outboard Panel Semi-Span Length - (SSNOP)
        private CAD_Parameter _OutboardPanelSemiSpanLength = CreateDoubleParameter("SSNOP");
        //
        //  Exposed Panel Semi-Span Length - (SSNEP)
        private CAD_Parameter _ExposedPanelSemiSpanLength = CreateDoubleParameter("SSNEP");
        //
        //  Theoretical Panel Semi-Span Length at Root Chord - (SSPN)
        private CAD_Parameter _TheoreticalPanelSemiSpanLength = CreateDoubleParameter("SSPN");
        //
        //  Outboard Panel Semi-Span Length with Dihedral - (SSNDD)
        private CAD_Parameter _OutboardPanelSemiSpanLength_Dihedral = CreateDoubleParameter("SSNDD");
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
        //  DATCOM_VTPLNF CONSTRUCTOR
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
