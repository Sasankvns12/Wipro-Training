using System;
public abstract class FoodOrder
{
    public abstract void PlaceOrder(string item);
    public void OrderInfo()
    {
        Console.WriteLine("Placing Food Order");
    }
}
class FastFoodOrder : FoodOrder
{
    public override void PlaceOrder(string item)
    {
        Console.WriteLine("Order placed for[item] at FastFood Outlet");
    }
}
class FineDiningOrder : FoodOrder
{
    public override void PlaceOrder(string item)
    {
        Console.WriteLine("Order placed for[item] at FineDining Restaurant");
    }
}
class Program
{
    public static void Main()
    {
        FoodOrder FastFoodOrder = new FastFoodOrder();
        FoodOrder FineDiningOrder = new FineDiningOrder();
        Console.WriteLine("FastFood Order :");
        FastFoodOrder.OrderInfo();
        FastFoodOrder.PlaceOrder("CheeseBurger Meal");
        Console.WriteLine("\nFineDining Order :");
        FineDiningOrder.OrderInfo();
        FineDiningOrder.PlaceOrder("Filet Mignon with Truffle Sauce");
    }
}