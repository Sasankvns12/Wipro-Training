using System;
namespace CompressionStrategy
{
    public abstract class CompressionStrategy
    {
        public abstract void Compress(string inputPath, string outputPath);
    }
    public class ZipCompression : CompressionStrategy
    {
        public override void Compress(string inputPath, string outputPath)
        {
            Console.WriteLine($"Compressing {inputPath} to {outputPath} using ZIP format.");
            Console.WriteLine("ZIP Compression completed successfully.");
        }
    }
    public class RarCompression : CompressionStrategy
    {
        public override void Compress(string inputPath, string outputPath)
        {
            Console.WriteLine($"Compressing {inputPath} to {outputPath} using RAR format.");
            Console.WriteLine("RAR Compression completed successfully.");
        }
    }
    public class Compressor
    {
        private CompressionStrategy _strategy;
        public Compressor(CompressionStrategy strategy)
        {
            _strategy = strategy;
        }
        public CompressionStrategy Strategy
        {
            set { _strategy = value; }
        }
        public void CompressFile(string inputPath, string outputPath)
        {
            _strategy.Compress(inputPath, outputPath);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var compressor = new Compressor(new ZipCompression());
            compressor.CompressFile("document.txt", "document.zip");
            Console.WriteLine("\nChanging Compression strategy at runtime...\n");
            compressor.Strategy = new RarCompression();
            compressor.CompressFile("image.png", "image.rar");
            Console.WriteLine("\nSwitching back to ZIP Strategy...\n");
            compressor.Strategy = new ZipCompression();
            compressor.CompressFile("data.csv", "data.zip");
        }
    }
}