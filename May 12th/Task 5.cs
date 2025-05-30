abstract class Vehicle
{
    public string Brand;
    public int Year;
    public void DisplayInfo()
    {
        Console.WriteLine($"Brand : {Brand}, Year : {Year}");
    }
    public abstract void Start();
}
class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car is starting with the key");
    }
}
class Bike : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Bike is starting with the kick");
    }
}
class Program
{
    public static void Main()
    {
        Car MyCar = new Car();
        MyCar.Start();
        Console.WriteLine();
        
        Bike MyBike = new Bike();
        MyBike.Start();
        Console.WriteLine();
    }
}