using System;
using System.Collections.Generic;
using Lab3.Vehicles;

class Program
{
    static void Main()
    {
        // 1) Готуємо маршрут з кількох сегментів
        var route = new List<RouteSegment>
        {
            new RouteSegment("Місто → Траса", distanceKm: 25,  loadTons: 2.0, passengers: 18),
            new RouteSegment("Траса М-06",     distanceKm: 120, loadTons: 5.5, passengers: 30),
            new RouteSegment("Об’їзна",        distanceKm: 15,  loadTons: 1.0, passengers: 12)
        };

        // 2) Поліморфна колекція транспортних засобів
        var vehicles = new List<Vehicle>
        {
            new Truck(model: "Volvo FM",   baseLitersPer100: 28, litersPer100PerTon: 0.9),
            new Bus  (model: "MAN Lion",   baseLitersPer100: 20, litersPer100PerPassenger: 0.08),
            new Truck(model: "DAF XF",     baseLitersPer100: 30, litersPer100PerTon: 0.8),
            new Bus  (model: "Bogdan A092",baseLitersPer100: 18, litersPer100PerPassenger: 0.06)
        };

        Console.WriteLine("=== Сумарна витрата пального на маршруті ===\n");
        foreach (var v in vehicles)
        {
            double total = 0;
            foreach (var seg in route)
                total += v.FuelConsumption(seg);   // ← поліморфний виклик override-методу

            Console.WriteLine($"{v,-28} => {total:0.00} л");
        }

        // (Необов'язково) Демонстрація фіналізаторів для критеріїв ЛР
        vehicles = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}

