namespace Lab4v17
{
    // Реалізація стратегії сортування за зростанням
    public class SortAscending : ISortStrategy
    {
        public int[] Sort(int[] array)
        {
            Array.Sort(array);
            return array;
        }
    }
}
