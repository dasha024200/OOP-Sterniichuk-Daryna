using System;
using lab23.Interfaces;

namespace lab23.Implementations
{
    public class GpsNavigation : INavigation
    {
        public void NavigateTo(string destination) => Console.WriteLine($"Navigating to: {destination}");
    }
}
