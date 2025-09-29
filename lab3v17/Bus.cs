using System;

namespace Lab3.Vehicles
{
    // АВТОБУС: залежність від кількості пасажирів
    public sealed class Bus : Vehicle
    {
        // додаткові л/100км на кожного пасажира (спрощена модель)
        public double LitersPer100PerPassenger { get; }

        public Bus(string model, double baseLitersPer100, double litersPer100PerPassenger)
            : base(model, baseLitersPer100)
        {
            if (litersPer100PerPassenger < 0) throw new ArgumentException("Factor must be >= 0");
            LitersPer100PerPassenger = litersPer100PerPassenger;
        }

        public override double FuelConsumption(RouteSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            double per100 = BaseLitersPer100 + LitersPer100PerPassenger * Math.Max(0, segment.Passengers);
            return per100 * (segment.DistanceKm / 100.0);
        }
    }
}
