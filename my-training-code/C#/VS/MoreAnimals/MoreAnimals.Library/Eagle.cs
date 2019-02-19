using System;
using System.Collections.Generic;
using System.Text;

namespace MoreAnimals.Library
{
    // We extend classes and implement interfaces with :
    public class Eagle : ABird
    {
        // in C#, by default, overriding inherited members is not allowed!
        // only writing new members
        public override void MakeNoise()
        {
            Console.WriteLine("Caw");
        }

        // Attempt to override the inherited "GoTo"
        public void GoTo(string location)
        {
            Console.WriteLine($"I'm an Eagle Flying to {location}");
        }
    }
}
