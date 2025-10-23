namespace Lab4v17
{
    // Реалізація стратегії сортування за спаданням
    public class SortDescending : ISortStrategy
    {
        public int[] Sort(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
            return array;
        }
    }
}
