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
            int choice = 0;
            string[] details;
           

            MultipleAddressBooks multipleAddressBooks = new MultipleAddressBooks();
            Address_Book addressBook = null;

            Console.WriteLine("Welcome to Address Book Program");
            while (true)
            {   
                bool flag = true;
                Console.WriteLine("1.Add Address Book\n2.Open Address Book");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter name of Address Book");
                name = Console.ReadLine();
                if (choice == 1)
                {
                    multipleAddressBooks.AddAddressBook(name);
                    addressBook = multipleAddressBooks.GetAddressBook(name);
                }
                else if (choice == 2)
                {
                    addressBook = multipleAddressBooks.GetAddressBook(name);
                    if (addressBook == null)
                    {
                        Console.WriteLine("No such Address Book");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }

                while (flag)
                {
                    if (addressBook == null)
                    {
                        break;
                    }
                    Console.WriteLine("1.Add Contact\n2.Edit Contact\n3.Remove a contact\n4.Exit");
                    choice = Convert.ToInt32(Console.ReadLine());

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
                            flag = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
