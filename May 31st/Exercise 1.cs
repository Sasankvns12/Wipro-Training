using System;
using System.Collections.Generic;

// Interface for rentable objects
public interface IRentable
{
    decimal RentCostPerDay { get; }
    void Rent();
}

// Base class
public abstract class Vehicle : IRentable
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public abstract decimal RentCostPerDay { get; }
    public bool IsRented { get; private set; }

    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void Rent()
    {
        if (IsRented)
        {
            Console.WriteLine($"{GetType().Name} {Make} {Model} is already rented.");
        }
        else
        {
            IsRented = true;
            Console.WriteLine($"{GetType().Name} {Make} {Model} has been rented for ${RentCostPerDay}/day.");
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Year} {Make} {Model} (${RentCostPerDay}/day)";
    }
}

// Subclass Car
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public override decimal RentCostPerDay => 50.00m;

    public Car(string make, string model, int year, int doors) 
        : base(make, model, year)
    {
        NumberOfDoors = doors;
    }

    public override string ToString()
    {
        return base.ToString() + $", {NumberOfDoors} doors";
    }
}

// Subclass Bike
public class Bike : Vehicle
{
    public string BikeType { get; set; }
    public override decimal RentCostPerDay => 15.00m;

    public Bike(string make, string model, int year, string bikeType) 
        : base(make, model, year)
    {
        BikeType = bikeType;
    }

    public override string ToString()
    {
        return base.ToString() + $", {BikeType}";
    }
}

// Subclass Truck
public class Truck : Vehicle
{
    public decimal LoadCapacity { get; set; } // in tons
    public override decimal RentCostPerDay => 120.00m;

    public Truck(string make, string model, int year, decimal loadCapacity) 
        : base(make, model, year)
    {
        LoadCapacity = loadCapacity;
    }

    public override string ToString()
    {
        return base.ToString() + $", {LoadCapacity} ton capacity";
    }
}

// Rental System
public class RentalSystem
{
    private List<IRentable> rentableItems = new List<IRentable>();

    public void AddVehicle(Vehicle vehicle)
    {
        rentableItems.Add(vehicle);
    }

    public void DisplayAvailableVehicles()
    {
        Console.WriteLine("\nAvailable Vehicles:");
        Console.WriteLine("------------------");
        
        foreach (var item in rentableItems)
        {
            if (item is Vehicle vehicle && !vehicle.IsRented)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }

    public void RentVehicle(int index)
    {
        if (index >= 0 && index < rentableItems.Count)
        {
            if (rentableItems[index] is IRentable rentable)
            {
                rentable.Rent();
            }
        }
        else
        {
            Console.WriteLine("Invalid vehicle selection.");
        }
    }

    public void RentMultipleVehicles(List<int> indices)
    {
        decimal totalCost = 0;
        Console.WriteLine("-------------------------");
        
        foreach (var index in indices)
        {
            if (index >= 0 && index < rentableItems.Count)
            {
                if (rentableItems[index] is IRentable rentable)
                {
                    rentable.Rent();
                    totalCost += rentable.RentCostPerDay;
                }
            }
            else
            {
                Console.WriteLine($"Invalid vehicle selection at index {index}.");
            }
        }
        
        Console.WriteLine($"Total daily cost for all rented vehicles: ${totalCost}");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create rental system
        var rentalSystem = new RentalSystem();

        // Add some vehicles
        rentalSystem.AddVehicle(new Car("Toyota", "Camry", 2020, 4));
        rentalSystem.AddVehicle(new Car("Honda", "Civic", 2021, 2));
        rentalSystem.AddVehicle(new Bike("Trek", "FX", 2022, "Hybrid"));
        rentalSystem.AddVehicle(new Bike("Giant", "Defy", 2021, "Road"));
        rentalSystem.AddVehicle(new Truck("Ford", "F-150", 2020, 1.5m));
        rentalSystem.AddVehicle(new Truck("Chevrolet", "Silverado", 2022, 2.0m));

        // Display available vehicles
        rentalSystem.DisplayAvailableVehicles();

        // Rent a single vehicle
        Console.WriteLine("\nRenting a single vehicle:");
        rentalSystem.RentVehicle(0); // Rent the Toyota Camry

        // Display available vehicles again
        rentalSystem.DisplayAvailableVehicles();

        // Rent multiple vehicles
        Console.WriteLine("\nRenting multiple vehicles:");
        rentalSystem.RentMultipleVehicles(new List<int> { 1, 2, 4 }); // Rent Honda Civic, Trek FX, and Ford F-150

        // Display available vehicles one more time
        rentalSystem.DisplayAvailableVehicles();
    }
}