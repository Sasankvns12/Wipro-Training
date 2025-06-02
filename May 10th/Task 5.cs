using System;
class AreaCalculaor
{
    public static double Area(double length, double breadth)
    {
        return length * breadth;
    }
    public static double Area(double radius)
    {
        return Math.PI * radius * radius;
    }
    public static double Area(double baseLength, double height,string shape)
    {
        return 0.5 * baseLength * height;
    }
    public static void Main(string[] args)
    {
        double rectangleArea = Area(4.5, 5.2);
        Console.WriteLine($"Area of Rectangle (4.5 x 5.2) = {rectangleArea:F2}");
        double circleArea = Area(3.0);
        Console.WriteLine($"Area of Circle (radius 3.0) = {circleArea:F2}");
        double triangleArea = Area(6.0, 4.0, "triangle");
        Console.WriteLine($"Area of Triangle (base 6, height 4) = {triangleArea:F2}");
    }
}