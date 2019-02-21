using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethodsAndLINQ.Extensions
{
    public static class ListExtension
    {
        // C# supports adding methods onto any class/struct
        // using static methods whose first parameter is declared with "this"
        // the class/struct which type
        public static bool Empty<T>(this List<T> list)
        {
            return list.Count == 0;
        }


        public static int Pow(this int a, int b)
        {

            if(b < 0)
            {
                // nameof() turns variable into string. useful when referring to variable
                throw new ArgumentException("exponent must be nonnegative", nameof(b));
            }
            if (b == 0) return 1;

            int result = a;
            while (b>0)
            {
                result *= a;
                b--;
            }
            return result;
        }
    }
}
