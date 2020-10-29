using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace AddressBook
{
    class LoadAddressBooks
    {
        ReadOrWriteToFile rw = new ReadOrWriteToFile();
        string[] filePaths = Directory.GetFiles(@"C:\Users\Gharat\source\repos\AddressBook\AddressBookFiles", "*.csv");

        /// <summary>
        /// Load the already existing address books records from files
        /// </summary>
        /// <param name="multipleAddressBooks"></param>
        public  void LoadExistingAddressBooks(MultipleAddressBooks multipleAddressBooks)
        {
            if (filePaths.Length == 0)
            {
                Console.WriteLine("No address books present");
                return;
            }
            Console.WriteLine("Address Books Present");
            int count = 1;
            foreach (string paths in filePaths)
            {
                string addressBookName = Path.GetFileNameWithoutExtension(paths);
                Console.WriteLine(count++ + "."+addressBookName);

                multipleAddressBooks.AddAddressBook(addressBookName);
                
                Address_Book addressBook = multipleAddressBooks.GetAddressBook(addressBookName);
                List<Contacts> contactList = GetAddressBookRecords(paths);

                foreach (var contacts in contactList)
                {
                    addressBook.contactList.Add(contacts);
                }
                
            }
            
        }
        /// <summary>
        /// Get the records from csv files
        /// </summary>
        /// <param name="files"></param>
        /// <returns>List of contacts present in files</returns>
        public List<Contacts> GetAddressBookRecords(string files)
        {
            using (var reader = new StreamReader(files))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contacts>().ToList();
                return records;
            }
        }
    }
}
