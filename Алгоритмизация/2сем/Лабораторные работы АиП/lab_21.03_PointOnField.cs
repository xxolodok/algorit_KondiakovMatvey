using System;
delegate void OutOfBoundsDelegate();

class Program
{
    static void OutOfBoundsConsole()
    {
        Console.WriteLine($"Точка покинула поле");
    }
    static void Main()
    {
        var point = new Point(2, 10);
        var field = new Field(0, 0, 20, 20);
        var r = new Random();

        point.OutOfBounds += OutOfBoundsConsole;
        while (!point.isOutOfBounds)
        {
            int deltaX = r.Next(-2, 3);
            int deltaY = r.Next(-2, 3);

            point.Move(deltaX, deltaY, field);
        }

    }
}
class Point
{
    public int X;
    public int Y;
    public bool isOutOfBounds;

    public event OutOfBoundsDelegate OutOfBounds;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
        isOutOfBounds = false;
    }

    public void Move(int deltaX, int deltaY, Field field)
    {
        X = X + deltaX;
        Y = Y + deltaY;

        if (X < field.minX || Y < field.minY || X > field.maxX || Y > field.maxY)
        {
            if (OutOfBounds != null) OutOfBounds();
            Console.WriteLine($"{X}, {Y}");
            isOutOfBounds = true;
        }
        else
        {
            Console.WriteLine($"{X}, {Y}");
        }
    }
}

class Field
{
    public int minX;
    public int minY;
    public int maxX;
    public int maxY;

    public Field(int minx, int miny, int maxx, int maxy)
    {
        minX = minx;
        minY = miny;
        maxX = maxx;
        maxY = maxy;
    }
}