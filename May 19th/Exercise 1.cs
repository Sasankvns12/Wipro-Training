using System;
public abstract class SmartDevice
{
    public abstract void TurnOn();
    public void ShowStatus()
    {
        Console.WriteLine("Device Status : Active");
    }
}
public interface IRemoteControl
{
    void IncreaseVolume();
    void DecreaseVolume();
}
class SmartLight : SmartDevice, IRemoteControl
{
    public override void TurnOn()
    {
        Console.WriteLine("Smart Light turned on");
    }
    public void IncreaseVolume()
    {
        Console.WriteLine("Lights do not support volume control");
    }
    public void DecreaseVolume()
    {
        Console.WriteLine("Lights do not support volume control");
    }
}
class SmartSpeaker : SmartDevice, IRemoteControl
{
    public override void TurnOn()
    {
        Console.WriteLine("Smart Speaker turned on");
    }
    public void IncreaseVolume()
    {
        Console.WriteLine("Volume Increased");
    }
    public void DecreaseVolume()
    {
        Console.WriteLine("Volume Decreased");
    }
}
class Program
{
    public static void Main()
    {
        SmartDevice SmartLight = new SmartLight();
        SmartDevice SmartSpeaker = new SmartSpeaker();
        Console.WriteLine("Testing Smart Light:");
        SmartLight.ShowStatus();
        SmartLight.TurnOn();
        ((IRemoteControl)SmartLight).IncreaseVolume();
        ((IRemoteControl)SmartLight).DecreaseVolume();
        Console.WriteLine("\nTesting Smart Speaker :");
        SmartSpeaker.ShowStatus();
        SmartSpeaker.TurnOn();
        ((IRemoteControl)SmartSpeaker).IncreaseVolume();
        ((IRemoteControl)SmartSpeaker).DecreaseVolume();
    }
}