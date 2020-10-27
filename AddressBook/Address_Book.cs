using CsvHelper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{
    class Address_Book
    {
        public List<Contacts> contactList;
        public Address_Book()
        {
            contactList = new List<Contacts>();
            
        }
        public string AddContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            if (CheckName(firstName, lastName) == false)
            {
                Contacts contact = new Contacts(firstName, lastName, address, city, state, zipCode, phoneNo, eMail);
                contactList.Add(contact);
                return "Details Added Successfully";
            }
            return "Name already exists";
        }
        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            foreach (Contacts c in contactList)
            {
                if (c.FirstName.Equals(firstName))
                {
                    c.LastName = lastName;
                    c.Address = address;
                    c.City = city;
                    c.State = state;
                    c.ZipCode = zipCode;
                    c.PhoneNo = phoneNo;
                    c.EMail = eMail;
                   
                    return;
                }
            }
        }
        public void RemoveContact(string firstName,string lastName)
        {
            foreach (Contacts c in contactList)
            {
                if (c.FirstName.Equals(firstName) && c.LastName.Equals(lastName))
                {
                    contactList.Remove(c);
                    
                    return;
                }
            }
        }
        public bool CheckName(string firstName, string lastName)
        {
            
            foreach(Contacts contact in contactList.FindAll(e => e.FirstName.Equals(firstName) && e.LastName.Equals(lastName)))
            {
                return true;
            }
            return false;
        }
        public List<Contacts> GetPersonByCityOrState(string cityOrState)
        {
            List<Contacts> contact = new List<Contacts>();
            foreach(Contacts c in contactList.FindAll(e => e.City.Equals(cityOrState) || e.State.Equals(cityOrState)))
            {
                    contact.Add(c);
            }
            return contact;
        }
        public void SortByName()
        {
            contactList.Sort((contact1,contact2)=>contact1.FirstName.CompareTo(contact2.FirstName));
            foreach(Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }
            
        }
        public void SortByCity()
        {
            contactList.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
            foreach (Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByState()
        {
            contactList.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
            foreach (Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        public void SortByZipCode()
        {
            contactList.Sort((contact1, contact2) => contact1.ZipCode.CompareTo(contact2.ZipCode));
            foreach (Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }

    }
}
