using System;
using System.Collections.Generic;
using System.Text;
using AircraftObjects;
using SE_Library;

namespace DatcomLibrary
{
    public class DatcomVerticalStabilizer
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public double AspectRatio { get; set; }
        public double SweepAngle { get; set; }
        public double TaperRatio { get; set; }
        public VerticalStabilizer myVerticalStabilizer { get; set; }

        public string AirfoilCode { get; private set; } = string.Empty;

        public DatcomVerticalStabilizer(string name, double area, double aspectRatio, double sweepAngle, double taperRatio)
        {
            Name = name;
            Area = area;
            AspectRatio = aspectRatio;
            SweepAngle = sweepAngle;
            TaperRatio = taperRatio;
            myVerticalStabilizer = new VerticalStabilizer();
        }

        public static DatcomVerticalStabilizer CreateForNacaCode(string code)
        {
            var trimmed = code?.Trim() ?? string.Empty;
            var name = string.IsNullOrWhiteSpace(trimmed) ? "NACA-V" : $"NACA-V-{trimmed}";
            var stabilizer = new DatcomVerticalStabilizer(name, 0d, 0d, 0d, 0d)
            {
                AirfoilCode = trimmed
            };

            stabilizer.AssignAirfoil(trimmed);
            return stabilizer;
        }

        private void AssignAirfoil(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return;
            }

            var normalizedCode = code.Trim();
            var airfoil = new Airfoil
            {
                Name = normalizedCode,
                ID = normalizedCode,
                AirfoilType = Airfoil.AirfoilTypeEnum.NACA
            };

            myVerticalStabilizer.Airfoils.Add(airfoil);
        }
    }
}
