using System;
public interface IAnimalActions
{
    public void Eat();
    public void Sleep();
}
class Lion : IAnimalActions
{
    public void Eat()
    {
        Console.WriteLine("Lion is eating meat");
    }
    public void Sleep()
    {
        Console.WriteLine("Lion is sleeping");
    }
}
class Elephant : IAnimalActions
{
    public void Eat()
    {
        Console.WriteLine("Elephant is eating grass");
    }
    public void Sleep()
    {
        Console.WriteLine("Elephant is sleeping");
    }
}
class Program
{
    public static void Main()
    {
        IAnimalActions Lion = new Lion();
        IAnimalActions Elephant = new Elephant();
        Console.WriteLine("Lion Actions :");
        Lion.Eat();
        Lion.Sleep();
        Console.WriteLine("\nElephant Actions :");
        Elephant.Eat();
        Elephant.Sleep();
    }
}
