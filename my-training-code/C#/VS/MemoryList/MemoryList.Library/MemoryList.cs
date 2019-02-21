using System;
using System.Collections.Generic;

namespace ML.Library
{
    public class MemoryList<T>
    {

        protected readonly List<T> _list = new List<T>();

        public void Add( T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            //_list.Remove
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        // Test driven development
        // 1. write tests that fail
        // 2. make new tests pass without changing them (by writing the real code)
    }
}
