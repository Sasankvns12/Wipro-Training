using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Queue<string> customers = new Queue<string>();
        customers.Enqueue("Rajesh");
        customers.Enqueue("Neha");
        customers.Enqueue("Priya");

        Console.WriteLine("Serving Customers");
        while(customers.Count > 0)
        {
            Console.WriteLine("Serving : " + customers.Dequeue());
        }
    }
}