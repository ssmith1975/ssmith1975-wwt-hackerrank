using System.Collections.Generic;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace StringEncoder
{
    public class Solution
    {

        /// <summary>
        ///     Encodes strings
        /// </summary>
        /// <param name="stringToEncode">Input string to encode</param>
        /// <returns>Returns encoded string</returns>
        public static string encode(string stringToEncode, Dictionary<char, char> charMap)
        {
            StringBuilder sb = new StringBuilder();

            // Setup character mapping
            //Dictionary<char, char> charMap = buildCharMapping();
           
            // Convert string to lowercase 
            stringToEncode = stringToEncode.ToLower();

            // Reverse order of digits for numerical values within string
            stringToEncode = reverseDigitOrder(stringToEncode);

            // Add to stringbuilder
            sb.Append(stringToEncode);

            // Map characters one character at a time
            for (int i = 0; i < sb.Length; i++)
            {
                // Get current character
                char character = sb[i];
                // Check mapping dictionary
                if (charMap.ContainsKey(character))
                {
                    // Update character with encoded character mapped from dictionary
                    sb[i] = charMap[character];
                } // end if
            } // end for loop


            return sb.ToString();

        } // end encode

        /// <summary> 
        ///     Replaces numbers in strings with its digit ordering in reverse.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Returns a string</returns>
        static string reverseDigitOrder(string str)
        {
            string regexPattern = @"\d+";

            return Regex.Replace(str, regexPattern,
                new MatchEvaluator(m => {
                    char[] charArr = (m.Value).ToCharArray();
                    Array.Reverse(charArr);
                    return new string(charArr);
                }) // end MatchEvaluator
            ); // end Regex

        } // reverseDigitOrder

        /// <summary>
        ///     Generates character mapping
        /// </summary>
        /// <returns>Dictionary key/value pair of type char</returns>
        static public Dictionary<char, char> buildCharMapping()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            // Initialize dictionary
            Dictionary<char, char> charMap = new Dictionary<char, char>()
            {
                // map vowels
                {'a','1'},
                {'e','2'},
                {'i','3'},
                {'o','4'},
                {'u','5'},

                //map 'y' and space
                {'y',' '},
                {' ','y'},

            };

            // Generate mapping for consonants by  pairing them with previous 
            // the previous character in the alphabet
            foreach (var ch in alphabet)
            {
                if (!charMap.ContainsKey(ch))
                {
                    char key = ch;
                    char val = (char)(ch - 1);
                    charMap[key] = val;
                } // end if

            } // end foreach loop

            return charMap;
        } // end buildCharMapping

        public static void Main(string[] args)
        {
            Dictionary<char, char> charMap = buildCharMapping();
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            Console.Write("Enter some text to encode: " );
            string stringToEncode = Console.ReadLine();

            string res = encode(stringToEncode, charMap);
            Console.WriteLine("\r\nResult: " + res);
 
            Console.WriteLine("\r\n\r\nHit any key to exit program....");
            Console.ReadKey();

            //textWriter.WriteLine(res);

            //textWriter.Flush();
           // textWriter.Close();
            
        }
    } // end Main
}
