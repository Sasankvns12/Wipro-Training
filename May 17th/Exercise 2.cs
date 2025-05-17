using System;
public interface ISupportTicket
{
    public void CreateTicket(string issue);
    public void ResolveTicket(int tickedId);

}
class EmailSupport : ISupportTicket
{
    public void CreateTicket(string issue)
    {
        Console.WriteLine($"Creating ticket via Email: {issue}");
    }
    public void ResolveTicket(int ticketId)
    {
        Console.WriteLine($"Resolving ticket {ticketId} via Email");
    }
}
class PhoneSupport : ISupportTicket
{
    public void CreateTicket(string issue)
    {
        Console.WriteLine($"Creating ticket via phone : {issue}");
    }
    public void ResolveTicket(int ticketId)
    {
        Console.WriteLine($"Resolving ticket {ticketId} via phone");
    }
}
class Program
{
    public static void Main()
    {
        ISupportTicket EmailSupport = new EmailSupport();
        ISupportTicket PhoneSupport = new PhoneSupport();
        Console.WriteLine("Email Support :");
        EmailSupport.CreateTicket("Cannot access my account");
        EmailSupport.ResolveTicket(1001);
        Console.WriteLine("\nPhone Support :");
        PhoneSupport.CreateTicket("Payment processing failed");
        PhoneSupport.ResolveTicket(1002);
    }
}