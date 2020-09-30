using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AddressBook
{
    class Contacts
    {
        string firstName,lastName,address,city,state,zipCode,phoneNo,eMail;

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
        public Contacts(string firstName,string lastName,string address,string city,string state,string zipCode,string phoneNo,string eMail)
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            string[] details;
            Console.WriteLine("Welcome to Address Book Program");
           
            Console.WriteLine("Enter the details separated by comma");
            Console.WriteLine("First Name, Last Name, Address, City, State, ZipCode, Email");
            details = Console.ReadLine().Split(",");

            addressBook.addContact(details[0],details[1],details[2],details[3],details[4],details[5],details[6],details[7]);

            Console.WriteLine("Details Added");
            

        }
    }
}
