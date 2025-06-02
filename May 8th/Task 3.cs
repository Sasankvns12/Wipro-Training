using System;
using System.Collections.Generic;
class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
}
public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student {ID = 1, Name = "Alice" },
            new Student {ID = 2, Name = "Bob" }
        };
        students.Add(new Student { ID = 3, Name = "Charlie" });

            foreach (var Student in students)
            {
                Console.WriteLine($"ID : {Student.ID}, Name:{Student.Name}");
            }
    }
}

       