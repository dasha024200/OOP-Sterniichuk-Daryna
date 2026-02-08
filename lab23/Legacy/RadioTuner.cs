using System;

namespace lab23.Legacy
{
    public class RadioTuner
    {
        public void On() => Console.WriteLine("Radio ON.");
        public void Off() => Console.WriteLine("Radio OFF.");
        public void SetStation(double freq) => Console.WriteLine($"Radio station set to {freq:0.0} FM.");
    }
}
