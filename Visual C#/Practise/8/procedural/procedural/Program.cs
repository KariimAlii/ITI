using System;
using System.Collections.Generic;

namespace procedural
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What's your name?");
            var name = Console.ReadLine();
            var reversedName = ReverseName(name);
            Console.WriteLine($"Your reversed name is : \"{reversedName}\" ");

            var numbers = new List<int>();
            while (true)
            {
                Console.Write("Enter a Number or type quit to exit ..                 ");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit") break;
                var newNum = Convert.ToInt32(input);
                numbers.Add(newNum);
            }


            Console.WriteLine("The Unique List :  ");
            foreach (var k in GetUniques(numbers)) Console.WriteLine(k);
        }
        public static string ReverseName(string name)
        {
            char[] reversedArray = new char[name.Length];
            for (var i = 0; i < name.Length; i++) reversedArray[i] = name[name.Length - 1 - i];
            // var reversedName = String.Join("", reversedArray);
            return new String(reversedArray);
        }

        public static List<int> GetUniques(List<int> numbers)
        {
            // 4- Write a program and ask the user to
            // continuously enter a number
            // or type "Quit" to exit.
            // The list of numbers may include duplicates.
            // Display the unique numbers that the user has entered.

            //==================== first solution : don't permit to enter the same number twice ===========//
            //var uniqueList = new List<int>();
            //while (true)
            //{
            //    Console.Write("Enter a Number or type quit to exit ..                 ");
            //    var input = Console.ReadLine();
            //    if (input.ToLower() == "quit") break;
            //    var newNum = Convert.ToInt32(input);
            //    if (uniqueList.Contains(newNum))
            //    {
            //        uniqueList.Remove(newNum);
            //        continue;
            //    }
            //    uniqueList.Add(newNum);
            //}
            //foreach (var k in uniqueList) Console.WriteLine(k);

            //==================== second solution :  permit to enter the same number twice ===========//


            // numbers list

            // unique list
            // var uniqueList = numbers.Distinct(); //.ToList()   // it gives unique values , leaves one value from every duplicate value , [1,1,2,2,3,4,5] => [1,2,3,4,5] , it doesnot remove 1,2
            // https://www.dotnetperls.com/duplicates
            var uniqueList = new List<int>();
            foreach (var number in numbers)
            {
                if (!uniqueList.Contains(number)) 
                    uniqueList.Add(number); // [1,1,2,2,3,4,5] => [1,2,3,4,5] , it doesnot remove 1,2
                // else uniqueList.Remove(number); // [1,1,2,2,3,4,5] => [3,4,5] , it removes 1,2
            }
            return uniqueList;


        }
    }
}