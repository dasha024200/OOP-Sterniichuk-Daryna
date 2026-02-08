using System;
using lab23.Interfaces;

namespace lab23.Implementations
{
    public class RadioControl : IRadioControl
    {
        public void On() => Console.WriteLine("Radio ON.");
        public void Off() => Console.WriteLine("Radio OFF.");
        public void SetStation(double frequency) => Console.WriteLine($"Radio station set to {frequency:0.0} FM.");
    }
}
