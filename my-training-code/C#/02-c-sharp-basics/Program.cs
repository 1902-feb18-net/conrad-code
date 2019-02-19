using System;
using System.Collections.Generic;

// namespace should match folder structure
// with dots for subfolders
namespace _02_c_sharp_basics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Variables
            // Declare and initialize
            string myString = ".NET";

            string myString2;
            myString2 = ".NET";

            Console.WriteLine(myString2);

            // Basic data types
            int integer; // 32 bit
            double dec; // 64 bit float
            string s; // string of characters
            bool trueOrFalse; // true or false 

            // Basic Control Structures
            if (1 == 3)
            {
                // this wont run if false
            }
            else if (1 == 2)
            {
                // Also won't run
            }
            else
            {
                // This will run
                System.Console.WriteLine("1 Isn't equal to any of those.");
            }

            // LOOPS
            int max = 10;
            for (int i = 0; i < max; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            int num = 4;
            while (num > 0)
            {
                num -= 10;
                Console.WriteLine(num);
            }

            // also do-while

            switch (num)
            {

                case 3:
                    num = 4;
                    break;
                case 4:
                    num = 3;
                    break;
                default:
                    System.Console.WriteLine("Unexpected Condition");
                    break;
            }

            // Call function
            PrintStuff("String sent from main function!");

            PrintStuff(Reverse("Conrad Troha"));

            // we have compile time type inference for variables
            var data = "asdf";
            // we can declare variables and have the type decided based upon
            // what we give it as initial value

            // we can't have the compiler predict the future 
            // it really just copies type of right hand side of assignment

            // use var when type is obvious from context and/or obnoxiously long
            var myList = new List<List<List<string>>>(); 

            // in C# apart from basic data types we spend most of our time talking 
            // about objects created with "new"
            // e.g.
            var program = new Program();
        }

        // seperate functions

        // first modifier (static)
        // second return type (void)
        // third we have name of function
        // last we have parameter list
        static void PrintStuff(string stuff){
            
            Console.WriteLine(stuff);
        }

        static string Reverse(string s){

            string result = "";
            foreach (char ch in s) // for each character in string
            {
                result = ch + result;
            }
            return result;
        }
    }
}
