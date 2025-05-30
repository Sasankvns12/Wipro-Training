using System;
public abstract class TicketBooking
{
    public abstract void BookTicket(int seats);
    public void ShowBookingInfo()
    {
        Console.WriteLine("Booking Tickets");
    }
}
class BusBooking : TicketBooking
{
    public override void BookTicket(int seats)
    {
        Console.WriteLine("Booking x Bus Tickets");
    }
}
class FlightBooking : TicketBooking
{
    public override void BookTicket(int seats)
    {
        Console.WriteLine("Booking x Flight Tickets");
    }
}
class Program
{
    public static void Main()
    {
        TicketBooking BusBooking = new BusBooking();
        TicketBooking FlightBooking = new FlightBooking();
        Console.WriteLine("Bus Tickets :");
        BusBooking.ShowBookingInfo();
        BusBooking.BookTicket(3);
        Console.WriteLine("\nFlight Tickets :");
        FlightBooking.ShowBookingInfo();
        FlightBooking.BookTicket(2);
    }
}