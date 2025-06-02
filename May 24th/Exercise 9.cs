using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
       
        var cts = new CancellationTokenSource();

        Console.WriteLine("Starting work...");

        
        var workTask = DoWorkAsync(cts.Token);

        
        _ = Task.Delay(2000).ContinueWith(_ => {
            Console.WriteLine("\nRequesting cancellation after 2 seconds...");
            cts.Cancel();
        });

        try
        {
            await workTask;
            Console.WriteLine("Work completed successfully.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Work was canceled successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Work failed: {ex.Message}");
        }
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        try
        {
            for (int i = 1; i <= 10; i++)
            {
                
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"Working... Step {i}/10");
                await Task.Delay(500, token); 
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Cleaning up resources...");
            throw; 
        }
    }
}