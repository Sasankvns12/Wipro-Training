using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class student
    {
        class Student
        {
            public int RollNumber;
            public string Name;
            public int Marks;
            public void PrintDetails()
            {
                Console.WriteLine($"Roll Number : {RollNumber}");
                Console.WriteLine($"Name : {Name}");
                Console.WriteLine($"Marks : {Marks}");
            }
        }
    }
}
