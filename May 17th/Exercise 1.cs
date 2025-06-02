using System;
public interface IMaintenance
{
    public void Service();
    public void Repair();

}
class CarMaintenance : IMaintenance
{
    public void Service()
    {
        Console.WriteLine("Car is being serviced");
    }
    public void Repair()
    {
        Console.WriteLine("Car is being repaired");
    }
}
class BikeMaintenance : IMaintenance
{
    public void Service()
    {
        Console.WriteLine("Bike is being serviced");
    }
    public void Repair()
    {
        Console.WriteLine("Bike is being repaired");
    }
}
class Program
{
    public static void Main()
    {
        IMaintenance CarMaintenance = new CarMaintenance();
        IMaintenance BikeMaintenance = new BikeMaintenance();
        Console.WriteLine("Car Maintenance :");
        CarMaintenance.Service();
        CarMaintenance.Repair();
        Console.WriteLine("\nBike Maintenance :");
        BikeMaintenance.Service();
        BikeMaintenance.Repair();
    }
}
