using System;
using System.ComponentModel;
class PowerCalculator
{
    public static int Power(int baseNum, int exponent)
    {
        int result = 1;
        for(int i = 0; i< exponent; i++)
        {
            result *= baseNum;

        }
        return result;
    }
    public static double Power(double baseNum, double exponent)
    {
        return Math.Pow(baseNum, exponent);
    }
    public static void Main(string[] args)
    {
        int intResult = Power(2, 3);
        Console.WriteLine($"2^3 = {intResult}");
        double doubleResult = Power(5.5, 2);
        Console.WriteLine($"5.5^2 = {doubleResult}");
    }
}