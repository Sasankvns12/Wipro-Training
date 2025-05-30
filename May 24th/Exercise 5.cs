using System;
using System.Diagnostics;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching temperatures for cities...");
        Task<int> nyTask = GetTemperatureAsync("New York");
        Task<int> londonTask = GetTemperatureAsync("London");
        Task<int> tokyoTask = GetTemperatureAsync("Tokyo");
        int nyTemp = await nyTask;
        int londonTemp = await londonTask;
        int tokyoTemp = await tokyoTask;
        Console.WriteLine("\nTemperature Results :");
        Console.WriteLine($"New York : {nyTemp} degrees celcius");
        Console.WriteLine($"London : {londonTemp} degrees celcius");
        Console.WriteLine($"Tokyo : {tokyoTemp}degrees celcius");
    }
    static async Task<int> GetTemperatureAsync(string city)
    {
        Console.WriteLine($"Fetching temperature for {city}...");
        Random rnd = new Random();
        int delay = rnd.Next(1000, 3000);
        await Task.Delay(delay);
        int temperature = rnd.Next(-10, 36);
        Console.WriteLine($"Received {temperature} degrees celcius from {city} (took {delay}ms)");
        return temperature;
    }
}