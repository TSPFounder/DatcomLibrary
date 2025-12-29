using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_GRNDEF : DATCOM_Namelist
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
        //  Number of Ground Heights
        private CAD_Parameter _NumberGroundHeights = CreateIntegerParameter("NGH");  // - NGH - Max of 10
        //
        //  Ground Height Values
        private List<CAD_Parameter> _GroundHeight = new();  // - GRDHT
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
        //  DATCOM_GRNDEF CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_GRNDEF()
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
        //  Number of Ground Heights
        public CAD_Parameter NumberGroundHeights
        {
            get => _NumberGroundHeights;
            set => _NumberGroundHeights = value ?? throw new ArgumentNullException(nameof(value));
        }
        //
        //  Ground Height Values
        public List<CAD_Parameter> GroundHeights
        {
            get => _GroundHeight;
            set => _GroundHeight = value ?? throw new ArgumentNullException(nameof(value));
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
