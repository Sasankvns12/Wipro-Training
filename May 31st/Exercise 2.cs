using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Employee(int id, string name, string department, decimal salary)
    {
        ID = id;
        Name = name;
        Department = department;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Department: {Department}, Salary: {Salary:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list of employees
        List<Employee> employees = new List<Employee>
        {
            new Employee(1, "John Smith", "IT", 75000),
            new Employee(2, "Jane Doe", "HR", 65000),
            new Employee(3, "Mike Johnson", "IT", 82000),
            new Employee(4, "Sarah Williams", "Finance", 90000),
            new Employee(5, "David Brown", "HR", 58000),
            new Employee(6, "Emily Davis", "Finance", 95000),
            new Employee(7, "Robert Wilson", "IT", 78000),
            new Employee(8, "Lisa Taylor", "Marketing", 70000),
            new Employee(9, "James Anderson", "Marketing", 72000),
            new Employee(10, "Jessica Martinez", "Finance", 88000)
        };

        // 1. Display all employees
        Console.WriteLine("All Employees:");
        Console.WriteLine("--------------");
        employees.ForEach(e => Console.WriteLine(e));
        Console.WriteLine();

        // 2. Filter employees by department
        Console.Write("Enter department to filter (IT, HR, Finance, Marketing): ");
        string deptFilter = Console.ReadLine();
        
        var filteredEmployees = employees
            .Where(e => e.Department.Equals(deptFilter, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine($"\nEmployees in {deptFilter} department:");
        Console.WriteLine("----------------------------------");
        filteredEmployees.ForEach(e => Console.WriteLine(e));
        Console.WriteLine();

        // 3. Sort employees by salary descending
        var sortedBySalary = employees
            .OrderByDescending(e => e.Salary)
            .ToList();

        Console.WriteLine("Employees sorted by salary (descending):");
        Console.WriteLine("----------------------------------------");
        sortedBySalary.ForEach(e => Console.WriteLine(e));
        Console.WriteLine();

        // 4. Find average salary per department
        var avgSalaryByDept = employees
            .GroupBy(e => e.Department)
            .Select(g => new {
                Department = g.Key,
                AverageSalary = g.Average(e => e.Salary)
            })
            .OrderByDescending(x => x.AverageSalary)
            .ToList();

        Console.WriteLine("Average salary by department:");
        Console.WriteLine("----------------------------");
        foreach (var dept in avgSalaryByDept)
        {
            Console.WriteLine($"{dept.Department}: {dept.AverageSalary:C}");
        }
    }
}