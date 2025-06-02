using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        phonebook.Add("John Doe", "123-456-7890");
        phonebook.Add("Jane Smith", "234-567-8901");
        phonebook.Add("Alice Johnson", "345-678-9012");
        phonebook.Add("Bob Brown", "456-789-0123");
        phonebook.Add("Charlie Davis", "567-890-1234");
        string nameToUpdate = "Jane Smith";
        if(phonebook.ContainsKey(nameToUpdate))
        {
            phonebook[nameToUpdate] = "999-888-7777";
            Console.WriteLine($"Updated {nameToUpdate}'s phone number");

        }
        else
        {
            Console.WriteLine($"{nameToUpdate} not found in contacts");
        }
        string nameToCheck = "Alice Johnson";
        if(phonebook.ContainsKey(nameToCheck))
        {
            Console.WriteLine($"{nameToCheck} exists in contacts");
        }
        else
        {
            Console.WriteLine($"{nameToCheck} does not exists in contacts");
        }

        Console.WriteLine("\n All Contacts");
        foreach(KeyValuePair<string, string> contact in phonebook)
        {
            Console.WriteLine($"{contact.Key} : {contact.Value}");
        }
    }
}