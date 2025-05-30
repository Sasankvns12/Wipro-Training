using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Stack<string> books = new Stack<string>();
        books.Push("C# Programming");
        books.Push("Data Structures");
        books.Push("Machine Learning");

        Console.WriteLine("Books in the stack");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
        Console.WriteLine("\n Popped : " + books.Pop());
        Console.WriteLine("Next on the stack: " + books.Peek());

    }
}