using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<string, string> cities = new Dictionary<string, string>
        {
            {"Mumbai", "Maharashtra" },
            {"Bangalore", "Karnataka" },
            {"Chennai", "Tamil Nadu" },
            {"Kolkata", "West Bengal" },
            {"Hyderabad", "Telangana" },
        };
        Console.WriteLine("Indian cities and their states");
        foreach (var city in cities)
        {
            Console.WriteLine($" s{city.Key} is in {city.Value} ");
        }
        if (cities.ContainsKey("Chennai"))
        {
            Console.WriteLine("Chennai is present in the dictionary");
        }
    }
}