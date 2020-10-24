using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public void RemoveContact(string firstName,string lastName)
        {
            foreach (Contacts c in contactList)
            {
                if (c.firstName.Equals(firstName) && c.lastName.Equals(lastName))
                {
                    contactList.Remove(c);
                    
                    return;
                }
            }
        }
        public bool CheckName(string firstName, string lastName)
        {
            
            foreach(Contacts contact in contactList.FindAll(e => e.firstName.Equals(firstName) && e.lastName.Equals(lastName)))
            {
                return true;
            }
            return false;
        }
        public List<Contacts> GetPersonByCityOrState(string cityOrState)
        {
            List<Contacts> contact = new List<Contacts>();
            foreach(Contacts c in contactList.FindAll(e => e.city.Equals(cityOrState) || e.state.Equals(cityOrState)))
            {
                    contact.Add(c);
            }
            return contact;
        }
        public void SortByName()
        {
            contactList.Sort((contact1,contact2)=>contact1.firstName.CompareTo(contact2.firstName));
            foreach(Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }
            
        }
        

    }
}
