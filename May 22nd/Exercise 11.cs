using System;
using System.Collections.Generic;
using System.Linq;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = true;
    public override string ToString()
    {
        return $"{Title} by {Author} (ID : {Id}) - {(IsAvailable ? "Available" : "Checked Out")}";

    }
}
public class Library
{
    private List<Book> books = new List<Book>();
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Added book : {book.Title}");

    }
    public List<Book> SearchByAuthor(string Author)
    {
        return books.Where(b => b.Author.Equals(Author, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public List<Book> SearchByTitle(string Title)
    {
        return books.Where(b => b.Title.Contains(Title, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public void DisplayBooks(List<Book> booksToDisplay)
    {
        if(booksToDisplay.Count == 0)
        {
            Console.WriteLine("No Books Found");
            return;
        }
        foreach(var book in booksToDisplay)
        {
            Console.WriteLine(book);
        }
    }

}
class Program
{
    static void Main()
    {
        Library library = new Library();
        library.AddBook(new Book { Id = 1, Title = "To Kill a MockingBird", Author = "Harper Lee" });
        library.AddBook(new Book { Id = 2, Title = "1984", Author = "George Orwell" });
        library.AddBook(new Book { Id = 3, Title = "The Great GatsBy", Author = "F. Scott Fitzgerald" });
        library.AddBook(new Book { Id = 4, Title = "Animal Farm", Author = "George Orwell", IsAvailable = false });
        library.AddBook(new Book { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen" });
        Console.WriteLine("\nSearching for books by George Orwell :");
        var orwellBooks = library.SearchByAuthor("George Orwell");
        library.DisplayBooks(orwellBooks);
        Console.WriteLine("\nSearching for books in Great in Title :");
        var greatBooks = library.SearchByTitle("Great");
        library.DisplayBooks(greatBooks);
    }
}