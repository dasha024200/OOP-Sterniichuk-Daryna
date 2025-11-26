// Program.cs
using System;
using System.Collections.Generic;
using System.Linq; 
using lab6v17.Domain; // <<<< ПІДКЛЮЧАЄМО МОДЕЛЬ

// Оголошення власного делегата (вимога 22)
// Приймає температуру (double) і повертає булеве значення
delegate bool TemperatureCheckDelegate(double temp); // Коментар: Власний делегат

namespace lab6v17 // <<<< ОСНОВНИЙ ПРОСТІР ІМЕН
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Ініціалізація колекції List<TemperatureRecord>
            List<TemperatureRecord> records = new List<TemperatureRecord>()
            {
                new TemperatureRecord("Понеділок", 22.5),
                new TemperatureRecord("Вівторок", 26.0),
                new TemperatureRecord("Середа", 19.8),
                new TemperatureRecord("Четвер", 30.1),
                new TemperatureRecord("П'ятниця", 24.5),
                new TemperatureRecord("Субота", 27.3)
            };

            Console.WriteLine("--- Лабораторна робота №6: Лямбди та Делегати (Варіант 7) ---");

            // --- Використання Func<double, bool> (вимога 26) ---
            
            // Func<T, TResult> - метод із результатом
            // Завдання: відбір днів із температурою > 25°C
            Func<double, bool> isAbove25 = temp => temp > 25.0; // Коментар: Func<double, bool> (Лямбда-вираз)

            // Застосування LINQ-операції Where (обробка колекції)
            var hotDays = records
                .Where(r => isAbove25(r.Degrees)) // Фільтрація
                .ToList();
            
            Console.WriteLine("\n[1] Відбір гарячих днів (> 25°C) за допомогою Func<> та LINQ Where:");
            
            // --- Використання Action<double> (вимога 26) ---

            // Action<T> - метод без повернення значення
            // Завдання: відображення результату у форматі "Спекотно: X°С"
            Action<double> displayHotTemp = temp => Console.WriteLine($"Спекотно: {temp}°С"); // Коментар: Action<double> (Лямбда-вираз)

            // Виведення результатів
            foreach (var record in hotDays)
            {
                Console.Write($"\t{record.Day}: ");
                displayHotTemp(record.Degrees); // Виклик делегата Action<>
            }
            
            // --- Використання анонімного методу (вимога 24) ---

            // Використання власного делегата з анонімним методом
            TemperatureCheckDelegate isBelow20 = delegate (double temp) 
            { 
                return temp < 20.0; 
            }; // Коментар: Анонімний метод

            double wednesdayTemp = records.First(r => r.Day == "Середа").Degrees;
            Console.WriteLine("\n[2] Приклад анонімного методу:");
            Console.WriteLine($"\tТемпература у Середу ({wednesdayTemp}°C) нижча за 20°C? {isBelow20(wednesdayTemp)}");
            
            // --- Обчислення середньої температури (LINQ Average, вимога 27) ---
            
            double averageTemp = records.Average(r => r.Degrees);
            Console.WriteLine("\n[3] Обчислення середньої температури (LINQ Average):");
            Console.WriteLine($"\tСередня температура за тиждень: {averageTemp:F2}°C");
            
            Console.WriteLine("------------------------------------------");
        }
    }
}