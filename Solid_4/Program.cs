using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/


interface IPrice
{
    void SetPrice(double price);
}

interface IDiscount
{
    void ApplyDiscount(string discount);
}

interface IPromocode
{
    void ApplyPromocode(string promocode);
}

interface IColor
{
    void SetColor(byte color);
}

interface ISize
{
    void SetSize(byte size);
}


class Book : IPrice, IDiscount
{
    public double Price { get; private set; }

    public void SetPrice(double price)
    {
        if (double.IsNaN(price) ||
            double.IsInfinity(price) ||
            price < 0)
        {
            throw new ArgumentException(
                "Ціна має бути скінченним невід'ємним числом."
            );
        }

        Price = price;
    }

    public void ApplyDiscount(string discount)
    {
        double percent = double.Parse(discount);

        if (double.IsNaN(percent) || percent < 0 || percent > 100)
        {
            throw new ArgumentException(
                "Знижка має бути числом від 0 до 100."
            );
        }

        Price -= Price * percent / 100;
    }
}

class Outerwear : IPrice, IDiscount, IColor, ISize
{
    public double Price { get; private set; }
    public byte Color { get; private set; }
    public byte Size { get; private set; }

    public void SetPrice(double price)
    {
        if (double.IsNaN(price) ||
            double.IsInfinity(price) ||
            price < 0)
        {
            throw new ArgumentException(
                "Ціна має бути скінченним невід'ємним числом."
            );
        }

        Price = price;
    }

    public void ApplyDiscount(string discount)
    {
        double percent = double.Parse(discount);

        if (double.IsNaN(percent) || percent < 0 || percent > 100)
        {
            throw new ArgumentException(
                "Знижка має бути числом від 0 до 100."
            );
        }

        Price -= Price * percent / 100;
    }

    public void SetColor(byte color)
    {
        Color = color;
    }

    public void SetSize(byte size)
    {
        Size = size;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();

        book.SetPrice(500);
        book.ApplyDiscount("10");

        Console.WriteLine(
            "Ціна книжки після знижки: " + book.Price
        );

        Outerwear coat = new Outerwear();

        coat.SetPrice(2000);
        coat.ApplyDiscount("20");
        coat.SetColor(1);
        coat.SetSize(42);

        Console.WriteLine(
            "Ціна верхнього одягу після знижки: " + coat.Price
        );

        Console.WriteLine("Код кольору: " + coat.Color);
        Console.WriteLine("Розмір: " + coat.Size);

        Console.ReadKey();
    }
}