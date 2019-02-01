using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringEncoder;

namespace StringEncoder.Test
{
    [TestClass]
    public class TestEncodeMethod
    {
        Dictionary<char, char> charMapTest;

        [TestInitialize]
        public void TestInit()
        {
            charMapTestx = Solution.buildCharMapping();
        }
        [TestMethod]
        public void Should_Return_String()
        {
            string input = "Hello World!";
            string actual = Solution.encode(input, charMapTest);
            Assert.IsInstanceOfType(actual,typeof(String));
        } // end encodeReturnsAString

        [TestMethod]
        public void Should_Return_Lowercase()
        {
            string input1 = "ABCabc123";
            string input2 = input1.ToLower();

           
            string result1 = Solution.encode(input1, charMapTest);
            string result2 = Solution.encode(input2, charMapTest);

            bool actual1 = isAllLowerCase(result1);
            bool actual2 = isAllLowerCase(result2); 


            Assert.IsTrue(actual1, "Result1 one contained an uppercase");
            Assert.IsTrue(actual2, "Result2 one contained an uppercase");
            Assert.AreEqual(actual1, actual2, "Result should be the same regardless of input case.");
        } // end  Should_Return_Lowercase



        //vowels are replaced with number

        [TestMethod]
        public void Should_Replace_Vowels_WithNumber()
        {
            string[] input = { "a", "e", "i", "o", "u" };
            string[] expected = { "1", "2", "3", "4", "5" };
            string[] actual = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                actual[i] = Solution.encode(input[i], charMapTest);
            }
            
            CollectionAssert.AreEqual(expected, actual);
        } // end Should_Replace_Vowels_WithNumber

        [TestMethod]
        public void Should_Replace_Consonants_With_Previous()
        {
            string[] input = { "b", "c", "d", "x","z"};
            string[] expected = { "a", "b", "c", "w","y" };
            string[] actual = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                actual[i] = Solution.encode(input[i], charMapTest);
            }

            CollectionAssert.AreEqual(expected, actual);
        } // end Should_Replace_Consonants_With_Previous

        [TestMethod]
        public void Should_Replace_Y_With_Space()
        {
            string input = "y";
            string expected = " ";
            string actual = Solution.encode(input, charMapTest);
            Assert.AreEqual(expected, actual);
        } // end Should_Replace_Y_With_Space

        [TestMethod]
        public void Should_Replace_Space_With_Y()
        {
            string input = " ";
            string expected = "y";
            string actual = Solution.encode(input, charMapTest);
            Assert.AreEqual(expected, actual);
        } // end Should_Replace_Space_With_Y

        [TestMethod]
        public void Should_Replace_Number_With_Reverse()
        {
            string[] input = { "1", "123", "567-890" };
            string[] expected = { "1", "321", "765-098" };
            string[] actual = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                actual[i] = Solution.encode(input[i], charMapTest);
            }

            CollectionAssert.AreEqual(expected, actual);
        } // end Should_Replace_Consonants_With_Previous

        [TestMethod]
        public void Other_Characters_Should_Remain_Unchanged()
        {
            string[] input = { "!", ";", "-","[]","()" };
            string[] expected = { "!", ";", "-", "[]", "()" };
            string[] actual = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                actual[i] = Solution.encode(input[i], charMapTest);
            }

            CollectionAssert.AreEqual(expected, actual);
        } // end Other_Characters_Should_Remain_Unchanged

        [TestMethod]
        public void Should_Encode_Sample()
        {
            string input = "Hello World!";
            string expected = "g2kk4yv4qkc!";
            string actual = Solution.encode(input, charMapTest);
            Assert.AreEqual(expected, actual);
        } // end Should_Encode_Sample

        private bool isAllLowerCase(string str)
        {
            bool isLower = true;
            foreach (char ch in str.ToCharArray())
            {
                if (Char.IsLetter(ch) && !Char.IsLower(ch))
                {
                    isLower = false;
                    break;
                }
            } // end foreach loop

            return isLower;
        } // isAllLowerCase
    }
}
