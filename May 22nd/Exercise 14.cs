using System;
using System.Collections.Generic;
using System.Linq;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.00 },
            new Product { Id = 2, Name = "SmartPhone", Price = 800.00 },
            new Product { Id = 3, Name = "Tablet", Price = 400.00 },
            new Product { Id = 4, Name = "Monitor", Price = 250.00 },
            new Product { Id = 5, Name = "Keyboard", Price = 50.00 },
            new Product { Id = 6, Name = "Mouse", Price = 30.00 },

        };
        var sortedProducts = products.OrderByDescending(p => p.Price);
        Console.WriteLine("Products sorted by price(descending) :\n");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Id : {product.Id}, Name : {product.Name}, Price : ${product.Price :F2} ");
        }
        
        
    }
}