using System;
using System.Collections.Generic;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public override string ToString()
    {
        return $"{ Name} (${ Price})";
    }
}
public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal GetTotalPrice()
    {
        return Product.Price * Quantity;
    }
    public override string ToString()
    {
        return $"{Product} x {Quantity} = ${GetTotalPrice()}";
    }
}
public class ShoppingCart
{
    private List<CartItem> items = new List<CartItem>();
    public void AddItem(Product Product, int Quantity)
    {
        var existingItem = items.Find(item => item.Product.Id == Product.Id);
        if(existingItem != null)
        {
            existingItem.Quantity += Quantity;
        }
        else
        {
            items.Add(new CartItem { Product = Product, Quantity = Quantity });
        }
    }
    public void RemoveItem(int ProductId)
    {
        items.RemoveAll(item => item.Product.Id == ProductId);
    }
    public decimal GetCartTotal()
    {
        decimal total = 0;
        foreach(var item in items)
        {
            total += item.GetTotalPrice();
        }
        return total;
    }
    public void DisplayCart()
    {
        Console.WriteLine("Shopping Cart Contents :");
        foreach(var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"TOTAL : ${GetCartTotal()}\n");
    }
}
class Program
{
    static void Main()
    {
        Product laptop = new Product { Id = 1, Name = "Laptop", Price = 999.99m };
        Product mouse = new Product { Id = 2, Name = "Wireless Mouse", Price = 25.50m };
        Product keyboard = new Product { Id = 3, Name = "Mechanical Keyboard", Price = 89.99m };
        ShoppingCart Cart = new ShoppingCart();
        Cart.AddItem(laptop, 1);
        Cart.AddItem(mouse, 2);
        Cart.AddItem(keyboard, 1);
        Cart.AddItem(mouse, 1);
        Cart.DisplayCart();
        Console.WriteLine("Removing wireless mouse\n");
        Cart.RemoveItem(2);
        Cart.DisplayCart();
    }
}