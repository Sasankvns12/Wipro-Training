using System;
using System.Linq;
class Program
{
    static void Main()
    {
        string sentence = "C# is great and C# is fun";
        string[] words = sentence.Split(' ');
        var wordCounts = words.GroupBy(word => word).Select(group => new { Word = group.Key, Count = group.Count() });
        Console.WriteLine("Word Counts :");
        foreach(var item in wordCounts)
        {
            Console.WriteLine($"{item.Word} : {item.Count}");
        }
    }
}