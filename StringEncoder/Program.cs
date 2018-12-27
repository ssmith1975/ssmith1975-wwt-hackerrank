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

namespace StringEncoder
{
    public class Solution
    {

        // Complete the encode function below.
        public static string encode(string stringToEncode)
        {
            return stringToEncode;


        } // end encode



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
