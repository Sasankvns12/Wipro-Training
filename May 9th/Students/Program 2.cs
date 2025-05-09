using System;
using ConsoleApp1;
class Program
{
    public static void Main()
    {
        Student student1 = new Student { RollNumber = 101, Name = "Neha", Marks = 90 };
        Student student2 = new Student { RollNumber = 102, Name = "Ravi", Marks = 75 };
        student1.PrintDetails();
        student2.PrintDetails();
    }
}
