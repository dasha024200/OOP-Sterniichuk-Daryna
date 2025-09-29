using System;

class Program
{
    static void Main()
    {
        Point2D p1 = new Point2D(3, 4);
        Point2D p2 = new Point2D(1, 2);

        Console.WriteLine("Об'єкти:");
        Console.WriteLine("p1 = " + p1);
        Console.WriteLine("p2 = " + p2);

        Console.WriteLine("\nДоступ через властивості:");
        Console.WriteLine("X p1 = " + p1.X);
        Console.WriteLine("Y p1 = " + p1.Y);

        p1.X = 10;
        p1.Y = 20;
        Console.WriteLine("Оновлений p1 = " + p1);

        Console.WriteLine("\nВикористання індексатора:");
        Console.WriteLine("p2[0] = " + p2[0]);
        Console.WriteLine("p2[1] = " + p2[1]); 

        p2[0] = 5;  
        p2[1] = 6;  
        Console.WriteLine("Оновлений p2 = " + p2);

        Console.WriteLine("\nОператори:");
        Point2D sum = p1 + p2;
        Point2D diff = p1 - p2;

        Console.WriteLine("p1 + p2 = " + sum);
        Console.WriteLine("p1 - p2 = " + diff);
        Console.WriteLine("p1 == p2 ? " + (p1 == p2));
        Console.WriteLine("p1 != p2 ? " + (p1 != p2));
    }
}
