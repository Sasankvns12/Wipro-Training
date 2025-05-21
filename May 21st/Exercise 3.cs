using System;
using System.Collections.Generic;
class FirstUniqChar
{
    public static char? FindFirstUniqChar(string input)
    {
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        foreach(char c in input)
        {
            if(charCounts.ContainsKey(c))
            {
                charCounts[c]++;
            }
            else
            {
                charCounts[c] = 1;
            }
        }
        foreach(char c in input)
        {
            if (charCounts[c] == 1)
            {
                return c;
            }
        }
        return null;

    }
    static void Main()
    {
        string test = "swiss";
        char? result = FindFirstUniqChar(test);
        Console.WriteLine($"Input : \"{test}\"");
        Console.WriteLine(result.HasValue ? $"First Unique Character : '{result.Value}'" : "No unique characters found");
    }
}
