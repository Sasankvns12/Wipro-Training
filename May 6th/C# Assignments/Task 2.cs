using System;
public class FindSumOfDigits
{
    public static void Main(string[] args)
    {
        Console.Write("Enter a number :");
        int number = int.Parse(Console.ReadLine());
        int sum = 0, remainder;
        while (number > 0)
        {
            remainder = number % 10;
            sum = sum + remainder;
            number = number / 10;
    }
    Console.WriteLine($" The Sum of Digits is {sum}");
    Console.ReadLine();
}
}