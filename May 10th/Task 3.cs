using System;
class Product
{
    public string ProductName { get; set; }
    protected decimal price { get; set; }
    public void SetPrice(decimal Price)
    {
        this.price = Price;
    }
    public void SetPrice(int basePrice, int tax)
    {
        this.price = basePrice + (basePrice * tax / 100);
    }
    public virtual void Display()
    {
        Console.WriteLine($"ProductName : {ProductName}");
        Console.WriteLine($"Price : {price}");
    }

}
class Electronics : Product
{
    public int Warranty { get; set; }
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Warranty : {Warranty} months");
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Electronics Laptop = new Electronics();
        Laptop.ProductName = "UltraBook Pro";
        Laptop.Warranty = 24;
        Console.WriteLine("Setting Price with Decimal Value :");
        Laptop.SetPrice(999.99m);
        Laptop.Display();
        Console.WriteLine("\nSetting Price with Base Value and Price :");
        Laptop.SetPrice(900, 10);
        Laptop.Display();
    }
}