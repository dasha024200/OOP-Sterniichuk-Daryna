using System;

public class Point2D
{
    private double x;
    private double y;

    public double X
    {
        get => x;
        set
        {
            if (Math.Abs(value) > 1000)
                throw new ArgumentException("X занадто велике за модулем!");
            x = value;
        }
    }

    public double Y
    {
        get => y;
        set
        {
            if (Math.Abs(value) > 1000)
                throw new ArgumentException("Y занадто велике за модулем!");
            y = value;
        }
    }

    public Point2D(double x = 0, double y = 0)
    {
        X = x;
        Y = y;
    }

    public double this[int index]
    {
        get
        {
            if (index == 0) return X;
            if (index == 1) return Y;
            throw new IndexOutOfRangeException("Індекс може бути тільки 0 або 1");
        }
        set
        {
            if (index == 0) X = value;
            else if (index == 1) Y = value;
            else throw new IndexOutOfRangeException("Індекс може бути тільки 0 або 1");
        }
    }

    public static Point2D operator +(Point2D a, Point2D b)
        => new Point2D(a.X + b.X, a.Y + b.Y);

    public static Point2D operator -(Point2D a, Point2D b)
        => new Point2D(a.X - b.X, a.Y - b.Y);

    public static bool operator ==(Point2D a, Point2D b)
        => a.X == b.X && a.Y == b.Y;

    public static bool operator !=(Point2D a, Point2D b)
        => !(a == b);

    public override bool Equals(object obj)
    {
        if (obj is Point2D other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
        => X.GetHashCode() ^ Y.GetHashCode();

    public override string ToString()
        => $"Point({X}, {Y})";
}
