using System;
namespace Linq_practice;
class SimpleDelegate
{
    public delegate int SomeOperation(int i, int j);
    class Program
    {
        static int Sum(int x , int y)
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            SomeOperation add = Sum;
            int result = add(10, 10);
            Console.WriteLine(result);
        }
    }
}



    // Method 2
    class Function
   {
    static int Sum(int x , int y)
    {
        return x + y;
    }
    static void Main(string[] args)
    {
        Func<int , int , int> add = Sum;
        int result = add(10, 10);
        Console.WriteLine(result);
    }
   }

