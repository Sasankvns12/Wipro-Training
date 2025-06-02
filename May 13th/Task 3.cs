using System;
namespace Linq_practice;
delegate void CustomDel(string s);
class TestClass
{
    public static void Hello(string s)
    {
        Console.WriteLine($" Hello, {s}!");
    }
    public static void GoodBye(string s)
    {
        Console.WriteLine($" GoodBye, {s}!");
    }
    public static void Main()
    {
        CustomDel hiDel, byeDel, multiDel;
        hiDel = Hello;
        byeDel = GoodBye;
        multiDel = hiDel + byeDel;
        Console.WriteLine("Invoking delegate hiDel :");
        hiDel("A");
        Console.WriteLine("Invoking delegate byeDel :");
        byeDel("B");
        Console.WriteLine("Invoking delegate multiDel :");
        multiDel("C");
    }
}