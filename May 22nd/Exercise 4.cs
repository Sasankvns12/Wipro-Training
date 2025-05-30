using System;
using System.Collections.Generic;
using System.Linq;
public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
    public override string ToString()
    {
        return $"{Name} - {Marks} marks";
    }
}
class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Marks = 85 },
            new Student { Name = "Bob", Marks = 92 },
            new Student { Name = "Charlie", Marks = 78 },
            new Student { Name = "Diana", Marks = 95 },
            new Student { Name = "Ethan", Marks = 88 },
            new Student { Name = "Fiona", Marks = 79 },
        };
        Console.WriteLine("All Students :");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
        var topStudents = students.OrderByDescending(s => s.Marks).Take(3).ToList();
        Console.WriteLine("\nTop 3 Students :");
        foreach(var student in topStudents)
        {
            Console.WriteLine(student);
        }

    }
}