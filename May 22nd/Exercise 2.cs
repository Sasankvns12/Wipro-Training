using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<string, string> Contacts = new Dictionary<string, string>();
        Contacts.Add("John Doe", "555-1234");
        Contacts.Add("Jane Smith", "555-5678");
        Contacts.Add("Mike Johnson", "555-9012");
        Console.WriteLine("All Contacts :");
        foreach (KeyValuePair<string, string> Contact in Contacts)
        {
            Console.WriteLine($"Name : {Contact.Key}, PhoneNumber : {Contact.Value}");
        }
            Console.WriteLine("\nEnter a name to search :");
            string SearchName = Console.ReadLine();
            if (Contacts.TryGetValue(SearchName, out string PhoneNumber))
            {
                Console.WriteLine($"Phone Number for {SearchName} : {PhoneNumber}");
            }
            else
            {
                Console.WriteLine($"Contact '{SearchName}' not found");
            }
    }
}