using System;
using System.IO;
using System.Threading;

class ParallelFileReader
{
    private static int totalLines = 0;
    private static readonly object lockObject = new object();

    static void Main(string[] args)
    {
        // File paths - replace these with your actual file paths
        string[] filePaths = {
            @"C:\largefile1.txt",
            @"C:\largefile2.txt",
            @"C:\largefile3.txt"
        };

        // Create and start threads for each file
        Thread[] threads = new Thread[filePaths.Length];
        
        for (int i = 0; i < filePaths.Length; i++)
        {
            string filePath = filePaths[i];
            threads[i] = new Thread(() => ReadFile(filePath));
            threads[i].Start();
            Console.WriteLine($"Started thread for {filePath}");
        }

        // Wait for all threads to complete
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine($"\nAll files processed. Total lines across all files: {totalLines}");
    }

    static void ReadFile(string filePath)
    {
        try
        {
            int fileLineCount = 0;
            
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    fileLineCount++;
                }
            }

            // Safely update the total line count
            lock (lockObject)
            {
                totalLines += fileLineCount;
            }

            Console.WriteLine($"File {Path.GetFileName(filePath)}: {fileLineCount} lines");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file {filePath}: {ex.Message}");
        }
    }
}