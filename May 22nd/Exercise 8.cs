using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 2, 5, 8, 12, 15, 17, 20, 23, 30, 33, 40 };
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
        Console.WriteLine("Original Numbers :");
        Console.WriteLine(string.Join(",", numbers));
        Console.WriteLine("\nEven Numbers :");
        Console.WriteLine(string.Join(",", evenNumbers));
        Console.WriteLine("\nOdd Numbers:");
        Console.WriteLine(string.Join(",", oddNumbers));
    }
}