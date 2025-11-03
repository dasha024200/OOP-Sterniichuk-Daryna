using System;

namespace lab5v17.Exceptions
{
    public class SeatAlreadyBookedException : Exception
    {
        public SeatAlreadyBookedException(string message) : base(message) { }
    }
}
