using System;
using System.Threading;
class Program
{
    static bool pause = false;
    static bool stop = false;
    static void DoWork()
    {
        while(!stop)
        {
            if(pause)
            {
                Console.WriteLine("Thread Paused...");
                Thread.Sleep(500);
                continue;
            }
            Console.WriteLine("Thread is working...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Thread has stopped.");
    }
    static void Main()
    {
        Thread worker = new Thread(DoWork);
        Console.WriteLine("Initial Thread State :" + worker.ThreadState);
        worker.Start();

        Thread.Sleep(1000);
        pause = true;
        Console.WriteLine("Paused Thread State :" + worker.ThreadState);

        Thread.Sleep(1000);
        pause = false;
        Console.WriteLine("Resuming work...");

        Thread.Sleep(1000);
        stop = true;
        Console.WriteLine("Stopping thread");

        worker.Join();
        Console.WriteLine("Final Thread State :" + worker.ThreadState);
    }
}