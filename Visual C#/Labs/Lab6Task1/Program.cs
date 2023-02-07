using System;
using System.Collections.Generic;
//Task
//Write an extension method to reverse a
//string “ghada “ “adahg”
namespace Lab6Task1
{
    public static class stringExtension
    {
        public static string ReverseString(this string s)
        {
            string ReversedString = null;
            List<char> characters = new List<char>();
            for (int i = s.Length - 1; i >= 0; i--) characters.Add(s[i]);
            ReversedString = String.Join(string.Empty, characters);
            return ReversedString;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Karim".ReverseString());
        }
    }
}
