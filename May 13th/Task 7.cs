using System;
public interface IOrder
{
    public void PlaceOrder(string item);
    public void CancelOrder(string item);
  
}
class DineInOrder : IOrder
{
    public void PlaceOrder(string item)
    {
        Console.WriteLine("Placing dine-in order for item");
    }
    public void CancelOrder(string item)
    {
        Console.WriteLine("Canceling dine-in order for item");
    }
}
class TakeawayOrder : IOrder
{
    public void PlaceOrder(string item)
    {
        Console.WriteLine("Placing takeaway order for item");
    }
    public void CancelOrder(string item)
    {
        Console.WriteLine("Canceling takeaway order for item");
    }
}
class Program
{
    public static void Main()
    {
        IOrder DineInOrder = new DineInOrder();
        IOrder TakeawayOrder = new TakeawayOrder();

        string foodItem = "Burger";
        string drinkItem = "Soda";

        Console.WriteLine("DineInOrder Processing :");
        DineInOrder.PlaceOrder(foodItem);
        DineInOrder.CancelOrder(drinkItem);
        Console.WriteLine("\nTakeawayOrder Processing :");
        TakeawayOrder.PlaceOrder(foodItem);
        TakeawayOrder.CancelOrder(drinkItem);
    }
}
