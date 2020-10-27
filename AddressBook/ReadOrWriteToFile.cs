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
    class ReadOrWriteToFile
    {
        string path = @"C:\Users\Gharat\source\repos\AddressBook\Address Book Contacts.txt";
        string csvPath = @"C:\Users\Gharat\source\repos\AddressBook\AddressBookContacts.csv";
        public void WriteToFile(string addressBookName,List<Contacts> contactList)
        {
            if (FileExitsts(path))
            {
                int count = 0;

                using (StreamWriter sr = File.AppendText(path))
                {
                    sr.WriteLine(addressBookName + ":");
                    foreach (Contacts c in contactList)
                    {
                        sr.WriteLine(++count + " " + c.ToString() + "\n");

                    }
                    sr.Close();
                }
                Console.WriteLine("Written to file successfully");
            }
            else
            {
                Console.WriteLine("File Does Not Exist");
            }

        }
        public void ReadFromFile()
        {
            if (FileExitsts(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }

            }
        }
        public void WriteToCSV(List<Contacts> contactList)
        {
            if (FileExitsts(csvPath))
            {
                using (var writer = new StreamWriter(csvPath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(contactList);
                }
                Console.WriteLine("Records Added Successfully");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        public void ReadFromCSV()
        {
            if (FileExitsts(csvPath))
            {
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contacts>().ToList();
                    Console.WriteLine("Data reading done successfully");
                    foreach (Contacts contacts in records)
                    {
                        Console.Write("\t" + contacts.FirstName);
                        Console.Write("\t" + contacts.LastName);
                        Console.Write("\t" + contacts.Address);
                        Console.Write("\t" + contacts.City);
                        Console.Write("\t" + contacts.State);
                        Console.Write("\t" + contacts.ZipCode);
                        Console.Write("\t" + contacts.PhoneNo);
                        Console.Write("\t" + contacts.EMail);
                        Console.Write("\n");

                    }
                }
            }
            else
            {
                Console.WriteLine("No such file found");
            }
        }
        public void ClearFile()
        {
            File.WriteAllText(path, string.Empty);
        }
        public bool FileExitsts(string filePath)
        {
            if (File.Exists(filePath))
                return true;
            return false;
        }
    }
}
