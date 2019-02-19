using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    // an Abstract class is like a mix of class and interface
    // we can provide some implementations while leaving others unimplemented
    public abstract class ABird : IAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public abstract void MakeNoise();

        public virtual void GoTo(string location)
        {
            Console.WriteLine($"Flying to {location.ToLower()}");
        }
    }
}
