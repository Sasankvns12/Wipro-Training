using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<int, string> students = new Dictionary<int, string>();
        students.Add(101, "Alice");
        students.Add(102, "Bob");
        students.Add(103, "Charlie");
        Console.WriteLine("Students with ID 102 : " + students[102]);
        foreach ( var pair in students)
        {
            Console.WriteLine($"ID : {pair.Key}, Name : {pair.Value} ");
        }
    }
}