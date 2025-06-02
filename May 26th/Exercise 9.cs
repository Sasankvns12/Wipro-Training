using System;
using System.Collections.Generic;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting 5 tasks (2 will fail)...");
        try
        {
            var tasks = new List<Task>
            {
                SuccessfulTask("Task 1"),
                FailingTask("Task 2", "Database connection failed"),
                SuccessfulTask("Task 3"),
                FailingTask("Task 4", "File not found"),
                SuccessfulTask("Task 5")
            };
            await Task.WhenAll(tasks);
            Console.WriteLine("\nAll tasks completed (some with errors)");
        }
        catch(AggregateException ae)
        {
            Console.WriteLine("\nCaught AggregateException.Individual errors :");
            foreach(var ex in ae.Flatten().InnerExceptions)
            {
                Console.WriteLine($" - {ex.Message}");
            }
            Console.WriteLine("\nAll tasks completed (with some failures)");
        }
    }
    static async Task SuccessfulTask(string name)
    {
        await Task.Delay(new Random().Next(500, 1500));
        Console.WriteLine($"{name} completed successfully");
    }
    static async Task FailingTask(string name, string errorMessage)
    {
        await Task.Delay(new Random().Next(500, 1500));
        throw new InvalidOperationException($"{name} failed:{errorMessage}");
    }
}