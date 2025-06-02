using System;
using System.Runtime.InteropServices;
public abstract class PaymentMethod
{
    public abstract void ProcessPayment(decimal amount);
    public void ShowPaymentMethod(string method)
    {
        Console.WriteLine($"Payment Method : {method}");
    }
}
class CreditCardPayment : PaymentMethod
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card Payment of : {amount}");
    }
    
}
class UPIPayment : PaymentMethod
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing UPI Payment of : {amount}");
    }
    
}
class Program
{
    public static void Main()
    {
        PaymentMethod CreditCardPayment = new CreditCardPayment();
        PaymentMethod UPIPayment = new UPIPayment();
        Console.WriteLine("Credit Card Payment :");
        CreditCardPayment.ShowPaymentMethod("VISA Credit Card");
        CreditCardPayment.ProcessPayment(2500.50m);
        Console.WriteLine("\nUPI Payment :");
        UPIPayment.ShowPaymentMethod("PhonePe UPI");
        UPIPayment.ProcessPayment(1500.75m);
        Console.WriteLine("Polymorphism Demo");
        PaymentMethod[] Payments = new PaymentMethod[2];
        Payments[0] = new CreditCardPayment();
        Payments[1] = new UPIPayment();
        foreach(var payment in Payments)
        {
            payment.ShowPaymentMethod(payment.GetType().Name);
            payment.ProcessPayment(1000.00m);
            Console.WriteLine();
        }
    }
}