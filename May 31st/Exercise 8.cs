using System;
using System.Collections.Generic;

// Interface for printable objects
public interface IPrintable
{
    void Print();
}

// Abstract base class for invoices
public abstract class Invoice : IPrintable
{
    public string InvoiceNumber { get; }
    public DateTime InvoiceDate { get; }
    public string CustomerName { get; set; }
    public List<Product> Products { get; } = new List<Product>();
    public abstract decimal TaxRate { get; }
    public abstract decimal DiscountRate { get; }

    protected Invoice(string invoiceNumber, DateTime invoiceDate, string customerName)
    {
        InvoiceNumber = invoiceNumber;
        InvoiceDate = invoiceDate;
        CustomerName = customerName;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal CalculateSubtotal()
    {
        decimal subtotal = 0;
        foreach (var product in Products)
        {
            subtotal += product.Price * product.Quantity;
        }
        return subtotal;
    }

    public decimal CalculateTax()
    {
        return CalculateSubtotal() * TaxRate;
    }

    public decimal CalculateDiscount()
    {
        return CalculateSubtotal() * DiscountRate;
    }

    public abstract decimal CalculateTotal();

    public virtual void Print()
    {
        Console.WriteLine($"INVOICE: {InvoiceNumber}");
        Console.WriteLine($"Date: {InvoiceDate:yyyy-MM-dd}");
        Console.WriteLine($"Customer: {CustomerName}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Products:");
        Console.WriteLine("----------------------------------------");
        
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name,-20} {product.Quantity,5} x {product.Price,10:C} = {product.Price * product.Quantity,10:C}");
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Subtotal: {CalculateSubtotal(),30:C}");
        Console.WriteLine($"Discount ({DiscountRate:P0}): {CalculateDiscount(),24:C}");
        Console.WriteLine($"Tax ({TaxRate:P0}): {CalculateTax(),30:C}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"TOTAL: {CalculateTotal(),33:C}");
        Console.WriteLine("========================================");
    }
}

// Product class
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

// Retail invoice (higher tax, lower discount)
public class RetailInvoice : Invoice
{
    public override decimal TaxRate => 0.10m; // 10%
    public override decimal DiscountRate => 0.02m; // 2%

    public RetailInvoice(string invoiceNumber, DateTime invoiceDate, string customerName) 
        : base(invoiceNumber, invoiceDate, customerName) { }

    public override decimal CalculateTotal()
    {
        return CalculateSubtotal() + CalculateTax() - CalculateDiscount();
    }
}

// Wholesale invoice (lower tax, higher discount)
public class WholesaleInvoice : Invoice
{
    public override decimal TaxRate => 0.05m; // 5%
    public override decimal DiscountRate => 0.10m; // 10%

    public WholesaleInvoice(string invoiceNumber, DateTime invoiceDate, string customerName) 
        : base(invoiceNumber, invoiceDate, customerName) { }

    public override decimal CalculateTotal()
    {
        return CalculateSubtotal() + CalculateTax() - CalculateDiscount();
    }
}

class Program
{
    static void Main()
    {
        // Create a retail invoice
        var retailInvoice = new RetailInvoice("R-2023-001", DateTime.Now, "John Smith");
        retailInvoice.AddProduct(new Product("Laptop", 999.99m, 1));
        retailInvoice.AddProduct(new Product("Mouse", 24.99m, 2));
        retailInvoice.AddProduct(new Product("Keyboard", 49.99m, 1));
        
        Console.WriteLine("RETAIL INVOICE");
        Console.WriteLine("==============");
        retailInvoice.Print();
        Console.WriteLine();

        // Create a wholesale invoice
        var wholesaleInvoice = new WholesaleInvoice("W-2023-001", DateTime.Now, "ABC Corporation");
        wholesaleInvoice.AddProduct(new Product("Laptop", 899.99m, 10));
        wholesaleInvoice.AddProduct(new Product("Monitor", 199.99m, 5));
        wholesaleInvoice.AddProduct(new Product("Docking Station", 149.99m, 5));
        
        Console.WriteLine("WHOLESALE INVOICE");
        Console.WriteLine("================");
        wholesaleInvoice.Print();
    }
}