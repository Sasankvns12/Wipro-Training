using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Work Started");
        await DoAsyncWork();
        Console.WriteLine("Work Completed");
    }
    static async Task DoAsyncWork()
    {
        Console.WriteLine("Working asynchronously");
        await Task.Delay(2000);
        Console.WriteLine("Async work done");
    }
}