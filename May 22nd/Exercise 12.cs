using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Dictionary<int, decimal> employeeSalaries = new Dictionary<int, decimal>();
        employeeSalaries.Add(101, 45000.50m);
        employeeSalaries.Add(102, 52000.75m);
        employeeSalaries.Add(103, 38500.25m);
        employeeSalaries.Add(104, 62000.00m);
        employeeSalaries.Add(105, 48000.90m);
        Console.WriteLine("Employee ID's in System :");
        foreach(var id in employeeSalaries.Keys)
        {
            Console.WriteLine($"ID : {id}");
        }
        Console.Write("\nEnter Employee ID to look up salary :");
        string input = Console.ReadLine();
        if(int.TryParse(input, out int employeeId))
        {
            if(employeeSalaries.TryGetValue(employeeId, out decimal Salary))
            {
                Console.WriteLine($"Salary for employee {employeeId} : {Salary}");
            }
            else
            {
                Console.WriteLine($"Employee ID {employeeId} not found");
            }
        }
        else
        {
            Console.WriteLine($"Invalid Input. Please enter a numeric Employee ID");
        }
    }
}