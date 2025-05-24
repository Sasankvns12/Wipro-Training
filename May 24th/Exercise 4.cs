using System;
using System.Diagnostics;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting file downloads...");
        var StopWatch = Stopwatch.StartNew();
        Task<string> download1 = DownloadFileAsync("document.pdf", 1500);
        Task<string> download2 = DownloadFileAsync("image.jpg", 1000);
        Task<string> download3 = DownloadFileAsync("archive.zip", 2000);
        string[] results = await Task.WhenAll(download1, download2, download3);
        StopWatch.Stop();
        Console.WriteLine("\nAll downloads completed!");
        Console.WriteLine($"Total download time : {StopWatch.ElapsedMilliseconds}ms");
        foreach(var result in results)
        {
            Console.WriteLine(result);
        }
    }
    static async Task<string> DownloadFileAsync(string fileName, int delay)
    {
        Console.WriteLine($"Starting download of {fileName}(estimated time : {delay}ms)");
        await Task.Delay(delay);
        long fileSize = new Random().Next(500, 5000) * 1024;
        string result = $"Downloaded {fileName} ({fileSize / 1024}KB) in {delay}ms";
        Console.WriteLine($"Completed download of {fileName}");
        return result;
    }
}