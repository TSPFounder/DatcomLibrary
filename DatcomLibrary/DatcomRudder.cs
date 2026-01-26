using DATCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatcomLibrary
{
    public class DatcomRudder
    {
        public DatcomRudder()
        {
            myRudder = new AircraftObjects.Rudder();
            myRudder.ControlType = AircraftObjects.FlightControl.ControlTypeEnum.Rudder;
        }

        public Boolean IsSymmetric { get; set; }
        public DATCOM_ASYFLP assymetricFlap { get; set; }
        public DATCOM_SYMFLP symmetricFlap { get; set; }
        public AircraftObjects.Rudder myRudder { get; set; }
        public String Name { get; set; }
    }
}
