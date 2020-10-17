using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class MultipleAddressBooks
    {
        Dictionary<string, Address_Book> addressBooksCollection = new Dictionary<string, Address_Book>();
        public MultipleAddressBooks()
        {
            addressBooksCollection = new Dictionary<string, Address_Book>();
        }
        public void AddAddressBook(string name)
        {
            Address_Book addressBook = new Address_Book();
            addressBooksCollection.Add(name, addressBook);
            
        }
        public Address_Book GetAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name))
            {
                return addressBooksCollection[name];
            }
            return null;
        }
        public void searchPersonOverMultipleAddressBook(string firstName,string lastName,string cityOrState)
        {
            Dictionary<string, Address_Book>.Enumerator enumerator = addressBooksCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("AddressBook Nmae :" + enumerator.Current.Key);
                Console.WriteLine();
                Contacts c = enumerator.Current.Value.SearchPerson(firstName,lastName,cityOrState);
                if (c != null)
                    Console.WriteLine("Name :"+c.firstName+" "+c.lastName+"\nAddress :"+c.address+"\nCity :"+c.city+"   State :"+c.state+"\nZipCode :"+c.zipCode+"\nPhone No :"+c.phoneNo+"   Email :"+c.eMail);
                else
                    Console.WriteLine("No Contact");
                Console.WriteLine("------------------------------");
            }
        }
            
    }
}
