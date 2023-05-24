using System;
using System.Text;

namespace stringbuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder("Hello Wolrd!"); // we must use System.Text to access StringBuilder  ====>    using System.Text;
            builder
                .Append('-', 10)
                .AppendLine()
                .Append("Header")
                .AppendLine()
                .Append('-', 10)

                .Replace('-', '+')
                .Replace("Header", "Krsha")

                .Remove(0, 10)
                .Insert(0, new String('-', 10));
            Console.WriteLine(builder);

            // string builder doesnt have search methods
            // but it has indexer
            Console.WriteLine($"The indexer: \"{builder[0]}\"");
                                                          //============== string are immutable ===========//
            // create string
            //string str = "Hello ";
            // add another string "World"
            // to the previous string example
            //str = string.Concat(str, "World");
            //Here, we are using the Concat() method to add the string "World" to the previous string str.

            //But how are we able to modify the string when they are immutable?

            //Let's see what has happened here,

            //C# takes the value of the string "Hello ".
            //Creates a new string by adding "World" to the string "Hello ".
            //Creates a new string object in memory , gives it a value "Hello World", and stores it in str.
            //The original string, "Hello ", that was assigned to str is released for garbage collection because no other variable holds a reference to it.

                                                     //============== stringbuilder are mutable ===========//
            // Instead of creating a new string in memory ==> we update the existing string
        }
    }
}