using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
class Program
{
    public static void Main()
    {
        ArrayList numbers = new ArrayList();
        Random random = new Random();
        for(int i = 0; i <=10; i++)
        {
            numbers.Add(random.Next(1, 51));
        }
        numbers.Sort();
        int max = (int)numbers[numbers.Count - 1];
        int min = (int)numbers[0];
        Console.WriteLine("Sorted numbers : " + string.Join(" ,", numbers.ToArray()));
        Console.WriteLine("Maximum numbers : " + max);
        Console.WriteLine("Minimum numbers : " + min);
        double sum = 0;
        foreach(int num in numbers)
        {
            sum += num;
        }
        double average = sum / numbers.Count;
        Console.WriteLine("Average : " + average);


    }
}