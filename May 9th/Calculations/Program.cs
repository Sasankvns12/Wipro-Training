using ConsoleApp1;
using System;
class Program
{
    public static void Main()
    {
        Calculator Calc = new Calculator();
        Console.WriteLine("Addition");
        Console.WriteLine("5 + 3 = " + Calc.Add(5, 3));
        Console.WriteLine("3.5 + 2.7 = " + Calc.Add(3.5, 2.7));
        Console.WriteLine("9 + 2 + 3 = " + Calc.Add(9, 2, 3));

        Console.WriteLine("Subtraction");
        Console.WriteLine("5 - 3 = " + Calc.Sub(5, 3));
        Console.WriteLine("3.5 - 2.7 = " + Calc.Sub(3.5, 2.7));
        Console.WriteLine("9 - 2 - 3 = " + Calc.Sub(9, 2, 3));

        Console.WriteLine("Multiplication");
        Console.WriteLine("5 * 3 = " + Calc.Mul(5, 3));
        Console.WriteLine("3.5 * 2.7 = " + Calc.Mul(3.5, 2.7));
        Console.WriteLine("9 * 2 * 3 = " + Calc.Mul(9, 2, 3));
    }
}