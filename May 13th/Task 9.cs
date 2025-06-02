using System;
public abstract class Employee
{
    public abstract void CalculateSalary();
    public void ShowBasicInfo()
    {
        Console.WriteLine("Employee Details");
    }
}
class FullTimeEmployee : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Salary : Basic + Allowance");
    }
}
class PartTimeEmployee : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Salary : Hourly rate x Hours worked");
    }
}
class Program
{
    public static void Main()
    {
        Employee FullTimeEmployee = new FullTimeEmployee();
        Employee PartTimeEmployee = new PartTimeEmployee();
        Console.WriteLine("Full-Time Salary :");
        FullTimeEmployee.ShowBasicInfo();
        FullTimeEmployee.CalculateSalary();
        Console.WriteLine("\nPart-Time Salary :");
        PartTimeEmployee.ShowBasicInfo();
        PartTimeEmployee.CalculateSalary();
    }
}