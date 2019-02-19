using MoreAnimals.Library;
using System;

namespace MoreAnimals.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# has "property initializer" system
            var fido1 = new Dog();
            fido1.Id = 1;
            fido1.Name = "Fido";
            fido1.Breed = "German Shepherd";

            // Much nicer syntax for doing the same thing!!!
            var fido2 = new Dog
            {
                Id = 1,
                Name = "Fido",
                Breed = "German Shepherd"
            };

            fido1.GoTo("park");
            fido1.MakeNoise();

            // IAnimal is a parent type of Dog
            // Dog is a subtype of IAnimal
            IAnimal animal = fido1;
            // converting from dog variable to IAnimal variable is upcasting
            // upcasting is guaranteed to exceed so it is implicit

            //when the Dog object is contained in IAnimal Variable,
            // we cannot see the Dog-specific stuff anymore
            // animal.Breed // error

            // Converting from IAnimal to Dog is downcasting and is not guaranteed to succeed
            // must be explicit with () casting

            Dog dog2 = (Dog)animal;

            // not all casting is up/downcasting, e.g. int to double and back
            // double to int loses data and thus must be exclicit
            int integer = (int)3.4;

            // int to double cannot lose data however
            // thus can be done implicitly
            double num = integer;

            var animals = new IAnimal[2];
            animals[0] = fido1;
            animals[1] = new Eagle
            {
                Id = 3,
                Name = "Bob",
            };

            foreach(IAnimal item in animals)
            {
                Console.WriteLine(item.Name);
                item.MakeNoise();
                item.GoTo("Park"); // here we can't see Eagle.GoTo, whi only hides ABird.GoTo
                                    // without overriding it
            }

            Eagle eagle1 = (Eagle)animals[1];
            eagle1.GoTo("Park");

            // camel case for local variables and private fields
            //Titlecase for everything else
        }
    }
}
