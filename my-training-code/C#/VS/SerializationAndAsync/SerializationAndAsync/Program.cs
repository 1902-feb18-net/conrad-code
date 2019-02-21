using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
           {
               new Person
               {
                   Name = "Nick",
                   Address = new Address
                   {
                       Street = "123 Main Street",
                       City = "Fort Worth",
                       State = "TX"
                   }
               },

            new Person
            {
                Name = "Fred",
                Address = new Address
                {
                    Street = "123 Main Street",
                    City = "Reston",
                    State = "VA"
                }
            }
           };

            // To send this over network or to disk, we need to serialize it
            // meaning, collecting data from across memory locations
            // into a well-defined text or binary format.
            // ideally this is reversible, we can deserialize the data back from
            // its format into memory (maybe on the other end of the network connection.)

            // normally, \ is used as an escape character in string literals.
            // so this string has a new line character:
            string newline = "\n";

            // when we want to treat backslashes literally, we have @strings
            string fileName = @"C:\revature\persons_data.xml";

            persons = DeserializeXMLFromFile(fileName);

            persons.Add(new Person { Id = persons.Max(p => p.Id + 1) });

            SerializeXMLToFile(fileName, persons);
        }

        private static void SerializeXMLToFile(string fileName, List<Person> persons)
        {
            // our first object, xmlSerializer
            // unfortunately does not know about generics
            var serializer = new XmlSerializer(typeof(List<Person>));

            // Create mode to overwrite file if already exists
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, persons);
            }
            catch (IOException e)
            {
                Console.WriteLine("error in writing to file:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                fileStream?.Dispose(); // all IDisposable have Dispose method
            }
            
        }

        private static List<Person> DeserializeXMLFromFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            // in addition to those XmlBlahBlah attributes, we can also customize
            // the format on the serializer object itself

            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Open);

                return (List<Person>)serializer.Deserialize(fileStream);
            }
            catch (IOException e)
            {
                Console.WriteLine("error in reading to file:");
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                fileStream?.Dispose(); // all IDisposable have Dispose method
            }
        }
    }
}
