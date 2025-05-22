using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public override string ToString()
    {
        return $"{Name}";
    }
}
class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee {Name = "John", Department = "IT"},
            new Employee {Name = "Sarah", Department = "HR"},
            new Employee {Name = "Mike", Department = "IT"},
            new Employee {Name = "Emily", Department = "Finance"},
            new Employee {Name = "David", Department = "HR"},
            new Employee {Name = "Lisa", Department = "Finance"},
        };
        var employeesByDepartment = employees.GroupBy(e => e.Department).OrderBy(g => g.Key);
        Console.WriteLine("Employees by Department :");
        foreach(var DepartmentGroup in employeesByDepartment)
        {
            Console.WriteLine($"\nDepartment : {DepartmentGroup.Key}");
            Console.WriteLine("Employees");
            foreach(var employee in DepartmentGroup)
            {
                Console.WriteLine($"- {employee.Name}");
            }
        }
    }
}