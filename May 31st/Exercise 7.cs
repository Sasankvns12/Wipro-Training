using System;

class Calculator
{
    // Overloaded Add methods
    public int Add(int a, int b) => a + b;
    public float Add(float a, float b) => a + b;
    public double Add(double a, double b) => a + b;

    // Overloaded Subtract methods
    public int Subtract(int a, int b) => a - b;
    public float Subtract(float a, float b) => a - b;
    public double Subtract(double a, double b) => a - b;

    // Overloaded Multiply methods
    public int Multiply(int a, int b) => a * b;
    public float Multiply(float a, float b) => a * b;
    public double Multiply(double a, double b) => a * b;

    public void PerformOperation()
    {
        Console.WriteLine("Available operations: Add, Subtract, Multiply");
        Console.Write("Enter operation name: ");
        string operation = Console.ReadLine();

        Console.WriteLine("Available data types: int, float, double");
        Console.Write("Enter data type: ");
        string type = Console.ReadLine();

        Console.Write("Enter first number: ");
        dynamic num1 = GetInput(type);
        Console.Write("Enter second number: ");
        dynamic num2 = GetInput(type);

        try
        {
            dynamic result = operation.ToLower() switch
            {
                "add" => Add(num1, num2),
                "subtract" => Subtract(num1, num2),
                "multiply" => Multiply(num1, num2),
                _ => throw new InvalidOperationException("Unknown operation")
            };

            Console.WriteLine($"Result: {result} ({result.GetType().Name})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private dynamic GetInput(string type)
    {
        string input = Console.ReadLine();
        return type.ToLower() switch
        {
            "int" => int.Parse(input),
            "float" => float.Parse(input),
            "double" => double.Parse(input),
            _ => throw new ArgumentException("Invalid data type")
        };
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        
        while (true)
        {
            Console.WriteLine("\nCalculator Menu");
            Console.WriteLine("1. Perform operation");
            Console.WriteLine("2. Exit");
            Console.Write("Choose option: ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                calc.PerformOperation();
            }
            else if (choice == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}