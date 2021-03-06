﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AddressBook
{
    class MultipleAddressBooks
    {

        /// <summary>
        ///Defining variables and collections used
        /// </summary>
        Dictionary<string, Address_Book> addressBooksCollection = new Dictionary<string, Address_Book>();
        public Dictionary<string, List<Contacts>> ContactByCity;
        public Dictionary<string, List<Contacts>> ContactByState;
        List<string> cities;
        List<string> states;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MultipleAddressBooks()
        {
            addressBooksCollection = new Dictionary<string, Address_Book>();
            ContactByCity = new Dictionary<string, List<Contacts>>();
            ContactByState = new Dictionary<string, List<Contacts>>();
            cities = new List<string>();
            states = new List<string>();

        }
        /// <summary>
        /// Add a new address book
        /// </summary>
        /// <param name="name"></param>
        public void AddAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name) == false)
            {
                Address_Book addressBook = new Address_Book();
                addressBooksCollection.Add(name, addressBook);
            }
            else
            {
                Console.WriteLine("Address Book Already Exist");
            }

        }
        /// <summary>
        /// Get the object of the address book to perform operations on
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Address_Book object</returns>
        public Address_Book GetAddressBook(string name)
        {
            if (this.addressBooksCollection.ContainsKey(name))
            {
                return this.addressBooksCollection[name];
            }
            return null;
        }
        /// <summary>
        /// Get a list distinct list of cities and state in all address books
        /// </summary>
        public void GetDistinctCityAndStateList()
        {
            foreach (var addressBook in addressBooksCollection)
            {
                foreach (var contact in addressBook.Value.contactList)
                {
                    if (cities.Contains(contact.City) == false)
                    {
                        cities.Add(contact.City);
                    }
                    if (states.Contains(contact.State) == false)
                    {
                        states.Add(contact.State);
                    }

                }
            }
        }
        /// <summary>
        /// Set the city to contacts dictionary
        /// </summary>
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
        /// <summary>
        /// Set the state to contacts dictionary
        /// </summary>
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
        /// <summary>
        /// View all the contacts by city
        /// </summary>
        /// <param name="city"></param>
        public void ViewPersonsByCity(string city)
        {
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Contacts contact in ContactByCity[city])
                {
                    Console.WriteLine(contact.ToString());
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        /// <summary>
        /// View all the contacts by state
        /// </summary>
        /// <param name="state"></param>
        public void ViewPersonsByState(string state)
        {
            if (ContactByState.ContainsKey(state))
            {
                foreach (Contacts contact in ContactByState[state])
                {
                    Console.WriteLine(contact.ToString());
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }

    }
}
