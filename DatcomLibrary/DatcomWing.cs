using System;
using System.Reflection;
using AircraftObjects;
using DATCOM;

namespace DatcomLibrary
{
    public class DatcomWing
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public double AspectRatio { get; set; }
        public double SweepAngle { get; set; }
        public double TaperRatio { get; set; }
        public Wing myWing { get; set; }
        public string AirfoilCode { get; private set; } = string.Empty;
        public DATCOM_WGPLNF? PlanformNamelist { get; private set; }

        public DatcomWing(string name, double area, double aspectRatio, double sweepAngle, double taperRatio)
        {
            Name = name;
            Area = area;
            AspectRatio = aspectRatio;
            SweepAngle = sweepAngle;
            TaperRatio = taperRatio;
            myWing = new Wing();
        }

        public static DatcomWing CreateForNacaCode(string code)
        {
            var trimmed = code?.Trim() ?? string.Empty;
            var name = string.IsNullOrWhiteSpace(trimmed) ? "NACA" : $"NACA-{trimmed}";
            var wing = new DatcomWing(name, 0d, 0d, 0d, 0d)
            {
                AirfoilCode = trimmed
            };

            wing.AssignAirfoil(trimmed);
            return wing;
        }

        public void AttachPlanformNamelist(DATCOM_WGPLNF namelist)
        {
            PlanformNamelist = namelist ?? throw new ArgumentNullException(nameof(namelist));
        }

        private void AssignAirfoil(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return;
            }

            var normalizedCode = code.Trim();
            var wingType = myWing.GetType();
            foreach (var candidate in new[] { "AirfoilType", "Airfoil", "AirfoilName" })
            {
                var property = wingType.GetProperty(candidate, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (property?.CanWrite == true && property.PropertyType == typeof(string))
                {
                    property.SetValue(myWing, normalizedCode);
                    return;
                }
            }

            foreach (var methodName in new[] { "SetAirfoilType", "SetAirfoil", "ApplyAirfoil" })
            {
                var method = wingType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase, null, new[] { typeof(string) }, null);
                if (method is not null)
                {
                    method.Invoke(myWing, new object[] { normalizedCode });
                    return;
                }
            }
        }
    }
}
