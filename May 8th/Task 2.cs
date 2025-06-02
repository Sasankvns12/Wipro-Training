using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        List<string> fruits = new List<string>() { "Apple", "Banana", "Cherry" };
        fruits.Add("Mango");
        fruits.Insert(1, "Orange");
        fruits.Remove("Banana");
        fruits.RemoveAt(2);
        if (fruits.Contains("Apple"))
        {
            Console.WriteLine("Apple is in the list");
            fruits.Sort();
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}
       