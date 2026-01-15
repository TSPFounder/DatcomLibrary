using AircraftObjects;
using DATCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatcomLibrary
{
    internal class DatcomFlap
    {
        public DatcomFlap() { 
        
            myFlap = new Flap();
            myFlap.ControlType = FlightControl.ControlTypeEnum.Flap;  
        }

        public Boolean IsSymmetric { get; set; }
        public DATCOM_ASYFLP assymetricFlap { get; set; }
        public DATCOM_SYMFLP symmetricFlap { get; set; }
        public Flap myFlap { get; set; }

        public void AddAssymetricFlap(DATCOM_ASYFLP flap)
        {
            assymetricFlap = flap;
            IsSymmetric = false;
        }

        public void AddSymmetricFlap(DATCOM_SYMFLP flap)
        {
            symmetricFlap = flap;
            IsSymmetric = true;
        }
    }
}
