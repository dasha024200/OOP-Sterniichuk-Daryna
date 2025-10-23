using System;
using System.Linq;

namespace Lab4v17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Початковий масив (заданий у коді)
            int[] data = { 5, 2, 9, 1, 7, 3 };

            Console.WriteLine("Початковий масив: " + string.Join(", ", data));

            // ---- Сортування за зростанням ----
            var ascending = new Sorter(new SortAscending());
            var ascResult = ascending.Execute((int[])data.Clone());

            Console.WriteLine("\n---- Сортування за зростанням ----");
            Console.WriteLine("Результат: " + string.Join(", ", ascResult));
            Console.WriteLine($"Мінімальне значення: {ascResult.Min()}");
            Console.WriteLine($"Максимальне значення: {ascResult.Max()}");
            Console.WriteLine($"Середнє значення: {ascResult.Average():F2}");

            // ---- Сортування за спаданням ----
            var descending = new Sorter(new SortDescending());
            var descResult = descending.Execute((int[])data.Clone());

            Console.WriteLine("\n---- Сортування за спаданням ----");
            Console.WriteLine("Результат: " + string.Join(", ", descResult));
            Console.WriteLine($"Мінімальне значення: {descResult.Min()}");
            Console.WriteLine($"Максимальне значення: {descResult.Max()}");
            Console.WriteLine($"Середнє значення: {descResult.Average():F2}");
        }
    }
}
