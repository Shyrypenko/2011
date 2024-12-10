using System;

class Program
{
    static void Main()
    {
        Func<int[], int> countPositive = numbers => Array.FindAll(numbers, n => n > 0).Length;

        int[] numbers = { -5, 3, 0, 7, -2, 10, -1 };
        Console.WriteLine($"Number of positive integers: {countPositive(numbers)}");
    }
}