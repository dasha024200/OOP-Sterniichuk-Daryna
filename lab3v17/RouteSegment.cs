namespace Lab3.Vehicles
{
    // Один відрізок маршруту
    public sealed class RouteSegment
    {
        public string Name { get; }
        public double DistanceKm { get; }    // довжина сегмента
        public double LoadTons { get; }      // тоннаж для вантажівки
        public int Passengers { get; }       // пасажири для автобуса

        public RouteSegment(string name, double distanceKm, double loadTons = 0, int passengers = 0)
        {
            Name = name;
            DistanceKm = distanceKm;
            LoadTons = loadTons;
            Passengers = passengers;
        }
    }
}
