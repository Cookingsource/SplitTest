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

        private void AssertSplit(string source, string delimiter, params string[] expectedResult)
        {
            CollectionAssert.AreEqual(
                expectedResult,
                StringEx.Split(source, delimiter));
        }
    }
}