using System;
using System.Diagnostics;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting three tasks with different delays...");
        Task<string> Task1 = SimulateTask("Task 1 (Fast)", 1500);
        Task<string> Task2 = SimulateTask("Task 2 (Medium)", 2500);
        Task<string> Task3 = SimulateTask("Task 3 (Slow)", 3500);
        Task<string> firstFinishedTask = await Task.WhenAny(Task1, Task2, Task3);
        string result = await firstFinishedTask;
        Console.WriteLine($"\nFirst task to complete : {result}");
        Console.WriteLine("Waiting for remaining tasks to finish...");
        await Task.WhenAll(Task1, Task2, Task3);
        Console.WriteLine("All tasks have completed.");

    }
    static async Task<string> SimulateTask(string taskName, int delayMs)
    {
        Console.WriteLine($"Starting {taskName} with delay {delayMs}ms");
        await Task.Delay(delayMs);
        Console.WriteLine($"Completed {taskName}");
        return taskName;
    }
}