using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Requesting data from all servers...");
        var cts = new CancellationTokenSource();
        try
        {
            var serverTasks = new Task<string>[]
            {
                GetServer1Response(cts.Token),
                GetServer2Response(cts.Token),
                GetServer3Response(cts.Token)
            };
            var completedTask = await Task.WhenAny(serverTasks);
            cts.Cancel();
            string result = await completedTask;
            Console.WriteLine($"\nFastest response : {result}");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Remaining server requests were cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error : {ex.Message}");
        }
    }
    static async Task<string> GetServer1Response(CancellationToken cancellationToken)
    {
        var delay = new Random().Next(1000, 3000);
        Console.WriteLine($"Server1 will respond in {delay}ms");
        await Task.Delay(delay, cancellationToken);
        return "Response from Server1";
    }
    static async Task<string> GetServer2Response(CancellationToken cancellationToken)
    {
        var delay = new Random().Next(1000, 3000);
        Console.WriteLine($"Server2 will respond in {delay}ms");
        await Task.Delay(delay, cancellationToken);
        return "Response from Server2";
    }
    static async Task<string> GetServer3Response(CancellationToken cancellationToken)
    {
        var delay = new Random().Next(1000, 3000);
        Console.WriteLine($"Server3 will respond in {delay}ms");
        await Task.Delay(delay, cancellationToken);
        return "Response from Server3";
    }
}
