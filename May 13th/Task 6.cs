using System;
public interface ITransport
{
    public void Start()
    {
        Console.WriteLine("Starting the transport");
    }
    public void Stop()
    {
        Console.WriteLine("Stopping the transport");
    }
}
class Bus : ITransport
{
    public void Start()
    {
        Console.WriteLine("Bus is starting");
    }
    public void Stop()
    {
        Console.WriteLine("Bus is stopping");
    }
}
class Train : ITransport
{
    public void Start()
    {
        Console.WriteLine("Train is starting");
    }
    public void Stop()
    {
        Console.WriteLine("Train is stopping");
    }
}
class Program
{
    public static void Main()
    {
        ITransport Bus = new Bus();
        ITransport Train = new Train();
        Console.WriteLine("Bus Operations :");
        Bus.Start();
        Bus.Stop();
        Console.WriteLine("\nTrain Operations :");
        Train.Start();
        Train.Stop();
    }
}
