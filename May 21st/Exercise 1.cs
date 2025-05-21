using System;
class TowerOfHanoi
{
    public static void Solve(int n, char fromRod, char toRod, char auxRod)
    {
        if(n == 1)
        {
            Console.WriteLine($"Move disk 1 from {fromRod} to {toRod}");
            return;
        }
        Solve(n - 1, fromRod, toRod, auxRod);
        Console.WriteLine($"Move disk {n} from {fromRod} to {toRod}");
        Solve(n - 1, fromRod, toRod, auxRod);
    }
    static void Main()
    {
        int n = 3;
        char source = 'A', destination = 'B', auxiliary = 'C';
        Console.WriteLine($"Tower of Hanoi for {n} disks :");
        Solve(n, source, destination, auxiliary);
    }
}