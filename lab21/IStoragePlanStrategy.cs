namespace lab21
{
    public interface IStoragePlanStrategy
    {
        decimal CalculateCost(int storageGb, int users);
    }
}
