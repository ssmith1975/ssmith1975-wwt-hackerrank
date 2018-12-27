using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringEncoder;

namespace StringEncoder.Test
{
    [TestClass]
    public class TestEncodeMethod
    {

        [TestMethod]
        public void encodeReturnsAString()
        {
            string input = "Hello World!";
            string actual = Solution.encode(input);
            Assert.IsInstanceOfType(actual,typeof(String));
        }

        [TestMethod]
        public void encodeSampleReturnsEncoded()
        {
            string input = "Hello World!";
            string expected = "g2kk4yv4qkc!";
            string actual = Solution.encode(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
