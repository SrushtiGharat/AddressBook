using System;
using System.Collections.Generic;

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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            
        }
    }
}
