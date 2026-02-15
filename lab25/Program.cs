using lab25.Factory;
using lab25.Observer;
using lab25.Strategy;
using lab25;

class Program
{
    static void Main()
    {
        Console.WriteLine("===== SCENARIO 1: FULL INTEGRATION =====");

        LoggerManager.Initialize(new ConsoleLoggerFactory());

        var context = new DataContext(new EncryptDataStrategy());
        var publisher = new DataPublisher();
        var observer = new ProcessingLoggerObserver();

        observer.Subscribe(publisher);

        string result = context.Execute("Hello World");
        publisher.PublishDataProcessed(result);

        Console.WriteLine("\n===== SCENARIO 2: CHANGE LOGGER =====");

        LoggerManager.Instance.ChangeFactory(new FileLoggerFactory());

        result = context.Execute("Second Data");
        publisher.PublishDataProcessed(result);

        Console.WriteLine("Check log.txt file for file logging.");

        Console.WriteLine("\n===== SCENARIO 3: CHANGE STRATEGY =====");

        context.SetStrategy(new CompressDataStrategy());

        result = context.Execute("Third Data");
        publisher.PublishDataProcessed(result);
    }
}
