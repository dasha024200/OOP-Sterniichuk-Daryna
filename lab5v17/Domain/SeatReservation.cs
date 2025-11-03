using System;

namespace lab5v17.Domain
{
    public class SeatReservation
    {
        public int HallId { get; }
        public int Row { get; }
        public int Seat { get; }
        public string CustomerName { get; }
        public decimal Price { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;

        public SeatReservation(int hallId, int row, int seat, string customerName, decimal price)
        {
            HallId = hallId;
            Row = row;
            Seat = seat;
            CustomerName = customerName;
            Price = price;
        }
    }
}
