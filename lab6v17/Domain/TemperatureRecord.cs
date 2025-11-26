// Domain/TemperatureRecord.cs

namespace lab6v17.Domain
{
    public class TemperatureRecord
    {
        public string Day { get; set; }
        public double Degrees { get; set; }

        public TemperatureRecord(string day, double degrees)
        {
            Day = day;
            Degrees = degrees;
        }
    }
}