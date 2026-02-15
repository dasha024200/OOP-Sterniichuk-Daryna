using lab24.Strategies;
using lab24.Processor;
using lab24.Observer;

class Program
{
    static void Main()
    {
        var squareStrategy = new SquareOperationStrategy();
        var cubeStrategy = new CubeOperationStrategy();
        var sqrtStrategy = new SquareRootOperationStrategy();

        var processor = new NumericProcessor(squareStrategy);
        var publisher = new ResultPublisher();

        var consoleObserver = new ConsoleLoggerObserver();
        var historyObserver = new HistoryLoggerObserver();
        var thresholdObserver = new ThresholdNotifierObserver(20);

        consoleObserver.Subscribe(publisher);
        historyObserver.Subscribe(publisher);
        thresholdObserver.Subscribe(publisher);

        double[] numbers = { 4, 9, 16 };

        foreach (var number in numbers)
        {
            double result = processor.Process(number);
            publisher.PublishResult(result, processor.GetCurrentOperationName());
        }

        processor.SetStrategy(cubeStrategy);

        foreach (var number in numbers)
        {
            double result = processor.Process(number);
            publisher.PublishResult(result, processor.GetCurrentOperationName());
        }

        processor.SetStrategy(sqrtStrategy);

        foreach (var number in numbers)
        {
            double result = processor.Process(number);
            publisher.PublishResult(result, processor.GetCurrentOperationName());
        }

        Console.WriteLine("\nHistory:");
        historyObserver.PrintHistory();
    }
}
