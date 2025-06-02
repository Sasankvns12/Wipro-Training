using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a paragraph :");
        string paragraph = Console.ReadLine();
        string[] words = paragraph.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?', ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (string word in words)
        {
            string cleanedWord = word.Trim().ToLower();
            if (wordCounts.ContainsKey(cleanedWord))
            {
                wordCounts[cleanedWord]++;
            }
            else
            {
                wordCounts[cleanedWord] = 1;
            }
        }
        var topWords = wordCounts.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key).Take(5);
        Console.WriteLine("\nTop 5 most frequency words :");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Word\t\tCount");
        Console.WriteLine("----------------------------");
        foreach(var word in topWords)
        {
            Console.WriteLine($"{word.Key,-15}\t{word.Value}");
        }
    }
}