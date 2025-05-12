using System;
using System.Data;
public interface ICalculator
{
    int Add(int a , int b);
    int Subtract(int a , int b);
    int Multiply(int a , int b);
    int Divide(int a , int b);
}
public class SimpleCalculator : ICalculator
{
    public int Add(int a , int b)
    {
        return a + b;
    }
    public int Subtract(int a , int b)
    {
        return a - b;
    }
    public int Multiply(int a , int b)
    {
        return a * b;
    }
    public int Divide(int a , int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot Divide by Zero");
        }
        return a / b;
    }
}
class Program
{
    public static void Main()
    {
        ICalculator calculator = new SimpleCalculator();
        int x = 10, y = 5;
        Console.WriteLine($"Addition : {x} + {y} = {calculator.Add(x , y)}");
        Console.WriteLine($"Subtraction : {x} - {y} = {calculator.Subtract(x , y)}");
        Console.WriteLine($"Multiplication : {x} * {y} = {calculator.Multiply(x , y)}");
        try
        {
            Console.WriteLine($"Division : {x} / {y} = {calculator.Divide(x , y)}");
            Console.WriteLine($"Division by zero test : {x} / 0 = {calculator.Divide(x , 0)}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error : {ex.Message}");
        }
    }
}
