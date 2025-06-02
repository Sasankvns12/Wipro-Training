using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 5, 2, 8, 2, 5, 1, 3, 7, 3, 8 };
        Console.WriteLine("Original numbers : " + string.Join(" ,", numbers));
        HashSet<int> uniquenumbers = new HashSet<int> (numbers);
        Console.WriteLine("Unique numbers : " + string.Join(" ,", uniquenumbers));
        int uniqueCount = uniquenumbers.Count;
        Console.WriteLine("Numbers of Unique elements : " + uniqueCount);
    }
}