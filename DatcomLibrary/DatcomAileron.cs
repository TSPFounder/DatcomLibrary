using AircraftObjects;
using DATCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatcomLibrary
{
    internal class DatcomAileron
    {
        public DatcomAileron()
        {
            myAileron = new Aileron();
            myAileron.ControlType = FlightControl.ControlTypeEnum.Aileron;
        }

        public Boolean IsSymmetric { get; set; }
        public DATCOM_ASYFLP assymetricFlap { get; set; }
        public DATCOM_SYMFLP symmetricFlap { get; set; }

        public Aileron myAileron { get; set; }
        }
}
