using System;
using System.Collections.Generic;
using CAD;
using SE_Library;

namespace DATCOM
{
    public class DATCOM_BODY : DATCOM_Namelist
    {
        //  *****************************************************************************************
        //  DECLARATIONS
        //
        //  ************************************************************
        //
        //  Namelist Data
        //
        //  Stations 
        public CAD_Parameter NumberStations { get; set; } = CAD_Parameter.CreateIntegerParameter("NX");  //  - NX
        public List<CAD_Parameter> LongitudinalStationLocation { get; set; } = new();  //  - X
        public List<CAD_Parameter> AreaAtStation { get; set; } = new();  //  - S
        public List<CAD_Parameter> PeripheryAtStation { get; set; } = new();  //  - P
        public List<CAD_Parameter> UpperZ_ValueAtStationLocation { get; set; } = new();  //  - ZU
        public List<CAD_Parameter> LowerZ_ValueAtStationLocation { get; set; } = new();  //  - ZL
        //
        //  Nose
        public CAD_Parameter ConicalNose { get; set; } = CAD_Parameter.CreateBooleanParameter("BNOSE", false);  //  - BNOSE
        public CAD_Parameter NoseLength { get; set; } = CAD_Parameter.CreateDoubleParameter("BLN");  //  - BLN
        public CAD_Parameter NoseBluntnessDiameter { get; set; } = CAD_Parameter.CreateDoubleParameter("DS");  //  - DS
        //
        //  Planform Half Width
        public List<CAD_Parameter> PlanformHalfWidth { get; set; } = new();  //  - R**
        //
        //  Tail
        public CAD_Parameter ConicalTail { get; set; } = CAD_Parameter.CreateBooleanParameter("BTAIL", false);  //  - BTAIL
        public CAD_Parameter TailLength { get; set; } = CAD_Parameter.CreateDoubleParameter("BLA");  //  - BLA
        //
        //  Wing Sweep & Area Rule
        //
        //  1 = Straight Wing, No Area Rule
        //  2 = Swept Wing, No Area Rule - Default
        //  3 = Swept Wing, Area Rule
        public CAD_Parameter ITYPE { get; set; } = CAD_Parameter.CreateIntegerParameter("ITYPE");  //  - ITYPE
        //
        //  Coefficient Calculation Method
        public CAD_Parameter JorgensonMethod { get; set; } = CAD_Parameter.CreateBooleanParameter("METHOD", false);  //  - METHOD
        //  *****************************************************************************************


        //  *****************************************************************************************
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
        //  DATCOM_BODY CONSTRUCTOR
        //
        //  ************************************************************
        public DATCOM_BODY()
        {
            this.NamelistGroupNumber = 2;
            this.Group1_NamelistEnum = Group1_DATCOM_NamelistEnum.None;
            this.Group2_NamelistEnum = Group2_DATCOM_NamelistEnum.BODY;
            this.Group3_NamelistEnum = Group3_DATCOM_NamelistEnum.None;
            this.Group4_NamelistEnum = Group4_DATCOM_NamelistEnum.None;
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