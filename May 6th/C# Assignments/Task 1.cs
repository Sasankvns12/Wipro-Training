using System;
class Program {
    static int CountWords(string sentence)
    {
        int count = 1;

        foreach(char character in sentence)
        {
            if (character == ' ') {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        string sentence = "Learning C# is fun";
        Console.WriteLine("Number of words : " + CountWords(sentence));
    }
}