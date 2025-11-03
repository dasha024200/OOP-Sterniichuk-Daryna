using System;
using System.Collections.Generic;
using System.Linq;
using lab5v17.Exceptions;
using lab5v17.Generics;

namespace lab5v17.Domain
{
    public class Hall
    {
        public int Id { get; }
        public string Name { get; }
        public int Rows { get; }
        public int SeatsPerRow { get; }
        public decimal SeatPrice { get; }

        // Matrix<bool>: true = місце зайнято, false = вільно
        private readonly Matrix<bool> _seats;
        private readonly List<SeatReservation> _reservations = new();

        public Hall(int id, string name, int rows, int seatsPerRow, decimal seatPrice)
        {
            if (rows <= 0 || seatsPerRow <= 0) throw new ArgumentException("Розміри залу мають бути додатні");
            if (seatPrice <= 0) throw new ArgumentException("Ціна квитка має бути > 0");

            Id = id;
            Name = name;
            Rows = rows;
            SeatsPerRow = seatsPerRow;
            SeatPrice = seatPrice;

            _seats = new Matrix<bool>(rows, seatsPerRow, defaultValue: false);
        }

        public SeatReservation ReserveSeat(int row, int seat, string customerName)
        {
            ValidateSeat(row, seat);

            if (_seats[row - 1, seat - 1])
                throw new SeatAlreadyBookedException($"Місце вже заброньовано (ряд {row}, місце {seat}).");

            _seats[row - 1, seat - 1] = true;
            var reservation = new SeatReservation(Id, row, seat, customerName, SeatPrice);
            _reservations.Add(reservation);
            return reservation;
        }

        public decimal GetRevenue() => _reservations.Sum(r => r.Price);

        public double GetOccupancyPercent()
        {
            var total = Rows * SeatsPerRow;
            var booked = _reservations.Count;
            return total == 0 ? 0 : booked * 100.0 / total;
        }

        public IEnumerable<(int Row, int Count)> GetTopRowsByPopularity(int topN)
        {
            return _reservations
                .GroupBy(r => r.Row)
                .Select(g => (Row: g.Key, Count: g.Count()))
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Row)
                .Take(topN);
        }

        public void PrintSeatMap()
        {
            for (int r = 1; r <= Rows; r++)
            {
                Console.Write($"Ряд {r,2}: ");
                for (int s = 1; s <= SeatsPerRow; s++)
                {
                    Console.Write(_seats[r - 1, s - 1] ? "#" : "X");
                    if (s < SeatsPerRow) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private void ValidateSeat(int row, int seat)
        {
            if (row < 1 || row > Rows || seat < 1 || seat > SeatsPerRow)
                throw new InvalidSeatException($"Некоректне місце: ряд {row}, місце {seat}.");
        }
    }
}
