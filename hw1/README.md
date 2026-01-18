# HW1 — SRP та анти-патерн God Object

## 1. Характеристики анти-патерну "God Object"
**God Object (Божественний об’єкт)** — це анти-патерн, коли один клас/модуль бере на себе надто багато обов’язків і стає “центром всесвіту” системи.

Типові характеристики:
- **Занадто багато відповідальностей**: бізнес-логіка, робота з БД, форматування, логування, валідація, робота з файлами тощо в одному класі.
- **Висока зв’язність (coupling)**: клас знає про “все і всіх”, має багато залежностей і викликає купу інших компонентів напряму.
- **Низька когезія (cohesion)**: методи класу мало пов’язані між собою і роблять різні речі.
- **Складність супроводу**: будь-яка зміна ламає щось несподівано, зростає ризик багів.
- **Погана тестованість**: важко написати юніт-тести, бо треба мокати багато залежностей, а логіка змішана.
- **Порушення принципів SOLID** (часто SRP та DIP), дублювання коду та “спагеті-архітектура”.

Наслідок: система стає крихкою, повільно розвивається, а будь-який рефакторинг стає болючим.

---

## 2. Приклад простого класу, який порушує SRP
SRP (Single Responsibility Principle) каже: **клас має мати лише одну причину для змін**.

Нижче приклад класу, який порушує SRP: він і валідує, і рахує знижку, і зберігає в файл, і відправляє email.

```csharp
public class OrderService
{
    public void ProcessOrder(Order order)
    {
        // 1) Валідація
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (order.Items.Count == 0) throw new InvalidOperationException("Order must have items.");

        // 2) Бізнес-логіка (знижки)
        decimal total = 0;
        foreach (var item in order.Items)
            total += item.Price * item.Quantity;

        if (total > 1000)
            total *= 0.9m; // 10% знижка

        order.Total = total;

        // 3) Збереження (I/O)
        File.AppendAllText("orders.txt", $"OrderId={order.Id}, Total={order.Total}\n");

        // 4) Сповіщення (email)
        Console.WriteLine($"Email sent to {order.CustomerEmail}: total = {order.Total}");
    }
}

public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; set; } = "";
    public List<OrderItem> Items { get; set; } = new();
    public decimal Total { get; set; }
}

public class OrderItem
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}