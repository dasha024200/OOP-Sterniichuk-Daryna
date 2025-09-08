using System;

public class Figure
{
    // Приватні поля
    private double _width;
    private double _height;

    // Статичний лічильник створених об'єктів
    public static int InstanceCount { get; private set; }

    // Властивості
    public string Name { get; set; }
    public double Width
    {
        get => _width;
        set
        {
            if (value <= 0) throw new ArgumentException("Width must be > 0");
            _width = value;
        }
    }
    public double Height
    {
        get => _height;
        set
        {
            if (value <= 0) throw new ArgumentException("Height must be > 0");
            _height = value;
        }
    }

    // Конструктор
    public Figure(string name, double width, double height)
    {
        Name = name;
        Width = width;
        Height = height;
        InstanceCount++;
    }

    // Деструктор (фіналізатор)
    ~Figure()
    {
        // У цьому прикладі він нічого не робить, але присутній для виконання вимоги.
    }

    // Метод масштабування
    public void Scale(double factor)
    {
        if (factor <= 0) throw new ArgumentException("Scale factor must be > 0");
        Width *= factor;
        Height *= factor;
    }

    // Обчислення площі та периметру
    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);

    public override string ToString() =>
        $"{Name}: {Width} x {Height}, S={Area():0.##}, P={Perimeter():0.##}";
}

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Lab1v17: Figure demo ===\n");

        // Створення об'єктів
        var a = new Figure("A", 3, 4);
        var b = new Figure("B", 5, 2.5);
        var c = new Figure("C", 10, 1.2);

        // Виведення початкових характеристик
        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine($"\nInstances: {Figure.InstanceCount}\n");

        // Масштабування деяких фігур
        a.Scale(2);
        c.Scale(0.5);

        // Вивід після змін
        Console.WriteLine("After scaling:");
        Console.WriteLine(a);
        Console.WriteLine(c);

        // Приклад помилки валідації
        try
        {
            b.Width = -1; // спричинить ArgumentException
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\nValidation error: {ex.Message}");
        }

        Console.WriteLine("\n=== Done ===");
    }
}
