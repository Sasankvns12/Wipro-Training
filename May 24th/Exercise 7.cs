using System;
using System.Diagnostics;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        var StopWatch = new Stopwatch();
        Console.WriteLine("Starting sequential execution...");
        Stopwatch.StartNew();
        await SimulateWorkAsync("Task 1 (Sequential)", 1000);
        await SimulateWorkAsync("Task 2 (Sequential)", 1500);
        await SimulateWorkAsync("Task 3 (Sequential)", 800);
        StopWatch.Stop();
        var SequentialTime = StopWatch.ElapsedMilliseconds;
        Console.WriteLine($"Sequential execution completed in {SequentialTime}ms\n");
        Console.WriteLine("Starting parallel execution...");
        StopWatch.Restart();
        var task1 = SimulateWorkAsync("Task 1 (Parallel)", 1000);
        var task2 = SimulateWorkAsync("Task 2 (Parallel)", 1500);
        var task3 = SimulateWorkAsync("Task 3 (Parallel)", 800);
        await Task.WhenAll(task1, task2, task3);
        StopWatch.Stop();
        var ParallelTime = StopWatch.ElapsedMilliseconds;
        Console.WriteLine($"Parallel execution completed in {ParallelTime}ms\n");
        Console.WriteLine("Execution time comparision :");
        Console.WriteLine($"Sequential : {SequentialTime}ms");
        Console.WriteLine($"Parallel : {ParallelTime}ms");
        Console.WriteLine($"Difference : {SequentialTime - ParallelTime}ms");

    }
    static async Task SimulateWorkAsync(string name, int delayMs)
    {
        Console.WriteLine($"Starting {name} (delay : {delayMs}ms");
        await Task.Delay(delayMs);
        Console.WriteLine($"Completed {name}");
    }
}