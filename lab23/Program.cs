using System;
using lab23.Implementations;

namespace lab23
{
    class Program
    {
        static void Main()
        {
            var engine = new EngineControl();
            var radio = new RadioControl();
            var gps = new GpsNavigation();

            var carComputer = new CarComputer(engine, radio, gps);

            Console.WriteLine("=== Refactored (ISP + DIP + DI) ===");
            carComputer.StartCar();
            carComputer.PlayRadio(101.7);
            carComputer.GoTo("Rivne, Soborna 1");
            carComputer.StopRadio();
            carComputer.StopCar();
        }
    }
}
