using System;

namespace lab21
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Оберіть тариф: Personal / Business / Enterprise / Archive");
            string plan = Console.ReadLine();

            Console.Write("Введіть обсяг сховища (ГБ): ");
            int storage = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість користувачів: ");
            int users = int.Parse(Console.ReadLine());

            try
            {
                var strategy = StoragePlanFactory.CreateStrategy(plan);
                var service = new CloudStorageService(strategy);

                decimal cost = service.Calculate(storage, users);

                Console.WriteLine($"Вартість хмарного сховища: {cost} грн");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
