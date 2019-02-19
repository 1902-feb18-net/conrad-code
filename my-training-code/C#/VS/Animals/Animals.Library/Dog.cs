using System;

namespace Animals.Library
{
    public class Dog
    {

        public string Noise = "Woof!";
        public void GoTo(string location)
        {
            // easy way to concatenate strings
            // Console.WriteLine("Walking to " + location);

            // string interpolation syntax
            // dollar sign turns braces into C# code
            Console.WriteLine($"Walking to {location}");
        }

        public void MakeNoise()
        {
            // no need for this.Noise because everything is in scope
            Console.WriteLine(Noise);
        }

        // access Modifiers 
        // in C#, every class/interface/etc. has some access modifier
        // and every class/etc _member_ has some access modifier
    }
}