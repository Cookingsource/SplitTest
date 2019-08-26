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
        public void CanRef()
        {
            StringEx.Split(null, null);
        }
    }
}