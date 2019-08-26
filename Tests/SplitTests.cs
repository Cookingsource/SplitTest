using System;
using NSubstitute;
using NUnit.Framework;
using Split;

namespace Tests
{
    public class SplitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Split_NullSource_Fails()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringEx.Split(null, Arg.Any<string>());
            });
        }

        [Test]
        public void Split_NullOrEmptySeparator_ReturnsSource()
        {
            string source = "SomeString";
            AssertSplit(source, null, source);
            AssertSplit(source, string.Empty, source);
        }

        [Test]
        public void Split_SingleCharDelimiter_DelimiterRemovedAndFragmentsReturned()
        {
            AssertSplit("a,b,c", ",", "a", "b", "c");
        }

        [Test]
        public void Split_AdjacentDelimiters_ProduceNoEmptyFragments()
        {
            AssertSplit("a,,,b",",","a","b");
        }

        [Test]
        public void Split_BeginningAndEndingDelimiters_ProduceNoEmptyFragments()
        {
            AssertSplit(",,,x,y", ",", "x", "y");
            AssertSplit("x,y,,,", ",", "x", "y");
        }

        private void AssertSplit(string source, string delimiter, params string[] expectedResult)
        {
            var result = StringEx.Split(source, delimiter);
            CollectionAssert.AreEqual(
                expectedResult,
                result);
        }
    }
}