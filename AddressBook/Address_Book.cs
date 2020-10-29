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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Address_Book()
        {
            contactList = new List<Contacts>();

        }
        /// <summary>
        /// Add a new Contact to Address Book
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="phoneNo"></param>
        /// <param name="eMail"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Edit a already existing contact in Address Book
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="phoneNo"></param>
        /// <param name="eMail"></param>
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
        /// <summary>
        /// Remove a contact from address book
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void RemoveContact(string firstName, string lastName)
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
        /// <summary>
        /// Check if a name is present in address book
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>Returns true if present else false</returns>
        public bool CheckName(string firstName, string lastName)
        {
            foreach (Contacts contact in contactList.FindAll(e => e.FirstName.Equals(firstName) && e.LastName.Equals(lastName)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Get a list of contacts in address book by city or set
        /// </summary>
        /// <param name="cityOrState"></param>
        /// <returns>List Of Contacts</returns>
        public List<Contacts> GetPersonByCityOrState(string cityOrState)
        {
            List<Contacts> contact = new List<Contacts>();
            foreach (Contacts c in contactList.FindAll(e => e.City.Equals(cityOrState) || e.State.Equals(cityOrState)))
            {
                contact.Add(c);
            }
            return contact;
        }
        /// <summary>
        /// Sort the contacts in address book by name
        /// </summary>
        public void SortByName()
        {
            contactList.Sort((contact1, contact2) => contact1.FirstName.CompareTo(contact2.FirstName));
            foreach (Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        /// <summary>
        /// Sort the contacts in address book by city
        /// </summary>
        public void SortByCity()
        {
            contactList.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
            foreach (Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        /// <summary>
        /// Sort the contacts in address book by state
        /// </summary>
        public void SortByState()
        {
            contactList.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
            foreach (Contacts c in contactList)
            {
                Console.WriteLine(c.ToString());
            }

        }
        /// <summary>
        /// Sort the contacts in address book by ZipCode
        /// </summary>
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
