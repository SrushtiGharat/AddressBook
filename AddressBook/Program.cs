using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AddressBook
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            Address_Book addressBook = new Address_Book();
            
            string[] details;
            Console.WriteLine("Welcome to Address Book Program");
            while (true)
            {
                Console.WriteLine("1.Add Contact\n2.Edit Contact\n3.Remove a contact\n4.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Enter the details separated by comma");
                        Console.WriteLine("First Name, Last Name, Address, City, State, ZipCode, Email");
                        details = Console.ReadLine().Split(",");

                        addressBook.addContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);

                        Console.WriteLine("Details Added");
                        break;
                    case 2:
                        Console.WriteLine("Enter the name to edit");
                        name = Console.ReadLine();
                        
                        if (addressBook.checkName(name) == true)
                        {
                            Console.WriteLine("Enter the following details separated by comma");
                            Console.WriteLine("Last Name, Address, City, State, ZipCode, Email");
                            details = Console.ReadLine().Split(",");
                            addressBook.editContact(name, details[0], details[1], details[2], details[3], details[4], details[5], details[6]);
                            Console.WriteLine("Details editted successfully");
                        }
                        else
                        {
                            Console.WriteLine("No such contact found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the name to be removed");
                        name = Console.ReadLine();
                        if (addressBook.checkName(name) == true)
                        {
                            addressBook.RemoveContact(name);
                            Console.WriteLine("Contact Removed Successfully");
                        }
                        else
                        {
                            Console.WriteLine("No such contact found");
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
