using System.Collections.Generic;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace StringEncoder
{
    public class Solution
    {

        public static void Main(string[] args)
        {
            string stringToEncode;
            Encoder stringEncoder;
            string result;

            // Prompt user for string to encode
            Console.Write("Enter some text to encode: " );
            stringToEncode = Console.ReadLine();

            // Setup encoder
            stringEncoder = Encoder.Instance;

            // Encode string
            result = stringEncoder.encode(stringToEncode);

            // Display encoded string
            Console.WriteLine($"\r\nResult: {result}");
 
            Console.WriteLine("\r\n\r\nHit any key to exit program....");
            Console.ReadKey();
            
        }
    } // end Main
}
