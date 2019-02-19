using System;

namespace Animals.Library
{
    public class Dog
    {
        // Fields
        // Declaring fields and getters and setters is NOT
        // common practice in C#! Use properties instead
        internal string Noise = "Woof!";

        //Getter
        public string getNoise()
        {
            return Noise;
        }

        //Setter
        public void setNoise(string newValue)
        {
            if(newValue == null || newValue.Length == 0)
            {
                // throwing an exception
                throw new ArgumentException("Value must not be null or empty");
            }
            Noise = newValue;
        }

        // Instead of using getters and setters,
        // in C# we have properties where other languages would just
        // use fields on their own

        // simplest property "auto-implemented"
        // field generated behind the scenes to back the property
        // "backing field"
        // Usually properties have some backing field
        public int id {get; set;} = 0;

        // This is the manual version of auto-property
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            } 
            set
            {
                // Implicit argument "value"
                // could do null/empty checks, etc.
                _name = value;
            }
        }
        // Property syntax provides getters and setters pretending
        // to be a field

        // we can have properties without set
        public string Color { get; } = "brown";
        public string Breed { get; set; }

        // methods
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