using System;
public abstract class Animal
{
    public abstract void MakeSound();
    public void Eat()
    {
        Console.WriteLine("Animal is Eating");
    }
}
class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Barks");
    }
}
class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meows");
    }
}
class Program
{
    public static void Main()
    {
        Animal Dog = new Dog();
        Animal Cat = new Cat();
        Console.WriteLine("Dog :");
        Dog.Eat();
        Dog.MakeSound();
        Console.WriteLine("\nCat :");
        Cat.Eat();
        Cat.MakeSound();
    }
}