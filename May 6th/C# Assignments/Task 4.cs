using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write(" n = ");
        int rows = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= rows; i++)
        {
          for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}