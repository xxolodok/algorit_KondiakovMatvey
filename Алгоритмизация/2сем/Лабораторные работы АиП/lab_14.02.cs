using System;
using System;

public interface IShape
{
    double Area();
    double Perimeter();
}
public class BaseShape
{
    public string Name;

    public BaseShape(string name)
    {
        Name = name;
    }
}
public class Circle : BaseShape, IShape
{
    public double Radius;

    public Circle(double radius) : base("Circle")
    {
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Square : BaseShape, IShape
{
    public double a;

    public Square(double sideLength) : base("Square")
    {
        a = sideLength;
    }

    public double Area()
    {
        return a * a;
    }

    public double Perimeter()
    {
        return 4 * a;
    }
}

public class EquilateralTriangle : BaseShape, IShape
{
    public double a;

    public EquilateralTriangle(double sideLength) : base("Equilateral Triangle")
    {
        a = sideLength;
    }

    public double Area()
    {
        return (Math.Sqrt(3) / 4) * a * a;
    }

    public double Perimeter()
    {
        return 3 * a;
    }
}
class Program
{
    static void Main()
    {
        Circle circle = new Circle(5);
        Square square = new Square(4);
        EquilateralTriangle triangle = new EquilateralTriangle(3);

        IShape[] shapes = { circle, square, triangle };

        foreach (IShape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name}:");
            Console.WriteLine($"  Площадь: {shape.Area()}");
            Console.WriteLine($"  Периметр: {shape.Perimeter()}");
        }
    }
}
