using System;
using ConsoleApp1;
class Program
{
    public static void Main()
    {
        Employee emp1 = new Employee { EmpId = 101, Salary = 12000, name = "Pranati", department = "ECE" };
        emp1.PrintDetails();
        emp1.UpdateSalary(20000);
        Console.WriteLine("Updated Values\n");
        emp1.PrintDetails();
        int Annual = emp1.AnnualSalary();
        Console.WriteLine($"Annual Salary : {Annual}");
    }
}