using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_SYMFLP : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Flap Enumerations
        //
        //  Flap Type
        private CAD_Parameter _FlapType = CreateIntegerParameter("FTYPE", (int)FlapTypeEnum.PlainFlap);
        //
        //  Nose Type
        private CAD_Parameter _NoseType = CreateIntegerParameter("NTYPE", (int)NoseTypeEnum.Round);
        //
        //  Jet Flap Type
        private CAD_Parameter _JetFlapType = CreateIntegerParameter("JETFLP", (int)JetFlapTypeEnum.Pure);
        //
        //  Flap Deflection Angles
        //
        //  Number of Flap Deflections
        private CAD_Parameter _NumberFlapDeflections = CreateIntegerParameter("NDELTA");
        //
        //  Flap Deflection Angle
        private List<CAD_Parameter> _DeflectionAngles = new();
        //
        //  Flap Geometry
        //
        //  Tangent of Airfoil Trailing Edge Angle
        private CAD_Parameter _TangentOfAirfoilTrailingEdgeAngle = CreateDoubleParameter("PHETE");
        //
        //  Tangent of Airfoil Trailing Edge Angle Based on Ordinates at 95% & 99% Chord
        private CAD_Parameter _TangentOfAirfoilTrailingEdgeAngle_95_99_Chord = CreateDoubleParameter("PHETEP");
        //
        //  Inboard End Longitudinal Flap Chord
        private CAD_Parameter _InboardEndLongitudinalFlapChord = CreateDoubleParameter("CHRDFI");
        //
        //  Outboard End Longitudinal Flap Chord
        private CAD_Parameter _OutboardEndLongitudinalFlapChord = CreateDoubleParameter("CHRDFO");
        //
        //  Inboard End Vertical Flap Span Location
        private CAD_Parameter _InboardEndVerticalFlapSpanLocation = CreateDoubleParameter("SPANFI");
        //
        //  Outboard End Vertical Flap Span Location
        private CAD_Parameter _OutboardEndVerticalFlapSpanLocation = CreateDoubleParameter("SPANFO");
        //
        //  Total Wing Chord at Inboard End 
        private List<CAD_Parameter> _TotalWingChordAtInboardEnd = new();
        //
        //  Total Wing Chord at Outboard End 
        private List<CAD_Parameter> _TotalWingChordAtOutboardEnd = new();
        //
        //  Average Chord of the Balance
        private CAD_Parameter _AverageChordOfBalance = CreateDoubleParameter("CB");
        //
        //  Average Thickness At Hinge Line
        private CAD_Parameter _AverageThicknessAtHingeLine = CreateDoubleParameter("TC");
        //
        //  Performance
        //
        //  Increment in Section Lift Coefficient Due to Deflecting Flap to Specified Angle
        private List<CAD_Parameter> _SectionLiftCoefficientIncrement = new();
        //
        //  Increment in Section Pitching Moment Coefficient Due to Deflecting Flap to Specified Angle
        private List<CAD_Parameter> _SectionPitchingMomentCoefficientIncrement = new();
        //
        //  Jet Flap Definitions
        //
        //  Two-Dimensional Jet Efflux Coefficient
        private CAD_Parameter _JetEffluxCoeff2D = CreateDoubleParameter("CMU");
        //
        //  Jet Deflection Angle
        private List<CAD_Parameter> _JetDeflectionAngle = new();
        //
        //  EBF Effective Jet Deflection Angle
        private List<CAD_Parameter> _EBFEffectiveJetDeflectionAngle = new();
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
        public enum FlapTypeEnum
        {
            PlainFlap = 1,
            SingleSlottedFlap,
            FowlerFlap,
            DoubleSlottedFlap,
            SplitFlap,
            LeadingEdgeFlap,
            LeadingEdgeSlat,
            KruegerFlap
        }
        public enum NoseTypeEnum
        {
            Round = 1,
            Elliptic,
            Sharp
        }
        public enum JetFlapTypeEnum
        {
            Pure = 1,
            IBF,
            EBF,
            Mechanical_PureJetCombo
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  DATCOM_SYMFLP CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_SYMFLP()
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
        //  Flap Enumerations
        //
        //  Flap Type
        public CAD_Parameter FlapType
        {
            get => _FlapType;
            set => _FlapType = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Nose Type
        public CAD_Parameter NoseType
        {
            get => _NoseType;
            set => _NoseType = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Flap Type
        public CAD_Parameter JetFlapType
        {
            get => _JetFlapType;
            set => _JetFlapType = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Flap Deflection Angles
        //
        //  Number of Flap Deflections
        public CAD_Parameter NumberFlapDeflections
        {
            get => _NumberFlapDeflections;
            set => _NumberFlapDeflections = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Flap Deflection Angle
        public List<CAD_Parameter> DeflectionAngles
        {
            get => _DeflectionAngles;
            set => _DeflectionAngles = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Flap Geometry
        //
        //  Tangent of Airfoil Trailing Edge Angle
        public CAD_Parameter TangentOfAirfoilTrailingEdgeAngle
        {
            get => _TangentOfAirfoilTrailingEdgeAngle;
            set => _TangentOfAirfoilTrailingEdgeAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Tangent of Airfoil Trailing Edge Angle Based on Ordinates at 95% & 99% Chord
        public CAD_Parameter TangentOfAirfoilTrailingEdgeAngle_95_99_Chord
        {
            get => _TangentOfAirfoilTrailingEdgeAngle_95_99_Chord;
            set => _TangentOfAirfoilTrailingEdgeAngle_95_99_Chord = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Inboard End Longitudinal Flap Chord
        public CAD_Parameter InboardEndLongitudinalFlapChord
        {
            get => _InboardEndLongitudinalFlapChord;
            set => _InboardEndLongitudinalFlapChord = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Outboard End Longitudinal Flap Chord
        public CAD_Parameter OutboardEndLongitudinalFlapChord
        {
            get => _OutboardEndLongitudinalFlapChord;
            set => _OutboardEndLongitudinalFlapChord = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Inboard End Vertical Flap Span Location
        public CAD_Parameter InboardEndVerticalFlapSpanLocation
        {
            get => _InboardEndVerticalFlapSpanLocation;
            set => _InboardEndVerticalFlapSpanLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Outboard End Vertical Flap Span Location
        public CAD_Parameter OutboardEndVerticalFlapSpanLocation
        {
            get => _OutboardEndVerticalFlapSpanLocation;
            set => _OutboardEndVerticalFlapSpanLocation = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Total Wing Chord at Inboard End 
        public List<CAD_Parameter> TotalWingChordAtInboardEnd
        {
            get => _TotalWingChordAtInboardEnd;
            set => _TotalWingChordAtInboardEnd = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Total Wing Chord at Outboard End 
        public List<CAD_Parameter> TotalWingChordAtOutboardEnd
        {
            get => _TotalWingChordAtOutboardEnd;
            set => _TotalWingChordAtOutboardEnd = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Average Chord of the Balance
        public CAD_Parameter AverageChordOfBalance
        {
            get => _AverageChordOfBalance;
            set => _AverageChordOfBalance = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Average Thickness At Hinge Line
        public CAD_Parameter AverageThicknessAtHingeLine
        {
            get => _AverageThicknessAtHingeLine;
            set => _AverageThicknessAtHingeLine = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Performance
        //
        //  Increment in Section Lift Coefficient Due to Deflecting Flap to Specified Angle
        public List<CAD_Parameter> SectionLiftCoefficientIncrement
        {
            get => _SectionLiftCoefficientIncrement;
            set => _SectionLiftCoefficientIncrement = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Increment in Section Pitching Moment Coefficient Due to Deflecting Flap to Specified Angle
        public List<CAD_Parameter> SectionPitchingMomentCoefficientIncrement
        {
            get => _SectionPitchingMomentCoefficientIncrement;
            set => _SectionPitchingMomentCoefficientIncrement = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Flap Definitions
        //
        //  Two-Dimensional Jet Efflux Coefficient
        public CAD_Parameter JetEffluxCoeff2D
        {
            get => _JetEffluxCoeff2D;
            set => _JetEffluxCoeff2D = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Jet Deflection Angle
        public List<CAD_Parameter> JetDeflectionAngle
        {
            get => _JetDeflectionAngle;
            set => _JetDeflectionAngle = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  EBF Effective Jet Deflection Angle
        public List<CAD_Parameter> EBFEffectiveJetDeflectionAngle
        {
            get => _EBFEffectiveJetDeflectionAngle;
            set => _EBFEffectiveJetDeflectionAngle = value ?? throw new ArgumentNullException(nameof(value));
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
