using System;
using System.Collections.Generic;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_ASYFLP : DATCOM_Namelist
    {
        private const int MaxFlapEntries = 9;

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
        private CAD_Parameter _FlapType = CreateEnumParameter("STYPE", (int)FlapTypeEnum.FlapSpoilerOnWing);  // - STYPE
        //
        //  Flap Deflection Angles
        //
        //  Number of Flap Deflections
        private CAD_Parameter _NumberFlapDeflections = CAD_Parameter.CreateIntegerParameter("NDELTA");  // - NDELTA
        //
        //  Left Hand Flap Deflection Angle
        private List<CAD_Parameter> _LeftHandDeflectionAngles = CreateDoubleParameterList("DELTAL", MaxFlapEntries);  // - DELTAL
        //
        //  Right Hand Flap Deflection Angle
        private List<CAD_Parameter> _RightHandDeflectionAngles = CreateDoubleParameterList("DELTAR", MaxFlapEntries);  // - DELTAR
        //
        //  Projected Deflector Height as Percent of Chord
        private List<CAD_Parameter> _ProjectedDeflectorHeightAsPercentChord = CreateDoubleParameterList("DELTAD", MaxFlapEntries);  // - DELTAD
        //
        //  Flap Geometry
        //
        //  Tangent of Airfoil Trailing Edge Angle
        private CAD_Parameter _TangentOfAirfoilTrailingEdgeAngle = CAD_Parameter.CreateDoubleParameter("PHETE");  // - PHETE
        //
        //  Inboard End Longitudinal Flap Aileron Chord
        private CAD_Parameter _InboardEndLongitudinalFlapChord = CAD_Parameter.CreateDoubleParameter("CHRDFI");  // - CHRDFI
        //
        //  Outboard End Longitudinal Flap Aileron Chord
        private CAD_Parameter _OutboardEndLongitudinalFlapChord = CAD_Parameter.CreateDoubleParameter("CHRDFO");  // - CHRDFO
        //
        //  Inboard End Vertical Flap Span Location
        private CAD_Parameter _InboardEndVerticalFlapSpanLocation = CAD_Parameter.CreateDoubleParameter("SPANFI");  // - SPANFI
        //
        //  Outboard End Vertical Flap Span Location
        private CAD_Parameter _OutboardEndVerticalFlapSpanLocation = CAD_Parameter.CreateDoubleParameter("SPANFO");  // - SPANFO
        //
        //  Spoiler Geometry
        //
        //  Spoiler Lip Distance to Wing Leading Edge  as Percent of Chord
        private List<CAD_Parameter> _SpoilerLipDistanceToWingLE = CreateDoubleParameterList("XSOC", MaxFlapEntries);  // - XSOC
        //
        //  Spoiler Hinge Line Distance to Wing Leading Edge  as Percent of Chord
        private CAD_Parameter _SpoilerHingeLineDistanceToWingLE = CAD_Parameter.CreateDoubleParameter("XSPRME");  // - XSPRME
        //
        //  Projected Spoiler Height to Mean Line as Percent of Chord
        private List<CAD_Parameter> _ProjectedSpoilerHeightToMeanLineAsPercentChord = CreateDoubleParameterList("HSOC", MaxFlapEntries);  // - HSOC
        //
        //  Projected Spoiler Height as Percent of Chord
        private List<CAD_Parameter> _ProjectedSpoilerHeightAsPercentChord = CreateDoubleParameterList("DELTAS", MaxFlapEntries);  // - DELTAS

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
            FlapSpoilerOnWing = 1,
            PlugSpoilerOnWing,
            SpoilerSlotDeflectionOnWing,
            PlainFlapAileron,
            DifferentialyDeflectedAllMoveableHorizontalTail
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  DATCOM_ASYFLP CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_ASYFLP()
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
        //  Flap Deflection Angles
        //
        //  Number of Flap Deflections
        public CAD_Parameter NumberFlapDeflections
        {
            get => _NumberFlapDeflections;
            set => _NumberFlapDeflections = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Left Hand Flap Deflection Angle
        public List<CAD_Parameter> LeftHandDeflectionAngles
        {
            get => _LeftHandDeflectionAngles;
            set => _LeftHandDeflectionAngles = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Right Hand Flap Deflection Angle
        public List<CAD_Parameter> RightHandDeflectionAngles
        {
            get => _RightHandDeflectionAngles;
            set => _RightHandDeflectionAngles = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Projected Deflector Height as Percent of Chord
        public List<CAD_Parameter> ProjectedDeflectorHeightAsPercentChord
        {
            get => _ProjectedDeflectorHeightAsPercentChord;
            set => _ProjectedDeflectorHeightAsPercentChord = value ?? throw new ArgumentNullException(nameof(value));
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
        //  Inboard End Longitudinal Flap Aileron Chord
        public CAD_Parameter InboardEndLongitudinalFlapChord
        {
            get => _InboardEndLongitudinalFlapChord;
            set => _InboardEndLongitudinalFlapChord = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Outboard End Longitudinal Flap Aileron Chord
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
        //  Spoiler Geometry
        //
        //  Spoiler Lip Distance to Wing Leading Edge  as Percent of Chord
        public List<CAD_Parameter> SpoilerLipDistanceToWingLE
        {
            get => _SpoilerLipDistanceToWingLE;
            set => _SpoilerLipDistanceToWingLE = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Spoiler Hinge Line Distance to Wing Leading Edge  as Percent of Chord
        public CAD_Parameter SpoilerHingeLineDistanceToWingLE
        {
            get => _SpoilerHingeLineDistanceToWingLE;
            set => _SpoilerHingeLineDistanceToWingLE = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Projected Spoiler Height to Mean Line as Percent of Chord
        public List<CAD_Parameter> ProjectedSpoilerHeightToMeanLineAsPercentChord
        {
            get => _ProjectedSpoilerHeightToMeanLineAsPercentChord;
            set => _ProjectedSpoilerHeightToMeanLineAsPercentChord = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Projected Spoiler Height as Percent of Chord
        public List<CAD_Parameter> ProjectedSpoilerHeightAsPercentChord
        {
            get => _ProjectedSpoilerHeightAsPercentChord;
            set => _ProjectedSpoilerHeightAsPercentChord = value ?? throw new ArgumentNullException(nameof(value));
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

        private static CAD_Parameter CreateEnumParameter(string name, int initialValue) => CAD_Parameter.CreateIntegerParameter(name, initialValue);

        

        private static List<CAD_Parameter> CreateDoubleParameterList(string prefix, int count)
        {
            var list = new List<CAD_Parameter>(count);
            for (var i = 1; i <= count; i++)
            {
                list.Add(CAD_Parameter.CreateDoubleParameter($"{prefix}{i}"));
            }

            return list;
        }
    }
}
