using System;
using System.Collections.Generic;
using System.Threading;
class Program
{
    private static Queue<string> taskQueue = new Queue<string>();
    private static bool running = true;
    private static int tasksProcessed = 0;
    private static readonly object queueLock = new object();
    static void Main(string[] args)
    {
        Thread workerThread = new Thread(ProcessTasks);
        workerThread.Start();
        for(int i = 1; i <=5; i++)
        {
            string task = $"Task_{i}";
            lock(queueLock)
            {
                taskQueue.Enqueue(task);
                Console.WriteLine($"Main : Enqueued {task}");
            }
            Thread.Sleep(200);
        }
        while(true)
        {
            lock(queueLock)
            {
                if (tasksProcessed == 5)
                break;
            }
            Thread.Sleep(100);
        }
        running = false;
        workerThread.Join();
        Console.WriteLine("All tasks processed. Exiting...");
    }
    static void ProcessTasks()
    {
        Console.WriteLine("Worker thread started.");
        while(running)
        {
            string task = null;
            lock(queueLock)
            {
                if(taskQueue.Count > 0)
                {
                    task = taskQueue.Dequeue();
                }
            }
            if(task != null)
            {
                Console.WriteLine($"Worker : Processing {task}");
                Thread.Sleep(500);
                lock(queueLock)
                {
                    tasksProcessed++;
                    Console.WriteLine($"Worker : Completed {task} ({tasksProcessed} / 5)");
                }
            }
            else
            {
                Thread.Sleep(100);
            }
        }
        Console.WriteLine("Worker thread exiting.");
    }
}
