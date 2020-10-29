using CsvHelper;
using Newtonsoft.Json;
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
        /// <summary>
        /// Write contacts in address book to a txt file
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="path"></param>
        public void WriteToFile(List<Contacts> contactList, string path)
        {
            using (StreamWriter sr = File.AppendText(path))
            {
                int count = 0;
                foreach (Contacts c in contactList)
                {
                    sr.WriteLine(++count + " " + c.ToString() + "\n");

                }
                sr.Close();
            }

        }

        /// <summary>
        /// Read contacts from txt file
        /// </summary>
        public void ReadFromFile(string path)
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
        /// <summary>
        /// Write contacts in address book to a .csv file
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="csvPath"></param>
        public void WriteToCSV(List<Contacts> contactList, string csvPath)
        {
            if (FileExitsts(csvPath) == false)
            {
                File.Create(csvPath).Close();
            }

            using (var writer = new StreamWriter(csvPath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvExport.WriteRecords(contactList);
            }

        }
        /// <summary>
        /// Read contacts from .csv file
        /// </summary>
        /// <param name="csvPath"></param>
        public void ReadFromCSV(string csvPath)
        {
            if (FileExitsts(csvPath))
            {
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contacts>().ToList();

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
                Console.WriteLine("File Does Not Exist");
            }
        }
        /// <summary>
        /// Write contacts in address book to a json file
        /// </summary>
        /// <param name="contactList"></param>
        /// <param name="jsonPath"></param>
        public void WriteToJsonFile(List<Contacts> contactList, string jsonPath)
        {
            if (FileExitsts(jsonPath) == false)
            {
                File.Create(jsonPath).Close();
            }
            using (StreamWriter r = new StreamWriter(jsonPath))
            {
                string json = JsonConvert.SerializeObject(contactList);
                r.WriteLine(json);
            }

        }
        /// <summary>
        /// Read contacts from json file
        /// </summary>
        /// <param name="jsonPath"></param>
        public void ReadFromJsonFile(string jsonPath)
        {
            if (FileExitsts(jsonPath))
            {
                using (StreamReader r = new StreamReader(jsonPath))
                {
                    string json = r.ReadToEnd();
                    List<Contacts> records = JsonConvert.DeserializeObject<List<Contacts>>(json);
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
                Console.WriteLine("File Does Not Exist");
        }

        /// <summary>
        /// Check if the file exits
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Returns true if the file exits at a given path or else returns false</returns>
        public bool FileExitsts(string filePath)
        {
            if (File.Exists(filePath))
                return true;
            return false;
        }
        /// <summary>
        /// Clear a file
        /// </summary>
        public void ClearFile(string path)
        {
            File.WriteAllText(path, string.Empty);
        }
    }
}
