using System;
using System.Collections.Generic;
public class Program
{
    public static void Main ()
    {
        List<int> numbers = new List<int>();
        numbers.Add(5);
        numbers.Add(10);
        numbers.Add(15);
        foreach (int num in numbers)
        {
            Console.WriteLine(num);

        }
    }

}