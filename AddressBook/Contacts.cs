using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string EMail { get; set; }




        public Contacts()
        {
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            State = "";
            ZipCode = "";
            PhoneNo = "";
            EMail = "";
        }
        public Contacts(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string eMail)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            PhoneNo = phoneNo;
            EMail = eMail;
        }
        public override string ToString()
        {
            return "Name :" + FirstName + " " + LastName + "\nAddress :" + Address +" \nCity :"+City+"  State :"+State+"   ZipCode :" + ZipCode + "\nPhone No :" + PhoneNo + "   Email :" + EMail;
        }
    }
}
