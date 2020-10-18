﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AddressBook
{
    class MultipleAddressBooks
    {
        Dictionary<string, Address_Book> addressBooksCollection = new Dictionary<string, Address_Book>();
        public Dictionary<string, List<Contacts>> ContactByCity;
        Dictionary<string, List<Contacts>> ContactByState;
        List<string> cities;
        List<string> states;
        public MultipleAddressBooks()
        {
            addressBooksCollection = new Dictionary<string, Address_Book>();
            ContactByCity = new Dictionary<string, List<Contacts>>();
            ContactByState = new Dictionary<string, List<Contacts>>();
            cities = new List<string>();
            states = new List<string>();

        }
        public void AddAddressBook(string name)
        {
            Address_Book addressBook = new Address_Book();
            if (addressBooksCollection.ContainsKey(name)==false)
            {
                addressBooksCollection.Add(name, addressBook);
                Console.WriteLine("Address Book Added Successfully");
            }
            else
            {
                Console.WriteLine("Address Book Already Exist");
            }

        }
        public Address_Book GetAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name))
            {
                return addressBooksCollection[name];
            }
            return null;
        }
        public void GetDistinctCityAndStateList()
        {
            foreach (var addressBook in addressBooksCollection)
            {
                foreach (var contact in addressBook.Value.contactList)
                {
                    if (cities.Contains(contact.city) == false)
                    {
                        cities.Add(contact.city);
                    }
                    if (states.Contains(contact.state) == false)
                    {
                        states.Add(contact.state);
                    }

                }
            }
        }
        public void SetContactByCityDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string city in cities)
            {
                List<Contacts> contacts = new List<Contacts>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetPersonByCityOrState(city));
                }
                if (ContactByCity.ContainsKey(city))
                {
                    ContactByCity[city] = contacts;
                }
                else
                {
                    ContactByCity.Add(city, contacts);
                }
            }

        }
        public void SetContactByStateDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string state in states)
            {
                List<Contacts> contacts = new List<Contacts>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetPersonByCityOrState(state));
                }
                if (ContactByState.ContainsKey(state))
                {
                    ContactByState[state] = contacts;
                }
                else
                {
                    ContactByState.Add(state, contacts);
                }
            }

        }
        public void ViewPersonsByCity(string city)
        {
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Contacts contact in ContactByCity[city])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zipCode + "\nPhone No :" + contact.phoneNo + "   Email :" + contact.eMail);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        public void ViewPersonsByState(string state)
        {
            if (ContactByState.ContainsKey(state))
            {
                foreach (Contacts contact in ContactByState[state])
                {
                    Console.WriteLine("Name :" + contact.firstName + " " + contact.lastName + "\nAddress :" + contact.address + "   ZipCode :" + contact.zipCode + "\nPhone No :" + contact.phoneNo + "   Email :" + contact.eMail);
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }

    }
}
