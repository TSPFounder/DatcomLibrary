using DATCOM;
using AircraftObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatcomLibrary
{
    public class DatcomFuselage
    {
        public DatcomFuselage()
        {
            myBody = new DATCOM_BODY();
        }

        public DATCOM_BODY myBody { get; set; }
    }
}
