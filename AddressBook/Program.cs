using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AddressBook
{
    class Contacts
    {
        public string firstName, lastName, address, city, state, zipCode, phoneNo, eMail;

        public Contacts()
        {
            firstName = "";
            lastName = "";
            address = "";
            city = "";
            state = "";
            zipCode = "";
            phoneNo = "";
            eMail = "";
        }
        public Contacts(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNo = phoneNo;
            this.eMail = eMail;
        }

    }
    class AddressBook
    {
        List<Contacts> contactList;
        public AddressBook()
        {
            contactList = new List<Contacts>();
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            Contacts contact = new Contacts(firstName, lastName, address, city, state, zipCode, phoneNo, eMail);
            contactList.Add(contact);
        }
        public void editContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            foreach (Contacts c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {   
                    c.lastName = lastName;
                    c.address = address;
                    c.city = city;
                    c.state = state;
                    c.zipCode = zipCode;
                    c.phoneNo = phoneNo;
                    c.eMail = eMail;
                    return;
                }
            }
        }
        public void RemoveContact(string name)
        {
            foreach(Contacts c in contactList)
            {
                if (c.firstName.Equals(name))
                {
                    contactList.Remove(c);
                    return;
                }
            }
        }
        public bool checkName(string firstName)
        {
            foreach(Contacts c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {
                    return true;
                }
            }
            return false;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            AddressBook addressBook = new AddressBook();
            
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
