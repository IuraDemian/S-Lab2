using System;
using System.Collections.Generic;

interface IOrder
{
    void CreateOrder(List<Tuple<int, int>> items);
}

class FastFoodOrder : IOrder
{
    public void CreateOrder(List<Tuple<int, int>> items)
    {
        Console.WriteLine("Замовлення фастфуду:");
        foreach (var item in items)
        {
            Console.WriteLine($"Код страви: {item.Item1}, Кiлькiсть: {item.Item2}");
        }
    }
}

class SushiOrder : IOrder
{
    public void CreateOrder(List<Tuple<int, int>> items)
    {
        Console.WriteLine("Замовлення сушi:");
        List<int> codes = new List<int>();
        List<int> quantities = new List<int>();

        foreach (var item in items)
        {
            codes.Add(item.Item1);
            quantities.Add(item.Item2);
        }

        Console.WriteLine("Коди страв: " + string.Join(", ", codes));
        Console.WriteLine("Кiлькостi: " + string.Join(", ", quantities));
    }
}

class TraditionalUkrainianOrder : IOrder
{
    public void CreateOrder(List<Tuple<int, int>> items)
    {
        Console.WriteLine("Замовлення традицiйної української кухнi:");
        List<int> orderList = new List<int>();

        foreach (var item in items)
        {
            for (int i = 0; i < item.Item2; i++)
            {
                orderList.Add(item.Item1);
            }
        }

        Console.WriteLine("Замовленi страви: " + string.Join(", ", orderList));
    }
}

class OrderFactory
{
    public static IOrder GetOrder(string type)
    {
        switch (type.ToLower())
        {
            case "a":
                return new FastFoodOrder();
            case "b":
                return new SushiOrder();
            case "c":
                return new TraditionalUkrainianOrder();
            default:
                throw new ArgumentException("Невiдомий тип замовлення");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберiть тип їжi (a - Фастфуд, b - Сушi, c - Традицiйна українська кухня): ");
        string type = Console.ReadLine();

        List<Tuple<int, int>> items = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(500, 1),
            new Tuple<int, int>(42, 2),
            new Tuple<int, int>(123, 3),
        };

        IOrder order = OrderFactory.GetOrder(type);
        order.CreateOrder(items);
    }
}
