using System;
using lab23.Interfaces;

namespace lab23.Implementations
{
    public class EngineControl : IEngineControl
    {
        public void Start() => Console.WriteLine("Engine started.");
        public void Stop() => Console.WriteLine("Engine stopped.");
    }
}
