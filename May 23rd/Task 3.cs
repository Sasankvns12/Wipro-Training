using System;
using System.Threading;
class Program
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Thread thread = new Thread(() =>
        {
            Console.WriteLine($"Sum: {a + b}");
        });
        thread.Start();
    }
}