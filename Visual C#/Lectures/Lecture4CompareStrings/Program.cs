using System;
using System.Text;


namespace Lecture4CompareStrings
{
    internal class Program
    {
        public static byte FindAsciiCode(string value)
        {
            // Encodes a set of characters into a sequence of bytes.
            byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
            return asciiBytes[0];
        }
        public static int CompareStrings(string value1, string value2)
        {
            byte Ascii1 = FindAsciiCode(value1);
            byte Ascii2 = FindAsciiCode(value2);

            if (value1.Length == value2.Length)
            {
                Boolean isEqual = true;
                byte[] asciiBytes1 = Encoding.ASCII.GetBytes(value1);
                byte[] asciiBytes2 = Encoding.ASCII.GetBytes(value2);
                for (int i = 0; i < asciiBytes1.Length; i++)
                {
                    if (asciiBytes1[i] != asciiBytes2[i]) isEqual = false;
                }
                //====NON CASE SENSITIVE=====//
                if (isEqual == false)
                {
                    if (value1.ToUpper() == value2.ToUpper()) return 0;
                    else return 1;
                }
                else return 0;

                //====CASE SENSITIVE=====//
                //if (isEqual == false) return 1;
                //else return 0;
            }
            else if (Ascii1 < Ascii2)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(FindAsciiCode("a"));
            Console.WriteLine("Enter First String");
            string value1 = Console.ReadLine();
            Console.WriteLine("Enter Second String");
            string value2 = Console.ReadLine();
            Console.WriteLine(CompareStrings(value1, value2));

            //string value = "abcd";
            //// Convert the string into a byte[].
            //byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
            //foreach (byte b in asciiBytes) Console.WriteLine(b);
        }
    }
}

//====ASCII====//
//A < a
//a < b

//string value = "A";
//// Convert the string into a byte[].
//byte[] asciiBytes = Encoding.ASCII.GetBytes(value);
//foreach (byte b in asciiBytes) Console.WriteLine(b);
