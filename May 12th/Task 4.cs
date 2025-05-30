abstract class Shape
{
    public abstract void Draw();
    public void Display()
    {
        Console.WriteLine("This is a shape");
    }
}
class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}
class Program
{
    public static void Main()
    {
        Circle circle = new Circle();
        circle.Draw();
    }
}