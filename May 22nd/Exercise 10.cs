using System;
using System.Collections.Generic;
public interface IAttendance
{
    void MarkAttendance();
}
public abstract class Staff
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string department { get; set; }
    public abstract decimal CalculateSalary();
    public override string ToString()
    {
        return $"{GetType().Name} - ID : {Id}, Name : {Name}, Department : {department}";
    } 
}
public class PermanentStaff : Staff, IAttendance
{
    public decimal BaseSalary { get; set; }
    public decimal Bonus { get; set; }
    public override decimal CalculateSalary()
    {
        return BaseSalary + Bonus;
    }
    public void MarkAttendance()
    {
        Console.WriteLine($"{Name} (Permanent) marked present with biometric scan");
    }
}
public class ContractStaff : Staff, IAttendance
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }
    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
    public void MarkAttendance()
    {
        Console.WriteLine($"{Name} (Contract) signed attendance register");
    }
}
class Program
{
    static void Main()
    {
        List<Staff> StaffList = new List<Staff>
        {
            new PermanentStaff
            {
                Id = 101,
                Name = "John Smith",
                department = "IT",
                BaseSalary = 5000,
                Bonus = 1000
            },
            new ContractStaff
            {
                Id = 102,
                Name = "Sarah Johnson",
                department = "HR",
                HourlyRate = 25,
                HoursWorked = 160
            },
            new PermanentStaff
            {
                Id = 103,
                Name = "Michael Brown",
                department = "Finance",
                BaseSalary = 6000,
                Bonus = 1500
            },
            new ContractStaff
            {
                Id = 104,
                Name = "Emily Davis",
                department = "Marketing",
                HourlyRate = 30,
                HoursWorked = 120
            }
        };
        foreach(var Staff in StaffList)
        {
            Console.WriteLine("\n" + Staff);
            if(Staff is IAttendance attendance)
            {
                attendance.MarkAttendance();
            }
            Console.WriteLine($"Salary :{Staff.CalculateSalary()}");
            if(Staff is PermanentStaff)
            {
                Console.WriteLine("Eligible for company benefits");
            }
            else if(Staff is ContractStaff)
            {
                Console.WriteLine("Contract ends after project completion");
            }
        }
    }
}