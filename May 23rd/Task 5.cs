using System;
using System.Threading;
class Program
{
    static void DoWork(object state)
    {
        Console.WriteLine($"ThreadPool Task Started -{state}");
        Thread.Sleep(1000);
        Console.WriteLine($"ThreadPool Task Finished -{state}");
            
    }
    static void Main()
    {
        for(int i = 1; i <= 5; i++)
        {
            ThreadPool.QueueUserWorkItem(DoWork, $"Task {i}");
        }

        Console.WriteLine("Main thread continues...");
        Thread.Sleep(3000);
        Console.WriteLine("Main thread ends");
    }
}