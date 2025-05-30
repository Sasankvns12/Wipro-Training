using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public override string ToString()
    {
        return $"{Name} - ${Price}";
    }
}
class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200.50m },
            new Product { Name = "Mouse", Price = 25.99m },
            new Product { Name = "Monitor", Price = 350.00m },
            new Product { Name = "Keyboard", Price = 85.75m },
            new Product { Name = "SmartPhone", Price = 799.99m }
        };
        Console.WriteLine("All Products :");
        foreach(var product in products)
        {
            Console.WriteLine(product);
        }
        var expensiveProducts = products.Where(p => p.Price > 500).ToList();
        Console.WriteLine("\nProducts with Price > $500 :");
        foreach(var Product in expensiveProducts)
        {
            Console.WriteLine(Product);
        }
    }
}
