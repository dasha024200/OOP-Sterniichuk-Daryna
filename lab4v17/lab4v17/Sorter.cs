namespace Lab4v17
{
    // Клас-композиція, який використовує стратегію сортування
    public class Sorter
    {
        private ISortStrategy _strategy;

        // Передаємо обрану реалізацію через конструктор
        public Sorter(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        // Виконуємо сортування через інтерфейс
        public int[] Execute(int[] array)
        {
            return _strategy.Sort(array);
        }
    }
}
