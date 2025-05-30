using System;
public class Program
{
    public static void Main()
    {
        string line = "Learning C# is really interesting";
        string[] words = line.Split(new[] { " " }, StringSplitOptions.None);
        string word = " ";
        int ctr = 0;
        foreach(String s in words)
        {
            if(s.Length > ctr)
            {
                word = s;
                ctr = s.Length;
            }
        }
        Console.WriteLine(word);
    }
}
