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
        public void SearchPersonOverMultipleAddressBook(string cityOrState)
        {
            Dictionary<string, Address_Book>.Enumerator enumerator = addressBooksCollection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("AddressBook Nmae :" + enumerator.Current.Key);
                Console.WriteLine();
                enumerator.Current.Value.SearchContactByCityOrState(cityOrState);
                Console.WriteLine("-------------------------");
            }
        }
        
    }
}
