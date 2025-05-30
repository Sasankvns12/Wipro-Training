using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 2, 5, 8, 5, 12, 8, 15, 2, 20, 5, 12 };
        Console.WriteLine("Original Numbers :");
        Console.WriteLine(string.Join(",", numbers));
        var duplicates = numbers.GroupBy(n => n).Where(g => g.Count() > 1).Select(g => g.Key);
        Console.WriteLine("\nDuplicate Numbers :");
        foreach (var number in duplicates)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine("\nDuplicates with Counts :");
        var duplicatesWithCounts = numbers.GroupBy(n => n).Where(g => g.Count() > 1).Select(g => new { Number = g.Key, Count = g.Count()});
        foreach (var item in duplicatesWithCounts)
        {
            Console.WriteLine($"{item.Number} appears {item.Count} times");
        }
    }
}