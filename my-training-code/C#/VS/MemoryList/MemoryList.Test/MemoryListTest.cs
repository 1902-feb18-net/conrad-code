using ML.Library;
using System;
using Xunit;

namespace ML.Test
{
    public class MemoryListTest
    {
        // second type of xunit test : Theory
        // Facts don't allow parameters
        // Theories accept sets of parameters, to run the test against all of them
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(10000)]
        public void AddedItemsShouldBeContained(int value)
        {
            var list = new MemoryList<int>();

            list.Add(value);

            Assert.True(list.Contains(value));

        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(10000)]
        public void RemoveShouldRemoveSingleItem(int value)
        {
            //arrange, act, assert
            var list = new MemoryList<int>();
            list.Add(value);

            list.Remove(value);

            Assert.False(list.Contains(value));
        }
    }
}
