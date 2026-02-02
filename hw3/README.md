ISP та DIP: як вони роблять код гнучким і тестованим
1) Принцип ISP (Interface Segregation Principle)

ISP говорить: клієнти не повинні залежати від методів, які вони не використовують.
Тобто краще мати кілька “вузьких” інтерфейсів, ніж один “товстий”, який змушує класи реалізовувати зайві методи.

Приклад інтерфейсу, що порушує ISP

Уявімо інтерфейс для багатофункціонального пристрою:

public interface IMultiFunctionDevice
{
    void Print(string text);
    void Scan(string path);
    void Fax(string number);
}


Проблема: якщо в нас є клас звичайного принтера, йому доведеться реалізувати Scan() і Fax() навіть якщо він цього не вміє. Найчастіше це закінчується NotImplementedException, зайвим кодом і “фальшивими” можливостями.

public class SimplePrinter : IMultiFunctionDevice
{
    public void Print(string text) { /* ok */ }

    public void Scan(string path) =
        throw new NotImplementedException();

    public void Fax(string number) =
        throw new NotImplementedException();
}


Це і є порушення ISP: клас змушений залежати від непотрібних методів.

Вирішення проблеми (розділення на “вузькі” інтерфейси)

Розділяємо інтерфейс на менші:

public interface IPrinter
{
    void Print(string text);
}

public interface IScanner
{
    void Scan(string path);
}

public interface IFax
{
    void Fax(string number);
}


Тепер кожен клас реалізує тільки те, що реально підтримує:

public class SimplePrinter : IPrinter
{
    public void Print(string text) { /* ok */ }
}


А якщо є "комбайн" — він реалізує всі потрібні інтерфейси:

public class OfficeMfd : IPrinter, IScanner, IFax
{
    public void Print(string text) { /* ... */ }
    public void Scan(string path) { /* ... */ }
    public void Fax(string number) { /* ... */ }
}

2) Принцип DIP (Dependency Inversion Principle)

DIP говорить:

Модулі високого рівня не повинні залежати від модулів низького рівня.

Обидва повинні залежати від абстракцій (інтерфейсів).

Абстракції не повинні залежати від деталей, деталі залежать від абстракцій.

Простими словами: бізнес-логіка має знати не про “конкретний клас EmailSender”, а про "інтерфейс INotificationSender".

Порушення DIP (залежність від конкретного класу)
public class EmailSender
{
    public void Send(string to, string message) { /* ... */ }
}

public class OrderService
{
    private readonly EmailSender _sender = new EmailSender(); // погано

    public void PlaceOrder()
    {
        // ...
        _sender.Send("user@mail.com", "Order placed");
    }
}


Мінуси:

важко замінити email на sms/telegram;

важко тестувати (під час тесту реально “відправлятиме” листи або треба мокати дуже костильно);

сильна зв’язаність.

Переваги DIP через Dependency Injection (DI)

Робимо залежність через інтерфейс і передаємо її ззовні (DI):

public interface INotificationSender
{
    void Send(string to, string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string to, string message) { /* ... */ }
}

public class OrderService
{
    private readonly INotificationSender _sender;

    // DI через конструктор
    public OrderService(INotificationSender sender)
    {
        _sender = sender;
    }

    public void PlaceOrder()
    {
        // ...
        _sender.Send("user@mail.com", "Order placed");
    }
}


Переваги DI (і DIP):

Легка заміна реалізації: EmailSender → SmsSender → TelegramSender без зміни бізнес-логіки.

Краще тестування: можна передати фейкову/мок реалізацію.

Менше зв’язаності: сервіс залежить від контракту (інтерфейсу), а не деталей.

Код гнучкіший: простіше підтримка і розширення.

Приклад для тесту (фейк):

public class FakeSender : INotificationSender
{
    public List<(string to, string message)> Sent = new();

    public void Send(string to, string message)
        => Sent.Add((to, message));
}

3) Як “вузькі” інтерфейси (ISP) покращують DI та тестування

Коли інтерфейси маленькі й точні, DI стає простішим:

Менше зайвих залежностей: класу не треба “впихати” один гігантський сервіс, з якого він використовує 1 метод.

Легше мокати/фейкати: мок на 2 методи зробити легко, а на 20 — складно і шумно.

Менше причин ламати код: зміна в одному “широкому” інтерфейсі змусить переробляти багато класів; з “вузькими” — зміна локальна.

Краще розділення відповідальностей: тест простіший, бо залежності точні й прозорі.

Висновок:
ISP робить абстракції “чистими” і компактними, а DIP + DI дозволяють підключати потрібні реалізації без прив’язки до деталей. Разом вони дають гнучкий, розширюваний і тестований код.