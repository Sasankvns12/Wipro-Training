interface IPayment
{
    void ProcessPayment(decimal amount);
}
class CreditCardPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card Payment of {amount}");
    }
}
class PayPalPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPalPayment of {amount}");
    }
}
class Program
{
    public static void Main()
    {
        IPayment payment;
        payment = new CreditCardPayment ();
        payment.ProcessPayment(1500.50m);
        payment = new PayPalPayment();
        payment.ProcessPayment(2500.75m);
    }
}
