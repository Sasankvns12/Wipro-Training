using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public Dictionary<string, int> SubjectMarks { get; set; } = new Dictionary<string, int>();
    
    public double Average => SubjectMarks.Values.Average();
    public int Highest => SubjectMarks.Values.Max();
    public int Lowest => SubjectMarks.Values.Min();
    public int Total => SubjectMarks.Values.Sum();

    public Student(string name)
    {
        Name = name;
    }

    public void AddMark(string subject, int mark)
    {
        SubjectMarks[subject] = mark;
    }

    public void DisplayResults()
    {
        Console.WriteLine($"\nStudent: {Name}");
        Console.WriteLine($"Subjects: {string.Join(", ", SubjectMarks.Keys)}");
        Console.WriteLine($"Total Marks: {Total}");
        Console.WriteLine($"Average: {Average:F2}");
        Console.WriteLine($"Highest Mark: {Highest}");
        Console.WriteLine($"Lowest Mark: {Lowest}");
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.WriteLine("Student Marks Analysis System");
        Console.WriteLine("----------------------------");

        while (true)
        {
            Console.Write("\nEnter student name (or 'done' to finish): ");
            string name = Console.ReadLine();
            
            if (name.ToLower() == "done")
                break;

            var student = new Student(name);

            while (true)
            {
                Console.Write($"Enter subject name for {name} (or 'done' to finish): ");
                string subject = Console.ReadLine();
                
                if (subject.ToLower() == "done")
                    break;

                Console.Write($"Enter marks for {subject}: ");
                if (int.TryParse(Console.ReadLine(), out int marks))
                {
                    student.AddMark(subject, marks);
                }
                else
                {
                    Console.WriteLine("Invalid marks. Please enter a number.");
                }
            }

            students.Add(student);
        }

        // Display individual student results
        Console.WriteLine("\nIndividual Student Results:");
        Console.WriteLine("--------------------------");
        foreach (var student in students)
        {
            student.DisplayResults();
        }

        // Find top 3 scorers using LINQ
        var topScorers = students
            .OrderByDescending(s => s.Average)
            .Take(3)
            .ToList();

        Console.WriteLine("\nTop 3 Scorers:");
        Console.WriteLine("-------------");
        for (int i = 0; i < topScorers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {topScorers[i].Name} - Average: {topScorers[i].Average:F2}");
        }
    }
}