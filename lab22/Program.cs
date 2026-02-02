using System;
using System.Collections.Generic;

namespace lab22
{
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea() => Width * Height;
    }

    class Square : Rectangle
    {
        public override int Width
        {
            get => base.Width;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            get => base.Height;
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }

    class LspDemo
    {
        public static void ResizeRectangle(Rectangle rect)
        {
            rect.Width = 5;
            rect.Height = 10;

            Console.WriteLine("Демонстрація порушення LSP");
            Console.WriteLine("Очікувана площа: 50");
            Console.WriteLine($"Фактична площа: {rect.GetArea()}");
            Console.WriteLine();
        }
    }

    interface IShape
    {
        int GetArea();
    }

    class RectangleFixed : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea() => Width * Height;
    }

    class SquareFixed : IShape
    {
        public int Side { get; set; }

        public int GetArea() => Side * Side;
    }

    class Program
    {
        static void PrintArea(IShape shape)
        {
            Console.WriteLine($"Площа фігури: {shape.GetArea()}");
        }

        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            LspDemo.ResizeRectangle(rectangle);

            Rectangle squareAsRectangle = new Square();
            LspDemo.ResizeRectangle(squareAsRectangle);

            Console.WriteLine("Альтернативне рішення (LSP дотримано)");
            IShape rect = new RectangleFixed { Width = 5, Height = 10 };
            IShape sq = new SquareFixed { Side = 5 };

            PrintArea(rect);
            PrintArea(sq);

            Console.WriteLine("\nDone.");
        }
    }
}
