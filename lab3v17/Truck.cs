using System;

namespace Lab3.Vehicles
{
    // ВАНТАЖІВКА: чим більше тонн, тим більше витрата
    public sealed class Truck : Vehicle
    {
        // скільки літрів/100км додає кожна тонна корисного вантажу
        public double LitersPer100PerTon { get; }

        public Truck(string model, double baseLitersPer100, double litersPer100PerTon)
            : base(model, baseLitersPer100) // ← виклик base(...)
        {
            if (litersPer100PerTon < 0) throw new ArgumentException("Factor must be >= 0");
            LitersPer100PerTon = litersPer100PerTon;
        }

        public override double FuelConsumption(RouteSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            double per100 = BaseLitersPer100 + LitersPer100PerTon * Math.Max(0, segment.LoadTons);
            return per100 * (segment.DistanceKm / 100.0);
        }
    }
}
