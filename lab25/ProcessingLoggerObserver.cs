using lab25.Observer;

namespace lab25
{
    public class ProcessingLoggerObserver
    {
        public void Subscribe(DataPublisher publisher)
        {
            publisher.DataProcessed += OnDataProcessed;
        }

        private void OnDataProcessed(string data)
        {
            LoggerManager.Instance.Log($"Processed data: {data}");
        }
    }
}
