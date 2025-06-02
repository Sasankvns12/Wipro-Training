using System;
public abstract class Book
{
    public abstract void Read();
    public void GetInfo()
    {
        Console.WriteLine("This is a book");
    }
}
class FictionBook : Book
{
    public override void Read()
    {
        Console.WriteLine("Reading a fiction book");
    }
}
class ScienceBook : Book
{
    public override void Read()
    {
        Console.WriteLine("Reading a science book");
    }
}
class Program
{
    public static void Main()
    {
        Book FictionBook = new FictionBook();
        Book ScienceBook = new ScienceBook();
        Console.WriteLine("Fiction Book :");
        FictionBook.GetInfo();
        FictionBook.Read();
        Console.WriteLine("\nScience Book :");
        ScienceBook.GetInfo();
        ScienceBook.Read();
    }
}
