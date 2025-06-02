using System;
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal Sound");
    }
}
class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}
class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Animal geniricAnimal = new Animal();
        Cat myCat = new Cat();
        Dog myDog = new Dog();
        Console.WriteLine("Direct Method Calls :");
        geniricAnimal.MakeSound();
        myCat.MakeSound();
        myDog.MakeSound();
        Console.WriteLine("\nPolymorphic Calls ;");
        Animal animal1 = new Cat();
        Animal animal2 = new Dog();
        animal1.MakeSound();
        animal2.MakeSound();
    }
}