using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting to process items using ThreadPool...");
        for(int i = 1; i <= 5; i++)
        {
            ThreadPool.QueueUserWorkItem(ProcessItem, $"Item-{i}");
        }
        Thread.Sleep(3500);
        Console.WriteLine("All items have been queued for processing.");
    }
    static void ProcessItem(object item)
    {
        string itemName = item as string;
        if (itemName == null) return;
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}]Starting to process {itemName}");
        int delay = 200 * int.Parse(itemName.Split('-')[1]);
        Thread.Sleep(delay);
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}]Finished processing {itemName} (took {delay}ms)");
    }
}