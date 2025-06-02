using System;
using System.Collections.Generic;


public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public abstract void MakeSound();

    public void Feed()
    {
        Console.WriteLine($"Feeding {Name} the {GetType().Name}");
    }

    public override string ToString()
    {
        return $"{GetType().Name} - Name: {Name}, Age: {Age}";
    }
}


public class Lion : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} roars loudly: ROOOAR!");
    }
}

public class Elephant : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} trumpets: TOOOOT!");
    }
}

public class Monkey : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} chatters: OOH OOH AH AH!");
    }
}


public class Zoo
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
        Console.WriteLine($"Added {animal.Name} to the zoo");
    }

    public void PerformDailyRoutine()
    {
        Console.WriteLine("\nZoo Daily Routine:");
      

        foreach (var animal in animals)
        {
            Console.WriteLine($"\nWorking with {animal.Name}:");
            animal.MakeSound();
            animal.Feed();
        }

        Console.WriteLine("\nAll animals have been cared for today!");
    }
}

class Program
{
    static void Main()
    {
       
        Zoo cityZoo = new Zoo();

       
        cityZoo.AddAnimal(new Lion { Name = "Simba", Age = 5 });
        cityZoo.AddAnimal(new Elephant { Name = "Dumbo", Age = 10 });
        cityZoo.AddAnimal(new Monkey { Name = "George", Age = 3 });
        cityZoo.AddAnimal(new Lion { Name = "Nala", Age = 4 });

       
        cityZoo.PerformDailyRoutine();
    }
}