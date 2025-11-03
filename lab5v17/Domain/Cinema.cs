using System.Collections.Generic;

namespace lab5v17.Domain
{
    public class Cinema
    {
        public string Name { get; }
        private readonly List<Hall> _halls = new();

        public Cinema(string name) => Name = name;

        public void AddHall(Hall hall) => _halls.Add(hall);

        public IReadOnlyList<Hall> Halls => _halls;
    }
}
