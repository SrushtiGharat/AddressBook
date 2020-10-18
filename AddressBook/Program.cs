using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AddressBook
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] name;
            int choice = 0;
            string[] details;
            bool flag = true;
            string addBookName = "";

            MultipleAddressBooks multipleAddressBooks = new MultipleAddressBooks();
            Address_Book addressBook = null;

            Console.WriteLine("Welcome to Address Book Program");
            while (true)
            {   
                
                Console.WriteLine("1.Add Address Book\n2.Open Address Book");
                choice = Convert.ToInt32(Console.ReadLine());
               
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        multipleAddressBooks.AddAddressBook(addBookName);
                        addressBook = multipleAddressBooks.GetAddressBook(addBookName);
                        flag = true;
                        break;
                    case 2:
                        Console.WriteLine("Enter name of Address Book");
                        addBookName = Console.ReadLine();
                        addressBook = multipleAddressBooks.GetAddressBook(addBookName);
                        flag = true;
                        if (addressBook == null)
                        {
                            Console.WriteLine("No such Address Book");
                            flag = false;
                        }
                        break;
                    default:
                        flag = false;
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                

                while (flag)
                {
                    
                    Console.WriteLine("1.Add Contact\n2.Edit Contact\n3.Remove a contact\n4.View Person By City\n5.View Person By State\n6.Exit");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the details separated by comma");
                            Console.WriteLine("First Name, Last Name, Address, City, State, ZipCode,Phone No Email");
                            details = Console.ReadLine().Split(",");

                            string message = addressBook.AddContact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);

                            Console.WriteLine(message);
                            
                            break;
                        case 2:
                            Console.WriteLine("Enter the name to edit");
                            name = Console.ReadLine().Split(" ");

                            if (addressBook.CheckName(name[0],name[1]) == true)
                            {
                                Console.WriteLine("Enter the following details separated by comma");
                                Console.WriteLine("FirstName,LastName,Address, City, State, ZipCode,Phone No Email");
                                details = Console.ReadLine().Split(",");
                                addressBook.EditContact(details[0], details[1], details[2], details[3], details[4], details[5],details[6],details[7]);
                                Console.WriteLine("Details editted successfully");
                            }
                            else
                            {
                                Console.WriteLine("No such contact found");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter the name to be removed");
                            name = Console.ReadLine().Split(" ");
                            if (addressBook.CheckName(name[0],name[1]) == true)
                            {
                                addressBook.RemoveContact(name[0],name[1]);
                                Console.WriteLine("Contact Removed Successfully");
                            }
                            else
                            {
                                Console.WriteLine("No such contact found");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Enter City");
                            string city = Console.ReadLine();
                            multipleAddressBooks.SetContactByCityDictionary();

                            multipleAddressBooks.ViewPersonsByCity(city);
                            break;
                        case 5:
                            Console.WriteLine("Enter State");
                            string state = Console.ReadLine();

                            multipleAddressBooks.SetContactByStateDictionary();
                            multipleAddressBooks.ViewPersonsByState(state);
                            break;
                       
                        case 6:
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
