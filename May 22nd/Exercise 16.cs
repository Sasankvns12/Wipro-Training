using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        var names = new List<string>
        {
            "Emma", "Olivia", "Ava", "Isabella", "Sophia",
            "Ethan", "Noah", "Liam", "Oliver", "Elijah"
        };

        var vowelNames = names.Where(n => "AEIOU".Contains(char.ToUpper(n[0]))).OrderByDescending(n => n).GroupBy(n => n[0]).Select(g => new
        {
            Vowel = g.Key,
            Names = g.ToList(),
            Count = g.Count()});
        Console.WriteLine("Names starting with vowels :");
        foreach(var group in vowelNames)
        {
            Console.WriteLine($"\nVowel '{group.Vowel}':");
            Console.WriteLine($"Count : {group.Count}");
            Console.WriteLine($"Names : {string.Join(",", group.Names)}");
        }
    }
}