using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Address_Book
    {
        List<Contacts> contactList;
        
        public Address_Book()
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
            foreach (Contacts c in contactList)
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
            foreach (Contacts c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
