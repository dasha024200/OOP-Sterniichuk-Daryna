using System.IO;

namespace lab25.Logger
{
    public class FileLogger : ILogger
    {
        private string _path = "log.txt";

        public void Log(string message)
        {
            File.AppendAllText(_path, $"[File] {message}\n");
        }
    }
}
