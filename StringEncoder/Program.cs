using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace StringEncoder
{
    public class Solution
    {

        // Complete the encode function below.
        public static string encode(string stringToEncode)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<char, char> charMap = buildCharMapping();
            string regexPattern = @"\d+";




            // Convert string to lowercase 
            stringToEncode = stringToEncode.ToLower();

            // Reverse order of digits for numerical values within string
            stringToEncode = Regex.Replace(stringToEncode, regexPattern,
                new MatchEvaluator(m => {
                    char[] charArr = (m.Value).ToCharArray();
                    Array.Reverse(charArr);
                    return new string(charArr);
                }) // end MatchEvaluator
            ); // end stringToEncode

            // Add to stringbuilder
            sb.Append(stringToEncode);

            // Map characters
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

        static Dictionary<char, char> buildCharMapping()
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

            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            Console.WriteLine("Input string:");
            string stringToEncode = Console.ReadLine();

            string res = encode(stringToEncode);

            Console.WriteLine(res);
            Console.ReadKey();

            //textWriter.WriteLine(res);

            //textWriter.Flush();
           // textWriter.Close();
            
        }
    } // end Main
}
