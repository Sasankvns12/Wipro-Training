using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<int, string>  employees = new Dictionary<int, string>
        {
            { 1, "Rohit" },
            { 2, "Anjali" },
            { 3, "Sandeep"}
        };
        employees[2] = "Ananya";
        Console.WriteLine("Updated Employee List : ");
        foreach ( var emp in employees)
        {
            Console.WriteLine($"ID : {emp.Key}, Name : {emp.Value} ");
        }
    }
}