using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = true;
    public Student BorrowedBy { get; set; } = null;
    public DateTime DueDate { get; set; }

    public Book(string isbn, string title, string author)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        string status = IsAvailable ? "Available" : $"Borrowed by {BorrowedBy.Name} (Due: {DueDate:yyyy-MM-dd})";
        return $"{Title} by {Author} (ISBN: {ISBN}) - {status}";
    }
}

public class Student
{
    public string ID { get; set; }
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();

    public Student(string id, string name)
    {
        ID = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name} (ID: {ID}) - Books borrowed: {BorrowedBooks.Count}";
    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private List<Student> students = new List<Student>();

    public void AddBook(string isbn, string title, string author)
    {
        if (books.Any(b => b.ISBN == isbn))
        {
            Console.WriteLine($"Book with ISBN {isbn} already exists.");
            return;
        }
        books.Add(new Book(isbn, title, author));
        Console.WriteLine($"Added book: {title} by {author}");
    }

    public void DeleteBook(string isbn)
    {
        var book = books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
        {
            Console.WriteLine($"Book with ISBN {isbn} not found.");
            return;
        }
        if (!book.IsAvailable)
        {
            Console.WriteLine($"Cannot delete - book is currently borrowed by {book.BorrowedBy.Name}.");
            return;
        }
        books.Remove(book);
        Console.WriteLine($"Deleted book: {book.Title}");
    }

    public void RegisterStudent(string id, string name)
    {
        if (students.Any(s => s.ID == id))
        {
            Console.WriteLine($"Student with ID {id} already registered.");
            return;
        }
        students.Add(new Student(id, name));
        Console.WriteLine($"Registered student: {name}");
    }

    public void BorrowBook(string studentId, string isbn, int daysToReturn = 14)
    {
        var student = students.FirstOrDefault(s => s.ID == studentId);
        var book = books.FirstOrDefault(b => b.ISBN == isbn);

        if (student == null)
        {
            Console.WriteLine($"Student with ID {studentId} not found.");
            return;
        }
        if (book == null)
        {
            Console.WriteLine($"Book with ISBN {isbn} not found.");
            return;
        }
        if (!book.IsAvailable)
        {
            Console.WriteLine($"Book is already borrowed by {book.BorrowedBy.Name}.");
            return;
        }

        book.IsAvailable = false;
        book.BorrowedBy = student;
        book.DueDate = DateTime.Now.AddDays(daysToReturn);
        student.BorrowedBooks.Add(book);

        Console.WriteLine($"{student.Name} has borrowed '{book.Title}'. Due date: {book.DueDate:yyyy-MM-dd}");
    }

    public void ReturnBook(string isbn)
    {
        var book = books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
        {
            Console.WriteLine($"Book with ISBN {isbn} not found.");
            return;
        }
        if (book.IsAvailable)
        {
            Console.WriteLine("This book is not currently borrowed.");
            return;
        }

        var student = book.BorrowedBy;
        student.BorrowedBooks.Remove(book);
        book.IsAvailable = true;
        book.BorrowedBy = null;

        Console.WriteLine($"{student.Name} has returned '{book.Title}'");
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("\nLibrary Books:");
        Console.WriteLine("--------------");
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void DisplayAllStudents()
    {
        Console.WriteLine("\nRegistered Students:");
        Console.WriteLine("-------------------");
        foreach (var student in students)
        {
            Console.WriteLine(student);
            if (student.BorrowedBooks.Any())
            {
                Console.WriteLine("  Borrowed Books:");
                foreach (var book in student.BorrowedBooks)
                {
                    Console.WriteLine($"  - {book.Title} (Due: {book.DueDate:yyyy-MM-dd})");
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Add some books
        library.AddBook("978-0061120084", "To Kill a Mockingbird", "Harper Lee");
        library.AddBook("978-0451524935", "1984", "George Orwell");
        library.AddBook("978-0743273565", "The Great Gatsby", "F. Scott Fitzgerald");

        // Register some students
        library.RegisterStudent("S1001", "Alice Johnson");
        library.RegisterStudent("S1002", "Bob Smith");
        library.RegisterStudent("S1003", "Carol Williams");

        // Borrow some books
        library.BorrowBook("S1001", "978-0061120084", 14);
        library.BorrowBook("S1002", "978-0451524935", 21);
        library.BorrowBook("S1003", "978-0743273565", 7);

        // Display current status
        library.DisplayAllBooks();
        library.DisplayAllStudents();

        // Return a book
        library.ReturnBook("978-0743273565");

        // Try to delete a borrowed book
        library.DeleteBook("978-0061120084");

        // Display updated status
        library.DisplayAllBooks();
        library.DisplayAllStudents();
    }
}