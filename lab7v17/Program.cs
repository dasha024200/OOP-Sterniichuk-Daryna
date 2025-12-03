using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace Lab7
{
    // Клас, що імітує роботу з файлами
    public class FileProcessor
    {
        private int _attempts = 0; // лічильник спроб виклику методу

        // Сценарій: завантаження списку ID замовлень з файлу
        public List<string> LoadOrderIds(string path)
        {
            _attempts++;

            // Перші 2 рази імітуємо IOException
            if (_attempts <= 2)
            {
                throw new IOException($"Тимчасова помилка читання файлу (спроба {_attempts}).");
            }

            // Потім – «успішне» завантаження (можна реально читати файл, але для лаби достатньо імітації)
            Console.WriteLine("Файл успішно прочитано.");
            return new List<string> { "ORDER-001", "ORDER-002", "ORDER-003" };
        }
    }

    // Клас, що імітує мережеві запити
    public class NetworkClient
    {
        private int _attempts = 0; // лічильник спроб виклику методу

        // Сценарій: отримання замовлень з API
        public List<string> GetOrdersFromApi(string url)
        {
            _attempts++;

            // Перші 3 рази імітуємо HttpRequestException
            if (_attempts <= 3)
            {
                throw new HttpRequestException($"Тимчасова помилка HTTP-запиту (спроба {_attempts}).");
            }

            // Потім – «успішна» відповідь
            Console.WriteLine("Дані успішно отримано з API.");
            return new List<string> { "ORDER-101", "ORDER-102", "ORDER-103" };
        }
    }

    // Узагальнений допоміжний клас з патерном Retry
    public static class RetryHelper
    {
        /// <summary>
        /// Виконує операцію з повторними спробами (Retry) та експоненційною затримкою.
        /// </summary>
        public static T ExecuteWithRetry<T>(
            Func<T> operation,
            int retryCount = 3,
            TimeSpan initialDelay = default,
            Func<Exception, bool> shouldRetry = null)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            // Якщо користувач не передав initialDelay – задаємо дефолт, напр. 500 мс
            if (initialDelay == default)
            {
                initialDelay = TimeSpan.FromMilliseconds(500);
            }

            for (int attempt = 1; attempt <= retryCount; attempt++)
            {
                try
                {
                    // Пробуємо виконати операцію
                    return operation();
                }
                catch (Exception ex)
                {
                    // Якщо є делегат shouldRetry і він каже "НЕ ретраїмо" – одразу проброс винятку
                    if (shouldRetry != null && !shouldRetry(ex))
                    {
                        Console.WriteLine($"Помилка не підлягає повтору: {ex.GetType().Name} - {ex.Message}");
                        throw;
                    }

                    // Якщо це остання спроба – теж проброс винятку
                    if (attempt == retryCount)
                    {
                        Console.WriteLine($"Досягнуто максимальну кількість спроб ({retryCount}).");
                        throw;
                    }

                    // Логування спроби
                    Console.WriteLine(
                        $"Спроба {attempt} не вдалася. Тип помилки: {ex.GetType().Name}. " +
                        $"Повідомлення: {ex.Message}");

                    // Експоненційна затримка: initialDelay * 2^(attempt-1)
                    double factor = Math.Pow(2, attempt - 1);
                    var delay = TimeSpan.FromMilliseconds(initialDelay.TotalMilliseconds * factor);

                    Console.WriteLine($"Очікування перед наступною спробою: {delay.TotalMilliseconds} мс.\n");
                    Thread.Sleep(delay);
                }
            }

            // Сюди ми практично не дійдемо, але компілятор цього хоче :)
            throw new InvalidOperationException("Неможливо виконати операцію з повторними спробами.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var fileProcessor = new FileProcessor();
            var networkClient = new NetworkClient();

            // Делегат, який визначає, ЧИ варто повторювати спробу для конкретного винятку
            Func<Exception, bool> shouldRetry = ex =>
                ex is IOException || ex is HttpRequestException;

            Console.WriteLine("=== Сценарій 1: Читання списку замовлень з файлу (FileProcessor) ===\n");

            try
            {
                var fileOrders = RetryHelper.ExecuteWithRetry(
                    operation: () => fileProcessor.LoadOrderIds("orders.txt"),
                    retryCount: 5,
                    initialDelay: TimeSpan.FromMilliseconds(500),
                    shouldRetry: shouldRetry
                );

                Console.WriteLine("Отримані замовлення з файлу:");
                foreach (var id in fileOrders)
                {
                    Console.WriteLine($" - {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Фатальна помилка при роботі з файлом: {ex.Message}");
            }

            Console.WriteLine("\n=== Сценарій 2: Отримання списку замовлень з API (NetworkClient) ===\n");

            try
            {
                var apiOrders = RetryHelper.ExecuteWithRetry(
                    operation: () => networkClient.GetOrdersFromApi("https://api.example.com/orders"),
                    retryCount: 5,
                    initialDelay: TimeSpan.FromMilliseconds(500),
                    shouldRetry: shouldRetry
                );

                Console.WriteLine("Отримані замовлення з API:");
                foreach (var id in apiOrders)
                {
                    Console.WriteLine($" - {id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Фатальна помилка при мережевому запиті: {ex.Message}");
            }

            Console.WriteLine("\nРоботу програми завершено. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}
