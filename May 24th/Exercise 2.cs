using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Thread PrintThread = new Thread(PrintTask);
        Thread ComputeThread = new Thread(ComputeTask);
        Thread WaitThread = new Thread(WaitTask);

        Console.WriteLine("Starting all threads...");

        PrintThread.Start();
        ComputeThread.Start();
        WaitThread.Start();

        PrintThread.Join();
        ComputeThread.Join();
        WaitThread.Join();

        Console.WriteLine("All tasks done.");
    }
    static void PrintTask()
    {
        Console.WriteLine("Print Task Started");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Printing document page {i}/5");
            Thread.Sleep(300);
        }
        Console.WriteLine("Print Task Completed");
    }
    static void ComputeTask()
    {
        Console.WriteLine("Compute Task Started");
        int result = 0;
        for (int i = 1; i <= 10; i++)
        {
            result += i * i;
            Thread.Sleep(200);
        }
        Console.WriteLine($"Compute Task Completed.Result : {result}");
    }
    static void WaitTask()
    {
        Console.WriteLine("Wait Task Started");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine($"Waiting... {i} seconds remaining");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Wait Task Completed");
    }
}

