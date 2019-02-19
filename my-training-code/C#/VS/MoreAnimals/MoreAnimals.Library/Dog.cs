using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    // Dog implements IAnimal Interface
    // every member specified by IAnimal guaranteed to be present on this class
    public class Dog : IAnimal
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }

        // methods
        public void MakeNoise()
        {
            Console.WriteLine("Woof!");
        }

        public void GoTo(string location)
        {
            Console.WriteLine($"Walking to {location}");
        }
    }
}
