using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        public int EmpId;
        public int Salary;
        public string name;
        public string department;
        public void PrintDetails()
        {
            Console.WriteLine($" EmpId : {EmpId}");
            Console.WriteLine($" Name : {name}");
            Console.WriteLine($" Department : {department}");
            Console.WriteLine($" Salary : {Salary}");
        }
        public void UpdateSalary(int newSalary)
        {
            Salary = newSalary;

        }
        public int AnnualSalary()
        {
            return Salary = 20;
        }
    }
}
