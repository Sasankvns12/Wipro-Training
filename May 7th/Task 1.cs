using System;
using System.Collections.Generic;
public class FrequencyCounter
{
    public static void Main(string[] args)
    {
        int[] array = { 1, 2, 2, 3, 4, 4, 4 };
        Dictionary <int, int> FrequencyMap = new Dictionary<int, int>();
        foreach (int number in array)
        {
            if (FrequencyMap . ContainsKey(number))
            {
                FrequencyMap[number] ++;
            }
            else
            {
                FrequencyMap[number] =1;
            }
        }
        foreach(KeyValuePair <int, int> Pair in FrequencyMap)
        {
            Console.WriteLine($"{Pair.Key} appears {Pair.Value} times");
        }
    }
}
