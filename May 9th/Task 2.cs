using System;
using System.Data;
class Employee
{
    public virtual void Work()
    {
        Console.WriteLine("Employee is Working");
    }

}
class Manager : Employee
{
    public override void Work()
    {
        Console.WriteLine("Manager is Supervising");
    }
    
}
class Program
{
    public static void Main()
    {
        Employee emp = new Employee();
        emp.Work();
        Manager mgr =  new Manager();
        mgr.Work();
        Employee polyemp = new Manager();
        polyemp.Work();
    }
}