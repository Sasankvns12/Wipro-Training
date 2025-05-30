using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
class Product
{
    public int ID { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public override string ToString()
    {
        return $"ID: {ID}, Name: {name}, Price: {price}";
            }
}
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();
        products.Add(new Product { ID = 1, name = "Laptop", price = 999.99m });
        products.Add(new Product { ID = 2, name = "Smartphone", price = 699.99m });
        products.Add(new Product { ID = 3, name = "Headphone", price = 149.99m });
        products.Add(new Product { ID = 4, name = "Tablet", price = 349.99m });
        products.Add(new Product { ID = 5, name = "Smartwatch", price = 199.99m });
        products = products.OrderByDescending(p => p.price).ToList();
        Console.WriteLine("Products by price :");
        foreach(var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("\n Product with highest price");
        Console.WriteLine(products[0]);


    }
}