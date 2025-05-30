using System;
using System.Collections.Generic;
using System.Linq;

public enum ItemType { Electronics, Clothing, Grocery, Furniture, Books }

public class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public Item(string name, ItemType type, int stock, decimal price)
    {
        Name = name;
        Type = type;
        Stock = stock;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name,-15} | {Type,-10} | {Stock,5} | {Price,10:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create and populate the item list
        List<Item> items = new List<Item>
        {
            new Item("Laptop", ItemType.Electronics, 5, 999.99m),
            new Item("T-Shirt", ItemType.Clothing, 20, 19.99m),
            new Item("Milk", ItemType.Grocery, 50, 3.49m),
            new Item("Desk", ItemType.Furniture, 3, 249.99m),
            new Item("Novel", ItemType.Books, 10, 12.99m),
            new Item("Smartphone", ItemType.Electronics, 8, 799.99m),
            new Item("Jeans", ItemType.Clothing, 15, 49.99m),
            new Item("Bread", ItemType.Grocery, 30, 2.99m),
            new Item("Chair", ItemType.Furniture, 7, 89.99m),
            new Item("Textbook", ItemType.Books, 4, 59.99m),
            new Item("Headphones", ItemType.Electronics, 2, 149.99m),
            new Item("Jacket", ItemType.Clothing, 3, 79.99m),
            new Item("Eggs", ItemType.Grocery, 40, 4.99m),
            new Item("Sofa", ItemType.Furniture, 1, 599.99m),
            new Item("Magazine", ItemType.Books, 25, 5.99m)
        };

        Console.WriteLine("Complete Inventory:");
        Console.WriteLine("============================================");
        Console.WriteLine("Name           | Type       | Stock |      Price");
        Console.WriteLine("--------------------------------------------");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        // 1. Filter low stock items (stock < 5)
        var lowStockItems = items.Where(i => i.Stock < 5).ToList();
        Console.WriteLine("\nLow Stock Items (Stock < 5):");
        Console.WriteLine("--------------------------------------------");
        foreach (var item in lowStockItems)
        {
            Console.WriteLine(item);
        }

        // 2. Group items by Type
        var itemsByType = items.GroupBy(i => i.Type)
                               .OrderBy(g => g.Key);

        Console.WriteLine("\nItems Grouped by Type:");
        Console.WriteLine("============================================");
        foreach (var group in itemsByType)
        {
            Console.WriteLine($"\n{group.Key}:");
            Console.WriteLine("--------------------------------------------");
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }
        }

        // 3. Find highest priced item in each group
        var highestPricedInEachGroup = items
            .GroupBy(i => i.Type)
            .Select(g => g.OrderByDescending(i => i.Price).First());

        Console.WriteLine("\nHighest Priced Item in Each Category:");
        Console.WriteLine("============================================");
        foreach (var item in highestPricedInEachGroup)
        {
            Console.WriteLine($"{item.Type,-10}: {item.Name} at {item.Price:C}");
        }
    }
}