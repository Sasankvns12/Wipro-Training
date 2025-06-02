using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class TextAnalyzer
{
    static void Main()
    {
        Console.WriteLine("Enter a paragraph:");
        string paragraph = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(paragraph))
        {
            Console.WriteLine("No input provided.");
            return;
        }

        // Word frequency analysis
        var wordFrequency = GetWordFrequency(paragraph);
        Console.WriteLine("\nWord Frequency:");
        foreach (var pair in wordFrequency.OrderByDescending(p => p.Value))
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        // Vowel and consonant count
        var (vowelCount, consonantCount) = CountVowelsAndConsonants(paragraph);
        Console.WriteLine($"\nVowels: {vowelCount}");
        Console.WriteLine($"Consonants: {consonantCount}");

        // Longest and shortest word
        var words = GetWords(paragraph);
        if (words.Any())
        {
            var longestWord = words.OrderByDescending(w => w.Length).First();
            var shortestWord = words.OrderBy(w => w.Length).First();
            Console.WriteLine($"\nLongest word: {longestWord} ({longestWord.Length} letters)");
            Console.WriteLine($"Shortest word: {shortestWord} ({shortestWord.Length} letters)");
        }
    }

    static Dictionary<string, int> GetWordFrequency(string text)
    {
        var words = GetWords(text);
        var frequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var word in words)
        {
            if (frequency.ContainsKey(word))
                frequency[word]++;
            else
                frequency[word] = 1;
        }

        return frequency;
    }

    static (int vowels, int consonants) CountVowelsAndConsonants(string text)
    {
        int vowels = 0, consonants = 0;
        var letters = text.Where(char.IsLetter).Select(char.ToLower);

        foreach (char c in letters)
        {
            if ("aeiou".Contains(c))
                vowels++;
            else
                consonants++;
        }

        return (vowels, consonants);
    }

    static List<string> GetWords(string text)
    {
        // Split into words, removing punctuation and empty entries
        return Regex.Split(text, @"\W+")
                   .Where(w => !string.IsNullOrEmpty(w))
                   .ToList();
    }
}