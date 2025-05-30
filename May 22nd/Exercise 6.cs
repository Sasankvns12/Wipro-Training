using System;
using System.Collections.Generic;
public abstract class Vehicle
{
    public string VehicleNumber { get; set; }
    public string Brand { get; set; }
    public decimal RatePerDay { get; set; }
    public virtual decimal CalculateRent(int days)
    {
        return days * RatePerDay;
    }
    public override string ToString()
    {
        return $"{GetType().Name} - Brand : {Brand}, Number : {VehicleNumber}";
    }
}
public class Car : Vehicle
{
    public Car(string number, string brand, decimal rate)
    {
        VehicleNumber = number;
        Brand = brand;
        RatePerDay = rate;
    }
    public override decimal CalculateRent(int days)
    {
        decimal baseCost = base.CalculateRent(days);
        return days > 3 ? baseCost * 1.10m : baseCost;
    }
}
public class Bike : Vehicle
{
    public Bike(string number, string brand, decimal rate)
    {
        VehicleNumber = number;
        Brand = brand;
        RatePerDay = rate;
    }
    public override decimal CalculateRent(int days)
    {
        int freeDays = days / 5;
        return (days - freeDays) * RatePerDay;
    }
}
public class Truck : Vehicle
{
    public Truck(string number, string brand, decimal rate)
    {
        VehicleNumber = number;
        Brand = brand;
        RatePerDay = rate;
    }
    public override decimal CalculateRent(int days)
    {
        decimal baseCost = days * RatePerDay;
        return baseCost < (3 * RatePerDay) ? (3 * RatePerDay) : baseCost;
    }
}
class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("C-101", "Toyata", 2500),
            new Bike("B-202", "Honda", 800),
            new Car("T-303", "Volvo", 5000),
            new Car("C-404", "BMW", 4000),
            new Bike("B-505", "Yamaha", 900),
        };
        int rentalDays = 5;
        Console.WriteLine($"Rental Costs for {rentalDays} days :");
        foreach(var vehicle in vehicles)
        {
            decimal rent = vehicle.CalculateRent(rentalDays);
            Console.WriteLine($"{vehicle}");
            Console.WriteLine($"Daily Rate : {vehicle.RatePerDay}");
            Console.WriteLine($"Total Rent :{rent}\n");
        }
    }
}
