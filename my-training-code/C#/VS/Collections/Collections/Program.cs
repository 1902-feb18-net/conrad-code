using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Lists();
            Sets();
            StringEquality();
        }

        static void Arrays()
        {
            int[] ints = new int[5];
            int[] ints2 = new int[] { 1, 2, 3, 49, 50 };

            // we can go through arrays with for loop, or foreach loop
            // if we have no need for the index

            // we can have arrays of any type, even other arrays

            int[][] twoDArray = new int[9][];
            twoDArray[0] = new int[4];
            twoDArray[1] = new int[4];
            //etc.
            // a 9 by 4 two d array
            // this is called a "jagged array"
            // each row could have different lengths if we wanted

            // c# has multidimensional array
            int[,] multiDArray = new int[5,5];
            // 5 by 5 multi d array

            multiDArray[0, 0] = 8;
            int[,,,] fourDArray = new int[5, 5, 4, 2]; // four D array
            // comma instead of extra brackets

            // This is gross
            int[,][] crazyThing = new int[2,2][];

            // we rarely have any use for arrays
            // for performance is really the only reason

            // in practice we use other objects
            
        }

        static void Lists()
        {
            // This list is contains objects and we can't know that it is ints or strings or etc.
            var list = new ArrayList{ 5, 8, 1 };
            list.AddRange(new int[] { 4, 5, 6, 7, 8 });
            list.Remove(8);
            list.Contains(8); // will check if the item exists in list and would be a good 
                              // while loop condition if we wanted to remove all '8',s
            list.Add("dklsafjdk"); 

            for(int i=0; i<list.Count; i++)
            {
                // can index into the list as if it were an array
                Console.WriteLine(list[i]);
                //list[i] = 2;
            }

            //foreach (var item in list)
            //{

            //}

            // early in C#'s history we got generics and stopped using ArrayList as well


            // This is the class we use for array-like stuff
            var genericList = new List<int>() { 1,2,3 };
            // This list doesn't upcast everything to object, it only allows ints
            // genericList.Add("fjdkls"); // not allowed because this instance is tied to the int type

            foreach (var item in genericList)
            {
                Console.WriteLine(item * 2); // works because we know this is an int
            }

        }

        static void Sets()
        {
            var set = new HashSet<string>();
            set.Add("abs");
            set.Add("abs"); // this line of code will do nothing
            set.Add("abcdef");

            // we take the idea of sets from math
            // a set has no concept of duplicates, something is either there or it isn't
            // there is also no concept of order

            Console.WriteLine(set.Count); // returns 2 

            // sets are useful when we aren't interested in storing order
            // the main thing we want to do is later on
            // check if some thing is or is not inside the set

            // very fast to remove, add, or check if a member is in the set
            // because it is based on a hash table

            var list = new List<int> { 1, 2, 2, 2, 3 };
            var withoutDupes = new List<int>(new HashSet<int>(list));

        }

        static void Maps()
        {
            // store key value relationship between things
            var dictionary = new Dictionary<string, string>();
            dictionary["classroom"] = "room where classes are held";

            var grades = new Dictionary<string, double>();
            // we also have an initializer syntax for dictionaries
            grades["Conrad"] = 80;
            // Helpful members: keys, values, ContainsKey, ContainsValue, TryGetValue

            foreach (KeyValuePair<string, double> item in grades)
            {
                //item.key
                //item.value
            }

            // Dictionary objects let you use any type you want to index into it
            // and any type to use for the value stored for that key
            // only one value for a given key in a dictionary
        }

        static void StringEquality()
        {
            string a = "asdf";
            string b = "asdf";
            Console.WriteLine(a==b); // returns true in C#

            // value types and reference types
            // value type variables store their values directly
            // reference type variables store a reference to their value

            // in C#, many of our basic types are value types:
            // int, double, float, bool, long

            // because this is a value type, n2 gets a copy of n1
            int n1 = 5;
            int n2 = n1;


            // because Dummy is a reference type, dummy2 is a copy of the reference
            // i.e. new reference to the same objects
            var dummy1 = new Dummy();
            var dummy2 = dummy1;

            dummy1.Data = 10;
            if (dummy2.Data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("value type");
            }
            // objects made from classes are reference types, always
            // objects made from structs are value types
            // all the built-in value types are "structs" in C#

            var vDummy1 = new ValueDummy();
            var vDummy2 = dummy1;

            vDummy1.Data = 10;
            if (vDummy2.Data == 10)
            {
                Console.WriteLine("reference type");
            }
            else
            {
                Console.WriteLine("value type");
            }

            // structs are copied entirely every time we pass to a new method
            // or assign to a new variable
            // value types are deleted from memory as soon as the one variable
            // that contains them passes out of scope.

            // reference types, we get a new copy of a reference but to the same
            // underlying object
            // reference types need to be garbage collected because we don't know 
            // right away when the LAST variable pointing to it has passed out of scope

            // in C#, we have the idea of "managed" vs "unmanaged" code -
            // in unmanaged code, you have to manually write the code to
            // delete reference type objects from memory

            // in managed code, there is garbage collection that runs periodically
            // to search for objects that are unreachable by any running part of code.

            // our tradeoff is, the computer should work harder so the developer can solve 
            // real problems. The memory is managed for us.

            //back to strings......

            // NORMALLY "==" compares value types by value and reference types by reference

            Console.WriteLine(new Dummy() == new Dummy()); // false...reference type
                                                           // for value types like structs, they don't have to be the same object just the
                                                           // same values

            // BUT we make an exception for strings because it's awkward to have to
            // do string.Equals() for comparing strings.

            // int C# all value types do derive from object.
            // so we can always upcast them to object varibales

            int i1 = 5;
            object o2 = i1; // implicit upcasting
            // this is called "boxing" - the int is wrapped inside a reference type object
            // to give that value reference type semantics
            // "unboxing"...the reverse with downcasting
            int i2 = (int)o2;

            // java has awkward Integer vs int distinctions
            // we have this as boxing and unboxing with object.

            // sometimes we want to see if two objects have the same values in them
            // for that we make use of a .Equals method
            // Either it exists in the class we are using or we write one for our own class
        }

        class Dummy { public int Data { get; set; }  };

        struct ValueDummy { public int Data { get; set; } };
    }


}
