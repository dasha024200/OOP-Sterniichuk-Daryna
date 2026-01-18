class Program
{
    static void Main()
    {
        // Dependencies
        IOrderValidator validator = new OrderValidator();
        IOrderRepository repository = new InMemoryOrderRepository();
        IEmailService emailService = new ConsoleEmailService();

        OrderService orderService = new OrderService(
            validator,
            repository,
            emailService
        );

        // Valid order
        Order validOrder = new Order(1, "Darina", 500);
        orderService.ProcessOrder(validOrder);

        Console.WriteLine();

        // Invalid order
        Order invalidOrder = new Order(2, "Test", -100);
        orderService.ProcessOrder(invalidOrder);
    }
}
