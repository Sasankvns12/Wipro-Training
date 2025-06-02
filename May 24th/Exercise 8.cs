using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting risky tasks...");

        try
        {
           
            var task1 = RiskyTaskAsync("Task 1 (Safe)");
            var task2 = RiskyTaskAsync("Task 2 (Risky)");  
            var task3 = RiskyTaskAsync("Task 3 (Safe)");

            
            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("All tasks completed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError caught: {ex.Message}");
            Console.WriteLine("Failed task details:");

            
            if (ex is AggregateException aggEx)
            {
                foreach (var innerEx in aggEx.InnerExceptions)
                {
                    Console.WriteLine($"- {innerEx.Message}");
                }
            }
            else
            {
                Console.WriteLine($"- {ex.Message}");
            }
        }
    }

    static async Task RiskyTaskAsync(string name)
    {
        Console.WriteLine($"Starting {name}");
        await Task.Delay(new Random().Next(500, 1500)); 

       
        if (name.Contains("Risky"))
        {
            throw new InvalidOperationException($"{name} failed because it's risky!");
        }

        Console.WriteLine($"Completed {name} successfully");
        return;
    }
}