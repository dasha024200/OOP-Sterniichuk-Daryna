using lab25.Factory;
using lab25.Logger;

namespace lab25
{
    public class LoggerManager
    {
        private static LoggerManager? _instance;
        private LoggerFactory _factory;
        private ILogger _logger;

        private LoggerManager(LoggerFactory factory)
        {
            _factory = factory;
            _logger = factory.CreateLogger();
        }

        public static LoggerManager Initialize(LoggerFactory factory)
        {
            _instance = new LoggerManager(factory);
            return _instance;
        }

        public static LoggerManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("LoggerManager not initialized");
                return _instance;
            }
        }

        public void ChangeFactory(LoggerFactory factory)
        {
            _factory = factory;
            _logger = factory.CreateLogger();
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
