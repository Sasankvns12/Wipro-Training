using System;
using System.Collections;
public class Program
{
    public static void Main()
    {
        ArrayList EmployeeNames = new ArrayList();
        EmployeeNames.Add("Sasank");
        EmployeeNames.Add("Nikitha");
        EmployeeNames.Add("Pranati");
        EmployeeNames.Add("Srikar");
        EmployeeNames.Add("Gayathri");

        Console.WriteLine("Initial list of Employees: ");
        DisplayEmployees(EmployeeNames);

        string nametofind = "Pranati";
        bool exists = EmployeeNames.Contains(nametofind);
        Console.WriteLine($"\nIs '{nametofind}' in the list ? {(exists ? "Yes" : "No")}");
        if (EmployeeNames.Count >= 2)
        {
            string removedName = (string)EmployeeNames[1];
            EmployeeNames.RemoveAt(1);
            Console.WriteLine($"\n Removed the second Employee : {removedName}");
        }
        Console.WriteLine("\n Total number of Employees : " + 4);
        DisplayEmployees(EmployeeNames);
    }
    public static void DisplayEmployees(ArrayList Employees)
    {
        foreach (string name in Employees)
        {
            Console.WriteLine($" -  {name}  ");
        }
    }
}