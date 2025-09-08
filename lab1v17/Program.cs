using System;
using Lab1v17;

public class Figure
{
    private double _width;
    private double _height;
    public static int InstanceCount { get; private set; }
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
    public Figure(string name, double width, double height)
    {
        Name = name;
        Width = width;
        Height = height;
        InstanceCount++;
    }
    ~Figure()
    {
        
    }

    public void Scale(double factor)
    {
        if (factor <= 0) throw new ArgumentException("Scale factor must be > 0");
        Width *= factor;
        Height *= factor;
    }

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

        var a = new Figure("A", 3, 4);
        var b = new Figure("B", 5, 2.5);
        var c = new Figure("C", 10, 1.2);

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine($"\nInstances: {Figure.InstanceCount}\n");

        a.Scale(2);
        c.Scale(0.5);

        Console.WriteLine("After scaling:");
        Console.WriteLine(a);
        Console.WriteLine(c);

        try
        {
            b.Width = -1;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\nValidation error: {ex.Message}");
        }
 Console.WriteLine("\n=== Lab1v17: Course demo ===\n");
        var course = new Course("Програмування", "Проф. Іваненко", 3);
        Console.WriteLine(course);
        course.EnrollStudent("Студент Петренко");

        Console.WriteLine("\n=== Done ===");
    }
}
