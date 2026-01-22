namespace lab21
{
    public static class StoragePlanFactory
    {
        public static IStoragePlanStrategy CreateStrategy(string planType)
        {
            return planType.ToLower() switch
            {
                "personal" => new PersonalPlan(),
                "business" => new BusinessPlan(),
                "enterprise" => new EnterprisePlan(),
                "archive" => new CloudArchivePlan(),
                _ => throw new ArgumentException("Невідомий тарифний план")
            };
        }
    }
}
