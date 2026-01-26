using System;
using AircraftObjects;

namespace DatcomLibrary
{
    public class DatcomHorizontalStabilizer
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public double AspectRatio { get; set; }
        public double SweepAngle { get; set; }
        public double TaperRatio { get; set; }
        public HorizontalStabilizer myHorizontalStabilizer { get; set; }
        public string AirfoilCode { get; private set; } = string.Empty;

        public DatcomHorizontalStabilizer(string name, double area, double aspectRatio, double sweepAngle, double taperRatio)
        {
            Name = name;
            Area = area;
            AspectRatio = aspectRatio;
            SweepAngle = sweepAngle;
            TaperRatio = taperRatio;
            myHorizontalStabilizer = new HorizontalStabilizer();
        }

        public static DatcomHorizontalStabilizer CreateForNacaCode(string code)
        {
            var trimmed = code?.Trim() ?? string.Empty;
            var name = string.IsNullOrWhiteSpace(trimmed) ? "NACA-H" : $"NACA-H-{trimmed}";
            var stabilizer = new DatcomHorizontalStabilizer(name, 0d, 0d, 0d, 0d)
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

            myHorizontalStabilizer.Airfoils.Add(airfoil);
        }
    }
}
