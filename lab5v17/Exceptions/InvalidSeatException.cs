using System;

namespace lab5v17.Exceptions
{
    public class InvalidSeatException : Exception
    {
        public InvalidSeatException(string message) : base(message) { }
    }
}
