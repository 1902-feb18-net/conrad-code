using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            // We WOULD write this but Main cannot be async 
            //persons = await DeserializeXMLFromFileAsync(fileName);
            persons = DeserializeXMLFromFileAsync(fileName).Result;

            persons.Add(new Person { Id = persons.Max(p => p.Id + 1) });

            SerializeXMLToFile(fileName, persons);

            // we could serialize in JSON format instead of XML...
            //JSON.NET (third-party) (aka newtonsoft JSON)

            string jsonFile = @"C:\revature\persons_data.json";

            persons = JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText(jsonFile));
        
            persons.Add(new Person { Id = persons.Max(p => p.Id + 1) });
            string newData = JsonConvert.SerializeObject(persons);
            File.WriteAllTextAsync(jsonFile, newData);
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


        // when we make code async...
        // the method has to have the "async" modifier
        // the mthod needs to return a Task or
        // a Task<something> if we wanted to return Something
        // the method should say Async at the end of its name (for self documenting purposes)
        // when we call async methods in our own methods, we need to "await" the tasks
        // they give us.
        private static async Task<List<Person>> DeserializeXMLFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            // in addition to those XmlBlahBlah attributes, we can also customize
            // the format on the serializer object itself

            //FileStream fileStream = null;
            //var memoryStream = new MemoryStream();

            //try
            //{
            //    fileStream = new FileStream(fileName, FileMode.Open);

            //    return (List<Person>)serializer.Deserialize(fileStream);
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine("error in reading to file:");
            //    Console.WriteLine(e.Message);
            //    return null;
            //}
            //finally
            //{
            //    fileStream?.Dispose(); // all IDisposable have Dispose method
            //}

            // we're going to use "using statement", not to be confused with 
            // using directive - at top of file

            // In place of boilerplate code with IDisposable try finally dispose

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    // copy the filestream into the memorystream
                    // Task copying = fileStream.CopyToAsync(memoryStream);
                    // await copying;
                    await fileStream.CopyToAsync(memoryStream);
                    

                    // the objects you're using to support async, or you aren't able to use it
                    // XmlSerializer.DeserializeAsync doesn't exist, or else, 
                    // we wouldn't need memoryStream
                }

                // using statement automatically disposes of resource when we exit it

                // reset "cursor" of stream to beginning to read its contents
                memoryStream.Position = 0;

                return (List<Person>)serializer.Deserialize(memoryStream);
                // should be try catching throughout this method
            }
        }
    }
}
