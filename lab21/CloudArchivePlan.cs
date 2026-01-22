namespace lab21
{
    public class CloudArchivePlan : IStoragePlanStrategy
    {
        public decimal CalculateCost(int storageGb, int users)
        {
            return (storageGb * 0.2m) + 30m;
        }
    }
}
