using System;

class Program
{
    static void Main()
    {
        int[] array = {10, 25, 30, 5, 60};
        int max = int.MinValue;
        int secondMax = int.MinValue;

        foreach (int num in array)
        {
            if (num > max)
            {
                secondMax = max;
                max = num;
            }
            else if (num > secondMax && num != max)
            {
                secondMax = num;
            }
        }

        Console.WriteLine("Second Largest Element: " + secondMax);
    }
}
