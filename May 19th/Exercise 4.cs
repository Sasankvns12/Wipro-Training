using System;
using System.Collections.Generic;
using System.Linq;
public class Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }

}
class Program
{
    static void Main()
    {
        List<Employee> Employees = new List<Employee>
        {
        new Employee { EmployeeID = 101, Name = "John Smith", Salary = 75000 },
        new Employee { EmployeeID = 102, Name = "Sarah Johnson", Salary = 82000 },
        new Employee { EmployeeID = 103, Name = "Michael Brown", Salary = 68000 },
        new Employee { EmployeeID = 104, Name = "Emily Davis", Salary = 91000 },
        new Employee { EmployeeID = 105, Name = "Robert Wilson", Salary = 78500 },
        };
        Employee HighestPaid = Employees.OrderByDescending(e => e.Salary).First();
        Console.WriteLine($"Highest Paid Employee : {HighestPaid.Name}, Salary: {HighestPaid.Salary}");
        Dictionary<int, string> employeeDictionary = new Dictionary<int, string>();
        foreach (var emp in Employees)
        {
            employeeDictionary.Add(emp.EmployeeID, emp.Name);
        }
        Console.WriteLine("\nEmployeeDictionary :");
        foreach (var kvp in employeeDictionary)
        {
            Console.WriteLine($"ID : {kvp.Key}, Name : {kvp.Value}");
        }
        Console.Write("\nEnter EmployeeID to search :");
        if (int.TryParse(Console.ReadLine(), out int searchID))
        {
            if (employeeDictionary.TryGetValue(searchID, out string employeeName))
            {
                Console.WriteLine($"Employee found : {employeeName}");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID entered");
        }

    }
}

