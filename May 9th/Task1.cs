using System;
class Animal
{
    public string Name;
    public string Species;
    public void DisplayAnimal()
    {
        Console.WriteLine($"Animal Name : {Name}");
        Console.WriteLine($"Species : {Species}");

    }

}
class Dog : Animal
{
    public string Breed;
    public void DisplayDog()
    {
        Console.WriteLine($"Breed : {Breed}");
    }
}
class Program
{
    public static void Main()
    {
        Dog myDog = new Dog();
        myDog.Name = "Buddy";
        myDog.Species = "Canine";
        myDog.Breed = "Labrador";
        myDog.DisplayAnimal();
        myDog.DisplayDog();
    }
}


