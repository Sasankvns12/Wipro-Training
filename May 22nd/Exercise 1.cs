using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        List<string> students = new List<string>();
        students.Add("Emma");
        students.Add("David");
        students.Add("Sophia");
        students.Add("James");
        students.Add("Olivia");
        Console.WriteLine("Original List of Students :");
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }
            students.Sort();
            Console.WriteLine("\nSorted List of Students :");
        foreach(string student in students)
        {
            Console.WriteLine(student);
        }
    }
}