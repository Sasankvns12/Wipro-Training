using System;
public interface IDeviceControl
{
    public void TurnOn();
    public void TurnOff();
}
class SmartTV : IDeviceControl
{
    public void TurnOn()
    {
        Console.WriteLine("SmartTV is now ON");
    }
    public void TurnOff()
    {
        Console.WriteLine("SmartTV is now OFF");
    }
}
class Speaker : IDeviceControl
{
    public void TurnOn()
    {
        Console.WriteLine("Speaker is now ON");
    }
    public void TurnOff()
    {
        Console.WriteLine("Speaker is now OFF");
    }
}
class Program
{
    public static void Main()
    {
        IDeviceControl SmartTV = new SmartTV();
        IDeviceControl Speaker = new Speaker();
        Console.WriteLine("Turning devices ON :");
        SmartTV.TurnOn();
        Speaker.TurnOn();
        Console.WriteLine("\nTurning devices OFF :");
        SmartTV.TurnOff();
        Speaker.TurnOff();
    }
}