using System;
using System.Collections.Generic;
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}
class Program
{
    static void Main()
    {
        Queue<Book> BorrowedBooks = new Queue<Book>();
        BorrowedBooks.Enqueue(new Book { Title = "To kill a MockingBird", Author = "Harper Lee" });
        BorrowedBooks.Enqueue(new Book { Title = "1984", Author = "George Orwell" });
        BorrowedBooks.Enqueue(new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" });
        BorrowedBooks.Enqueue(new Book { Title = "Pride and Prejudice", Author = "Jane Austen" });
        BorrowedBooks.Enqueue(new Book { Title = "The Hobbit", Author = "J.R.R. Tlokien" });
        Console.WriteLine("Next book to return : " + BorrowedBooks.Peek());
        Book returnedbook = BorrowedBooks.Dequeue();
        Console.WriteLine($"\nReturned Book : {returnedbook}\n");
        Stack<Book> newBooks = new Stack<Book>();
        newBooks.Push(new Book { Title = "Dune", Author = "Frank Herbert" });
        newBooks.Push(new Book { Title = "The Martian", Author = "Andy Weir" });
        newBooks.Push(new Book { Title = "Project Hail Mery", Author = "Andy Weir" });
        Console.WriteLine("Last Purchased Book : " + newBooks.Peek());
        Book ProcessedBook = newBooks.Pop();
        Console.WriteLine($"\nProcessed book : {ProcessedBook}\n");
        Console.WriteLine("Remaining Borrowed Books :");
        foreach(var book in BorrowedBooks)
        {
            Console.WriteLine(book);
        }
        Console.WriteLine("\nRemaining new books :");
        foreach(var book in newBooks)
        {
            Console.WriteLine(book);
        }
    }
}
