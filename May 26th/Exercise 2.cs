using System;
using System.Collections.Generic;
using System.Linq;
public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
    public char Grade { get; set; }
    public Student(string name, int marks, char grade)
    {
        Name = name;
        Marks = marks;
        Grade = grade;
    }
    public override string ToString()
    {
        return $"{Name} - Marks - {Marks}, Grade : {Grade}";
    }
}
class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student ("Alice", 85, 'B'),
            new Student ("Bob", 92, 'A' ),
            new Student ("Charlie", 78, 'C' ),
            new Student ("David", 95, 'A' ),
            new Student ("Eve", 88, 'B' ),
            new Student ("Frank", 65, 'D' ),
            new Student ("Grace", 79, 'A' ),
            new Student ("Henry", 82, 'B' ),
            new Student ("Ivy", 73, 'C' ),
            new Student ("Jack", 98, 'A' ),
        };
        var SortedByMarks = students.OrderByDescending(s => s.Marks);
        Console.WriteLine("Students sorted by marks (descending) :");
        foreach (var student in SortedByMarks)
        {
            Console.WriteLine(student);
        }
        Console.WriteLine();

        var GroupedByGrade = students.GroupBy(s => s.Grade);
        Console.WriteLine("Students Grouped by Grade :");
        foreach (var GradeGroup in GroupedByGrade.OrderBy(g => g.Key))
        {
            Console.WriteLine($"Grade {GradeGroup.Key} :");
            foreach(var student in GradeGroup)
            {
                Console.WriteLine($" {student}");
            }
        }
        Console.WriteLine();

        var Top3Students = students.OrderByDescending(s => s.Marks).Take(3);
        Console.WriteLine("Top 3 Students by marks :");
        foreach(var student in Top3Students)
        {
            Console.WriteLine(student);
        }
    }
}