using System;
public class shape
{
    public virtual void draw()
    {
        Console.WriteLine("Dreawing a generic shape");
    }
    public class Circle : shape
    {
        public override void draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            shape shape = new Circle();
            shape.draw();
        }
    }
}


