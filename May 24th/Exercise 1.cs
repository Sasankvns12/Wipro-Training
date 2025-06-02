using System;
using System.Threading;
class Program
{
    private static bool _pause = false;
    private static bool _stop = false;
    private static Thread _numberThread;
    static void Main(string[] args)
    {
        _numberThread = new Thread(PrintNumbers);
        _numberThread.Start();
        Console.WriteLine($"Thread started.State : {_numberThread.ThreadState}");
        Thread.Sleep(2000);
        _pause = true;
        Console.WriteLine($"Thread paused.State : {_numberThread.ThreadState}");
        Thread.Sleep(2000);
        _pause = false;
        Console.WriteLine($"Thread resumed.State : {_numberThread.ThreadState}");
        Thread.Sleep(2000);
        _stop = true;
        Console.WriteLine($"Stopping thread.State : {_numberThread.ThreadState}");
        _numberThread.Join();
        Console.WriteLine($"Thread stopped.Final State : {_numberThread.ThreadState}");
    }
    static void PrintNumbers()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (_stop)
            {
                Console.WriteLine("Thread stopping as requested.");
                return;
            }
            while (_pause && !_stop)
            {
                Thread.Sleep(100);
            }
            if (_stop) return;
            Console.WriteLine(i);
            Thread.Sleep(100);
        }
    }
}
