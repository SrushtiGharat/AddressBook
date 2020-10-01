using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contacts
    {
        public string firstName, lastName, address, city, state, zipCode, phoneNo, eMail;

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
        public Contacts(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
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
}
