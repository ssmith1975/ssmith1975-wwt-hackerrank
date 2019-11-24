using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringEncoder
{
    public class Encoder 
    {
        private static readonly Encoder instance = new Encoder();
 
        static Encoder()
        {
                
        }
        private  Encoder()
        {

        }
        public static Encoder Instance {
            get {
                return instance;
            }
        }

        /// <summary>
        ///     Encodes strings
        /// </summary>
        /// <param name="stringToEncode">Input string to
        public string encode(string stringToEncode)
        {

            StringBuilder sb = new StringBuilder();

            // Setup character mapping
            Dictionary<char, char> charMap = buildCharMapping();

            // Convert string to lowercase 
            stringToEncode = toLower(stringToEncode);

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


        private string toLower(string str)
        {
            return str.ToLower();
        }

        /// <summary> 
        ///     Replaces numbers in strings with its digit ordering in reverse.
        /// </summary>
        /// <param name="str">Input string</param>
        /// <returns>Returns a string</returns>
        private string reverseDigitOrder(string str)
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
        private Dictionary<char, char> buildCharMapping()
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

    }
}
