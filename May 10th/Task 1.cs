using System;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public void ShowInfo()
    {
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Age : {Age}");
    }
}
class Student : Person
{
    public int RollNumber { get; set; }
    public void ShowStudentInfo()
    {
        ShowInfo();
        Console.WriteLine($"RollNumber : {RollNumber}");
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student();
        student.Name = "John Doe";
        student.Age = 20;
        student.RollNumber = 101;
        Console.WriteLine("Showing Student Information :");
        student.ShowStudentInfo();
    }
}