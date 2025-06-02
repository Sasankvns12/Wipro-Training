using System;
using System.Diagnostics;
using System.Threading.Tasks;

class WeatherService
{
    // Simulate fetching weather data for a city with random delay
    private async Task<string> FetchWeatherAsync(string city)
    {
        Random rnd = new Random();
        int delay = rnd.Next(1000, 3000); // Random delay between 1-3 seconds
        
        Console.WriteLine($"Fetching weather for {city} (will take {delay}ms)...");
        await Task.Delay(delay); // Simulate API call delay
        
        // Simulated weather data
        string[] conditions = { "Sunny", "Cloudy", "Rainy", "Snowy" };
        int temp = rnd.Next(-10, 35);
        string condition = conditions[rnd.Next(conditions.Length)];
        
        return $"Weather in {city}: {temp}°C, {condition}";
    }

    public async Task GetWeatherForCitiesAsync()
    {
        string[] cities = { "New York", "London", "Tokyo" };
        var stopwatch = Stopwatch.StartNew();

        Console.WriteLine("Starting weather data retrieval...\n");

        // Create all tasks concurrently
        Task<string>[] weatherTasks = new Task<string>[cities.Length];
        for (int i = 0; i < cities.Length; i++)
        {
            weatherTasks[i] = FetchWeatherAsync(cities[i]);
        }

        // Wait for all tasks to complete
        string[] results = await Task.WhenAll(weatherTasks);

        Console.WriteLine("\nAll weather data received:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }

        stopwatch.Stop();
        Console.WriteLine($"\nTotal time taken: {stopwatch.ElapsedMilliseconds}ms");
    }
}

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Weather Service Simulation\n");
        var weatherService = new WeatherService();
        
        await weatherService.GetWeatherForCitiesAsync();
    }
}