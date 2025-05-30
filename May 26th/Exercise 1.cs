using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
public interface IPaymentProcessor
{
    void ProcessPayment();
}
public abstract class PaymentGateway
{
    public abstract string GatewayName { get; }
    public abstract bool Validate();
}
class Razorpay : PaymentGateway, IPaymentProcessor
{
    public override string GatewayName => "Razorpay";
    public override bool Validate()
    {
        Console.WriteLine($"Validating {GatewayName} Crediantials...");
        return true;
    }
    public void ProcessPayment()
    {
        if(Validate())
        {
            Console.WriteLine($"Processing Payment with {GatewayName}...");
            Console.WriteLine($"{GatewayName} Payment processed successfully!");
        }
        else
        {
            Console.WriteLine($"{GatewayName} validation failed. Payment aborted.");
        }
    }
}
class PayPal : PaymentGateway, IPaymentProcessor
{
    public override string GatewayName => "PayPal";
    public override bool Validate()
    {
        Console.WriteLine($"Validating {GatewayName} Crediantials...");
        return true;
    }
    public void ProcessPayment()
    {
        if (Validate())
        {
            Console.WriteLine($"Processing Payment with {GatewayName}...");
            Console.WriteLine($"{GatewayName} Payment processed successfully!");
        }
        else
        {
            Console.WriteLine($"{GatewayName} validation failed. Payment aborted.");
        }
    }
}
class Stripe : PaymentGateway, IPaymentProcessor
{
    public override string GatewayName => "Stripe";
    public override bool Validate()
    {
        Console.WriteLine($"Validating {GatewayName} Crediantials...");
        return true;
    }
    public void ProcessPayment()
    {
        if (Validate())
        {
            Console.WriteLine($"Processing Payment with {GatewayName}...");
            Console.WriteLine($"{GatewayName} Payment processed successfully!");
        }
        else
        {
            Console.WriteLine($"{GatewayName} validation failed. Payment aborted.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        List<IPaymentProcessor> PaymentProcessors = new List<IPaymentProcessor>
        {
            new Razorpay(),
            new PayPal(),
            new Stripe()
        };
        Console.WriteLine("Processing Payments :");
        foreach(var processor in PaymentProcessors)
        {
            processor.ProcessPayment();
            Console.WriteLine();
        }
    }
}
