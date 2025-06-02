using System;
namespace ApplianceDemo
{
    public class Appliance
    {
        public virtual void Operate()
        {
            Console.WriteLine("Operating a generic appliance");
        }
    }
    public class WashingMachine : Appliance
    {
        public override void Operate()
        {
            Console.WriteLine("Washing Clothes");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Appliance genericAppliance = new Appliance();
            Console.WriteLine("Testing base class :");
            genericAppliance.Operate();
            Console.WriteLine();
            WashingMachine myWasher = new WashingMachine();
            Console.WriteLine("Testing derived class directly");
            myWasher.Operate();
            Console.WriteLine();
            Appliance applianceRef = new WashingMachine();
            Console.WriteLine("Testing Polymorphism(base reference to derived object):");
            applianceRef.Operate();
        }
    }
}