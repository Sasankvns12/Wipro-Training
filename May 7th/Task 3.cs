using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter a Sentence : ");
        string sentence = Console.ReadLine();
        PrintDuplicateWords(sentence);

    }
    public static void PrintDuplicateWords(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
        {
            Console.Write("No Input Providede");
            return;
        }
        string[] words = sentence.Split(new[] { '', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
        var wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
            }
            else
            {
                wordCount[word]] = 1;
            }
        }
        var duplicates = wordCount.Where(pair => pair.Value > 1)
            .Select(pair => pair.Key);
        if (duplicates.Any())
        {
            Console.WriteLine("Duplicate words found : ");
            foreach (string duplicate in duplicates)
            {
                Console.WriteLine(duplicate);
            }
           else
            {
                Console.WriteLine("No duplicate words found ");
            }
        }
    }
}
