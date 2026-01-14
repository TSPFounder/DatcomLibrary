using AircraftObjects;
using DATCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatcomLibrary
{
    internal class DatcomFlap
    {
        public DatcomFlap()
        {
        }

        public Boolean IsSymmetric { get; set; }
        public DATCOM_ASYFLP assymetricFlap { get; set; }
        public DATCOM_ASYFLP symmetricFlap { get; set; }
        public Flap myFlap { get; set; }

        public void AddAssymetricFlap(DATCOM_ASYFLP flap)
        {
            assymetricFlap = flap;
            IsSymmetric = false;
        }

        public void AddSymmetricFlap(DATCOM_ASYFLP flap)
        {
            symmetricFlap = flap;
            IsSymmetric = true;
        }
    }
}
