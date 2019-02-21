using System;
using System.Collections.Generic;
using ExtensionMethodsAndLINQ.Extensions;
using System.Linq;

namespace ExtensionMethodsAndLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int result = 3.Pow(3);
            var list = new List<string>();
            list.Empty();
            var str = list.ToString();

            // extension methods don't allow us to truly modify the original type
            // they are only visible when we have a using directive
            // for the namespace where my static method is defined.

            // extension methods don't let you see any private/protected members

            // LINQ
            // Language Integrated Query
            // LINQ is a bunch of extension methods on IEnumerable<T> and IQueryable<T>
            // all come from System.Linq namespace
            list.ToList();

            list.AddRange(new string[] { "a", "b", "b", "jdkfl;sajfkdls;" });

            int sum = 0;
            foreach (var s in list)
            {
                sum += s.Length;
            }
            double averageStringLength = sum / list.Count;

            Console.WriteLine(averageStringLength);

            // With LINQ...
            averageStringLength = list.Average(s => s.Length);

            Console.WriteLine(averageStringLength);

            // a "lambda" is kind of like a method that's anonymous
            // and can be treated like an ordinary value/object

            // it Doesn't have to be anonymous
            Func<string, int> numberOfAs = x => x.Count(c => c == 'a');

            var numOfAllAs = list.Sum(numberOfAs); // getting function from a Func variable
            var numOfAllBs = list.Sum(NumberOfBs); // getting function from a method

            // funcitonal programming is a paradigm like
            // OOP, like procedural programming

            // we treat functions/methods as if they were just another piece of data

            // C# is not a purely functional language
            // but it does have plenty of support for programming in that style
            // especially with LINQ.
            // (C# does have some immuatable classes in the library)

            // LINQ has two syntaxes...
            // method syntax and query syntax ( SQL wannabe )

            var allEmptyStrings = from x in list
                                  where x == ""
                                  select x;

            // method syntax way
            allEmptyStrings = list.Where(x => x == "");

            // LINQ methods we definitely want to know...
            // Any (big OR on all elements)
            bool anyStringsLongerThanFive = list.Any(s => s.Length > 5);

            // All (big AND on all elements)
            bool allStringsLongerThanFive = list.All(s => s.Length > 5);

            // we have Contains(value)
            // we have Count(), Count(filterFunction)
            // DefaultIfEmpty
            // Distinct

            // the second characters of all the strings that start with 'a'
            var asdf = list.Distinct().Where(x => x[0] == 'a').Select(x => x[1]);
            // Select and Where are the most comon ones.
            // Select applies a mapping to the collection
            // Where filters a collection on some condition

            var allWithLengthThree = list.Where(s => s.Length == 3);

            // deferred execution.
            // many these LINQ methods return IEnumerable, never whatever 
            // the original collection was. in such cases, the processing
            // defined by the method calls doesn't happen until you start
            // trying to pull values out of that IEnumerable
            foreach (var item in asdf)
            {
                // HERE in this loop, we are executing the logic from line 88
                Console.WriteLine(item);
            }

            // we we DONT want deferred execution, we want all the values right now...
            // we often use .ToList()

            // apart from being used for LINQ, the importance of IEnumerable is
            // that it allows iterating with foreach statement.

        }

        static int NumberOfBs(string x)
        {
            var count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 'b')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
