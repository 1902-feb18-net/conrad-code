using CollectionTesting.Library;
using System;
using Xunit;

namespace CollectionTesting.Tests
{
    // usually, we write one test class to test each of our real classes
    public class MyStringCollectionTests
    {
        [Fact]
        public void Test1()
        {
            // Testing in general... make sure the code does what we expect
            // manual testing... run the code in our IDEs, plug in different inputs
            // and make sure we get the expected output.

            // Automated testing... we write the instructions for a test
            // and the expected results, the we re-run lots of tests automatically.

            // This helps us find and solve bugs quickly for subsequent development
            // it also helps us design well in the first place
            // Testable code is better designed code in general

            // unit testing is a particular kind of automated testing
            // where we resolve to test the smalles pieces we can at a time.

            // The alternative would be integration testing 


        }

        // we put our test methods inside an otherwise ordinary class
        // Fact attribute is our first example of C# attribute
        [Fact]
        public void AddShouldNotThrowException()
        {
            // three general steps to unit test
            // 1. arrange
            var collection = new MyStringCollection();

            // 2. act
            collection.Add("abc");
            // If an exception is thrown, that's caught by the test runner
            // and counted as a failure of the test.

            // 3. assert
            // (None needed here)
        }

        [Fact]
        public void ContainsShouldBeTrueForContained()
        {
            // arrange
            var collection = new MyStringCollection();
            collection.Add("asdf");

            // act
            var result = collection.Contains("asdf");

            // assert
            Assert.True(result);
            // xUnit provides Assert class with static methods
            // to help with asserting different things
        }

        [Fact]
        public void ContainsShouldBeFalseForNotContained()
        {
            // arrange
            var collection = new MyStringCollection();

            // act
            var result = collection.Contains("asdf");

            // assert
            Assert.False(result);
            // xUnit provides Assert class with static methods
            // to help with asserting different things
        }

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.True(false);
        //}
    }
}
