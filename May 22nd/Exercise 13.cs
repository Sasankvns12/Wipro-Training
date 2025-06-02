using System;
using System.Collections.Generic;
using System.Linq;
public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
    public override string ToString()
    {
        return $"{Name} : {Marks}";
    }
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Marks = 85 },
            new Student { Name = "Bob", Marks = 72 },
            new Student { Name = "Charlie", Marks = 90 },
            new Student { Name = "Diana", Marks = 68 },
            new Student { Name = "Ethan", Marks = 78 },
        };
        Console.WriteLine("Student Marks :");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
        double averageMarks = students.Average(s => s.Marks);
        Console.WriteLine($"\nAverage Marks : {averageMarks :F2}");
        int aboveAverageCount = students.Count(s => s.Marks > averageMarks);
        Console.WriteLine($"Number of students above average : {aboveAverageCount}");
        var aboveAverageStudents = students.Where(s => s.Marks > averageMarks);
        Console.WriteLine("\nAbove Average Students :");
        foreach (var student in aboveAverageStudents)
        {
            Console.WriteLine(student);
        }
    }
}