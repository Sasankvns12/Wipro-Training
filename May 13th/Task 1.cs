using System;
using System.Collections.Generic;
using System.Linq;
public class Employee
{
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public int Age { get; set; }
}
class Program
{
    public static void Main(string[] args)
    {
        Employee[] EmployeeArray =
        {
            new Employee() { EmployeeID = 1, EmployeeName = "John", Age = 18},
            new Employee() { EmployeeID = 2, EmployeeName = "Steve", Age = 21},
            new Employee() { EmployeeID = 3, EmployeeName = "Bill", Age = 25},
            new Employee() { EmployeeID = 4, EmployeeName = "Ram", Age = 31},
            new Employee() { EmployeeID = 5, EmployeeName = "Chris", Age = 35},
            new Employee() { EmployeeID = 6, EmployeeName = "Sasank", Age = 36},
            new Employee() { EmployeeID = 7, EmployeeName = "Pranati", Age = 37},
        };
        Employee[] Employees = new Employee[10];
        int i = 0;
        foreach(Employee employee in EmployeeArray)
        {
            if (employee.Age > 12 && employee.Age < 20)
            {
                Employees[i] = employee;
                System.Console.WriteLine(employee.EmployeeName);
                i++;
            }
        }



        // Method 2
        Employee[] teenagerEmployees = EmployeeArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();
        Employee bill = EmployeeArray.Where(s => s.EmployeeName == "Bill").FirstOrDefault();
        Employee Employee5 = EmployeeArray.Where(s => s.EmployeeID == 5).FirstOrDefault();
    }
}