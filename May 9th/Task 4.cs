using System;
class Vehicle
{
    public string Make;
    public string Model;
    public void DisplayVehicle()
    {
        Console.WriteLine($"Make : {Make}");
        Console.WriteLine($"Model : {Model}");
    }
}
class Car : Vehicle
{
    public string FuelType;
    public void DisplayCar()
    {
        DisplayVehicle();
        Console.WriteLine($"Fuel Type : {FuelType}");
    }
}
class Program
{
    public static void Main()
    {
        Car myCar = new Car();
        myCar.Make = "Toyata";
        myCar.Model = "Camry";
        myCar.FuelType = "Hybrid";
        Console.WriteLine("Vehicle Details");
        myCar.DisplayCar();


    }
}
