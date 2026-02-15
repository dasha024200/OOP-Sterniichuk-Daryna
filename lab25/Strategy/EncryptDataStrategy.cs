using System.Text;

namespace lab25.Strategy
{
    public class EncryptDataStrategy : IDataProcessorStrategy
    {
        public string Process(string data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        }
    }
}
