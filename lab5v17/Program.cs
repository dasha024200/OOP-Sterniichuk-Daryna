using System;
using System.Linq;
using lab5v17.Domain;
using lab5v17.Generics;
using lab5v17.Exceptions;

namespace lab5v17
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна №5: Кінотеатр і бронювання (Generics + LINQ + Exceptions) ===");

            // 1) Дані: один кінотеатр з одним залом (5 рядів × 8 місць)
            var cinema = new Cinema("Кінотеатр 'Україна'");
            var hall = new Hall(id: 1, name: "Зал №1", rows: 5, seatsPerRow: 8, seatPrice: 120m);
            cinema.AddHall(hall);

            // 2) Репозиторій бронювань (Generics Repository<SeatReservation>)
            var reservations = new Repository<SeatReservation>();

            // 3) Спробуємо зробити кілька бронювань
            TryReserve(hall, reservations, row: 1, seat: 1, "Оксана");
            TryReserve(hall, reservations, row: 1, seat: 2, "Іван");
            TryReserve(hall, reservations, row: 2, seat: 5, "Дарина");

            // 4) Демонстрація винятку: подвійне бронювання того ж місця
            try
            {
                Console.WriteLine("\n-- Спроба подвійного бронювання (ряд 1, місце 1) --");
                hall.ReserveSeat(row: 1, seat: 1, customerName: "Петро");
            }
            catch (SeatAlreadyBookedException ex)
            {
                Console.WriteLine($"Очікувана помилка: {ex.Message}");
            }

            // 5) Обчислення з колекціями / LINQ
            Console.WriteLine("\n=== Звіт по залу ===");
            var occupancy = hall.GetOccupancyPercent();
            var revenue   = hall.GetRevenue();
            Console.WriteLine($"Завантаженість залу: {occupancy:F1}%");
            Console.WriteLine($"Дохід: {revenue:0.00} грн");

            // Топ-популярні ряди (за кількістю бронювань), беремо 3
            var topRows = hall.GetTopRowsByPopularity(topN: 3);
            Console.WriteLine("Топ ряди за популярністю:");
            foreach (var (row, count) in topRows)
                Console.WriteLine($" - Ряд {row}: {count} бронювань");

            // 6) Приклади LINQ-запитів через Repository
            Console.WriteLine("\n=== Пошук у репозиторії бронювань (Repository.Where) ===");
            var row1Res = reservations.Where(r => r.HallId == hall.Id && r.Row == 1);
            foreach (var r in row1Res)
                Console.WriteLine($"Ряд {r.Row}, місце {r.Seat} — {r.CustomerName} ({r.CreatedAt:HH:mm:ss})");

            // 7) Показ усіх місць у вигляді матриці (Generics Matrix<T>)
            Console.WriteLine("\n=== Схема місць (X = вільно, # = зайнято) ===");
            hall.PrintSeatMap();

            Console.WriteLine("\nГотово. Натисни будь-яку клавішу, щоб вийти...");
            Console.ReadKey();
        }

        private static void TryReserve(Hall hall, Generics.Repository<SeatReservation> repo, int row, int seat, string name)
        {
            try
            {
                var res = hall.ReserveSeat(row, seat, name);
                repo.Add(res);
                Console.WriteLine($"OK: Заброньовано ряд {row}, місце {seat} для {name}");
            }
            catch (Exception ex) when (ex is InvalidSeatException || ex is SeatAlreadyBookedException)
            {
                Console.WriteLine($"Помилка бронювання ({row},{seat}): {ex.Message}");
            }
        }
    }
}
