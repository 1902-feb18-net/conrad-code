using System;
using System.Collections.Generic;

namespace CollectionTesting.Library
{
    public class MyStringCollection : MyGenericCollection<string>
    {
        // Use private or protected field
        // to store a List<string> to handle all the list operations

        // Now we are getting the field from the parent class
        //private List<string> _myString = new List<string>();

        // implement some collection methods like Add, Contains, Remove, and some
        // others that are not already on the List. 
        // i.e. Remove all empty strings,

        // At least five methods

        // base() means if someone calls the zero-parameter constructor,
        // first call the base classe's zero parameter constructor (this is done
        // by default already)
        public MyStringCollection() : base()
        {

        }

        // in C# we prefer thin constructors and setting properties after the fact
        // If we still want validation logic, we can put that in property "sets"
        // and maybe a .Validate method

        public MyStringCollection(string[] initial) : base(initial)
        {

        }

        // This is inherited now
        //public void Add(string s)
        //{
        //    _myString.Add(s);
        //}

        public bool Remove(string s)
        {
            return _list.Remove(s);
        }

        /// <summary>
        /// Remove all contained strings
        /// </summary>
        public void RemoveEmptyStrings()
        {
            while (_list.Contains(""))
            {
                _list.Remove("");
            }

           // Alternatively
           // _myString.RemoveAll(x => x == "");
        }

        // This is inherited now
        //public bool Contains(string s)
        //{
        //    return _myString.Contains(s);
        //}



    }
}
