using System;
namespace Linq_practice;
delegate void CustomDel(string s);
class TestClass
{
    public static void Hello(string s)
    {
        Console.WriteLine($" Hello, {s}!");
    }
    public static void Main()
    {
        CustomDel hiDel;
        hiDel = Hello;
        Console.WriteLine("Invoking delegate hiDel :");
        hiDel("A");
    }
}