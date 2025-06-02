using System;
using System.Collections.Generic;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        var imageFiles = new List<string>();
        for(int i = 1; i <=20; i++)
        {
            imageFiles.Add($"image_{i:D2}.jpg");
        }
        Console.WriteLine($"Starting parallel processing of {imageFiles.Count} images...");
        Console.WriteLine();
        int totalFiles = imageFiles.Count;
        int processedFiles = 0;
        object lockObj = new object();
        var parallelOptions = new ParallelOptions
        {
            MaxDegreeOfParallelism = Environment.ProcessorCount
        };
        await Parallel.ForEachAsync(imageFiles, parallelOptions, async (imageFile, cancellationToken) =>
        {
            await Task.Delay(200, cancellationToken);
            lock (lockObj)
            {
                processedFiles++;
                int percentage = (int)((double)processedFiles / totalFiles * 100);
                Console.WriteLine($"\rProcessing : {percentage}% complete({processedFiles}/{totalFiles})");
            }
        });
        Console.WriteLine("\n\nAll images processed successfully!");
    }
}