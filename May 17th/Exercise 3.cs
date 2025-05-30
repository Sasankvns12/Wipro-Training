using System;
public abstract class Document
{
    public abstract void PrintContent();
    public void ShowDocumentType(string type)
    {
        Console.WriteLine($"Document Type : {type}");
    }
}
class WordDocument : Document
{
    public override void PrintContent()
    {
        Console.WriteLine("Printing Word Document");
    }
}
class PDFDocument : Document
{
    public override void PrintContent()
    {
        Console.WriteLine("Printing PDF Document");
    }
}
class Program
{
    public static void Main()
    {
        Document WordDocument = new WordDocument();
        Document PDFDocument = new PDFDocument();
        Console.WriteLine("Word Document :");
        WordDocument.ShowDocumentType("Word");
        WordDocument.PrintContent();
        Console.WriteLine("\nPDF Document :");
        PDFDocument.ShowDocumentType("PDF");
        PDFDocument.PrintContent();
    }
}