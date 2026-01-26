using System;
using System.Collections.Generic;
using System.Text;
using AircraftObjects;
using DATCOM;

namespace DatcomLibrary
{
    public class DatcomElevator
    {
        public DatcomElevator()
        {
            myElevator = new Elevator();
            myElevator.ControlType = FlightControl.ControlTypeEnum.Elevator;
        }
        public Boolean IsSymmetric { get; set; }
        public DATCOM_ASYFLP assymetricFlap { get; set; }
        public DATCOM_SYMFLP symmetricFlap { get; set; }
        public Elevator myElevator { get; set; }
        public String Name { get; set; }
    }
}
