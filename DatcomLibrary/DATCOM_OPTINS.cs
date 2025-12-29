using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATCOM
{
    public class DATCOM_OPTINS : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Surface Roughness Factor
        private Double _SurfaceRoughnessFactor;
        //
        //  Reference Area
        private Double _ReferenceArea;
        //
        //  Longitudinal Wing Mean Aerodynamic Chord Length
        private Double _LongitudinalWingMeanChordLength;
        //
        //  Lateral Wing Span Reference Length
        private Double _LateralWingSpanReferenceLength;

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
        //  DATCOM_OPTINS CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_OPTINS()
        {
            this.NamelistGroupNumber = 1;
        }
        //  *****************************************************************************************


        //  *****************************************************************************************
        //  PROPERTIES
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Surface Roughness Factor
        public Double SurfaceRoughnessFactor
        {
            set { }
            get
            {
                return _SurfaceRoughnessFactor;
            }
        }
        //
        //  Reference Area
        public Double ReferenceArea
        {
            set { }
            get
            {
                return _ReferenceArea;
            }
        }
        //
        //  Longitudinal Wing Mean Aerodynamic Chord Length
        public Double LongitudinalWingMeanChordLength
        {
            set { }
            get
            {
                return _LongitudinalWingMeanChordLength;
            }
        }
        //
        //  Lateral Wing Span Reference Length
        public Double LateralWingSpanReferenceLength
        {
            set { }
            get
            {
                return _LateralWingSpanReferenceLength;
            }
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
