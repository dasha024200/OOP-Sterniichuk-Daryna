namespace lab21
{
    public class CloudStorageService
    {
        private readonly IStoragePlanStrategy _strategy;

        public CloudStorageService(IStoragePlanStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(int storageGb, int users)
        {
            return _strategy.CalculateCost(storageGb, users);
        }
    }
}
