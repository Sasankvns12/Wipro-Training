using System;
public abstract class Notification
{
    public abstract void Send();
    public void ShowType()
    {
        Console.WriteLine("Sending Notification");
    }
}
class EmailNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending Email Notification");
    }
}
class SMSNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending SMS Notification");
    }
}
class Program
{
    public static void Main()
    {
        Notification EmailNotification = new EmailNotification();
        Notification SMSNotification = new SMSNotification();
        Console.WriteLine("Email Notification :");
        EmailNotification.ShowType();
        EmailNotification.Send();
        Console.WriteLine("\nSMS Notification :");
        SMSNotification.ShowType();
        SMSNotification.Send();
    }
}
