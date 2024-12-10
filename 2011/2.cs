using System;
using System.Collections.Generic;

public class Backpack
{
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Fabric { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public List<(string Name, double Volume)> Contents { get; private set; } = new();

    public event Action<string> ItemAdded;

    public void AddItem(string name, double volume)
    {
        double currentVolume = CalculateCurrentVolume();
        if (currentVolume + volume > Volume)
        {
            throw new InvalidOperationException("Cannot add item. Volume limit exceeded.");
        }

        Contents.Add((name, volume));
        ItemAdded?.Invoke(name);
    }

    public double CalculateCurrentVolume()
    {
        double totalVolume = 0;
        foreach (var item in Contents)
        {
            totalVolume += item.Volume;
        }
        return totalVolume;
    }
}

class Program
{
    static void Main()
    {
        var backpack = new Backpack
        {
            Color = "Black",
            Brand = "Nike",
            Fabric = "Polyester",
            Weight = 1.5,
            Volume = 20
        };

        backpack.ItemAdded += item => Console.WriteLine($"Item added: {item}");

        try
        {
            backpack.AddItem("Water Bottle", 2);
            backpack.AddItem("Laptop", 5);
            backpack.AddItem("Books", 15);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}