using System;
public abstract class PaymentGateway
{
    public abstract void ProcessPayment(double amount);
    public void ShowGatewayName()
    {
        Console.WriteLine("Processing payment through gateway");
    }
}
class StripeGateway : PaymentGateway
{
    public override void ProcessPayment(double amount)
    {
        Console.WriteLine("Processing payment through stripe : {amount}");
    }
}
class PayPalGateway : PaymentGateway
{
    public override void ProcessPayment(double amount)
    {
        Console.WriteLine("Processing payment through paypal : {amount}");
    }
}
class Program
{
    public static void Main()
    {
        PaymentGateway StripeGateway = new StripeGateway();
        PaymentGateway PayPalGateway = new PayPalGateway();
        Console.WriteLine("Stripe methods :");
        StripeGateway.ShowGatewayName();
        StripeGateway.ProcessPayment(2500.00);
        Console.WriteLine("\nPayPal methods :");
        PayPalGateway.ShowGatewayName();
        PayPalGateway.ProcessPayment(1500.00);
    }
}