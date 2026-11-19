using System;

interface IShape
{
    int GetArea();
}

class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

// Квадрат має одну довжину сторони.
class Square : IShape
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IShape rectangle = new Rectangle
        {
            Width = 5,
            Height = 10
        };

        IShape square = new Square
        {
            Side = 10
        };

        Console.WriteLine(
            "Площа прямокутника: " + rectangle.GetArea()
        );

        Console.WriteLine(
            "Площа квадрата: " + square.GetArea()
        );

        Console.ReadKey();
    }
}