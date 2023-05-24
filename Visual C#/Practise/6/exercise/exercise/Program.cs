using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

namespace exercise
{
    internal class Program
    {
        public static void Exercise1()
        {
            var likeList = new List<string>();
            while (true)
            {
                Console.Write("Enter the Names who like user's Posts ..      ");
                var input = Console.ReadLine();
                /*
                if ( !String.IsNullOrWhiteSpace(input) ) 
                {
                    likeList.Add(input);
                } else
                {
                    break;
                }
                */
                if (String.IsNullOrWhiteSpace(input)) break;
                likeList.Add(input);
            }

            switch (likeList.Count)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("{0} likes your post.", likeList[0]);
                    break;
                case 2:
                    Console.WriteLine("{0} and {1} like your post." , likeList[0] , likeList[1]);
                    break;
                default: // (likeList.Count) > 2
                    Console.WriteLine("{0} and {1} and {2} other people like your post.", likeList[0], likeList[1] , likeList.Count-2);
                    break;
            }
        }
        public static void Exercise2()
        {
            //======== First Solution : using built-i Methods =========//
            //Console.Write("Enter Your Name...             ");
            //var inputString = Console.ReadLine();
            //var inputArray = inputString.ToCharArray();
            //Array.Reverse(inputArray);
            //var reversedString = String.Join("", inputArray);
            //Console.WriteLine("your reversed name is {0}", reversedString);
            //======== Second Solution : without using built-in Methods =========//
            Console.Write("Enter Your Name...             ");
            var inputString = Console.ReadLine();
            var reversedArray = new char[inputString.Length];
            for (var i = 0; i < inputString.Length; i++) reversedArray[i] = inputString[inputString.Length-i-1];
            var reversedString = new string(reversedArray);
            Console.WriteLine("your reversed name is {0}", reversedString);
        }
        public static void Exercise3()
        {
            // 3 - Write a program and ask the user to enter 5 numbers.
            // If a number has been previously entered, display an error message
            // and ask the user to re-try.
            // Once the user successfully enters 5 unique numbers,
            // sort them and display the result on the console.
            //============= First Solution ==============//
            //var numbers = new List<int>();
            //bool repeated = false;
            //while (true)
            //{
            //    repeated = false;
            //    Console.Write("Enter {0} unique numbers ..               ", 5 - numbers.Count);
            //    var newNum = Convert.ToInt32(Console.ReadLine());
            //    foreach (var number in numbers)
            //    {
            //        if (number == newNum)
            //        {
            //            Console.WriteLine("This Number is repeated !Retry with a unique number !");
            //            repeated = true;
            //        }
            //    }
            //    if (repeated) continue;
            //    numbers.Add(newNum);
            //    if (numbers.Count == 5) break;
            //}
            //numbers.Sort();
            //foreach (var k in numbers) Console.WriteLine(k);
            //============= Cleaner Solution ==============//
            var numbers = new List<int>();

            while (numbers.Count < 5)
            {

                Console.Write("Enter {0} unique numbers ..               ", 5 - numbers.Count);
                var newNum = Convert.ToInt32(Console.ReadLine());
                if (numbers.Contains(newNum))
                {
                    Console.WriteLine("This Number is repeated !Retry with a unique number !");
                    continue;
                }
                numbers.Add(newNum);
            }
            numbers.Sort();
            foreach (var k in numbers) Console.WriteLine(k);
        }
        public static void Exercise4()
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

            //==================== first solution : don't permit to enter the same number twice ===========//
            var numbers = new List<int>();
            
            // numbers list
            while (true)
            {
                Console.Write("Enter a Number or type quit to exit ..                 ");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit") break;
                var newNum = Convert.ToInt32(input);
                numbers.Add(newNum);
            }
            // unique list
            // var uniqueList = numbers.Distinct(); //.ToList()   // it gives unique values , leaves one value from every duplicate value , [1,1,2,2,3,4,5] => [1,2,3,4,5] , it doesnot remove 1,2
            // https://www.dotnetperls.com/duplicates
            var uniqueList = new List<int>();
            foreach (var number in numbers)
            {
                if ( !uniqueList.Contains(number) )
                {
                    uniqueList.Add(number); // [1,1,2,2,3,4,5] => [1,2,3,4,5] , it doesnot remove 1,2
                } else
                {
                    uniqueList.Remove(number); // [1,1,2,2,3,4,5] => [3,4,5] , it removes 1,2
                }
            }
            Console.WriteLine("The Unique List :  ");
            foreach (var k in uniqueList) Console.WriteLine(k);

        }
        public static void Exercise5()
        {
            // 5- Write a program and ask the user to
            // supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10).
            // If the list is empty or includes less than 5 numbers,
            // display "Invalid List" and ask the user to re-try;
            // otherwise, display the 3 smallest numbers in the list.
            while (true)
            {
                Console.Write("Enter 5 numbers separated with (,)             ");
                var inputString = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(inputString))
                {
                    Console.WriteLine("Invalid List , Please Retry !");
                    continue;
                }
                var inputArray = inputString.Split(",");
                // foreach (var k in inputArray) Console.WriteLine(k);
                if (inputArray.Length < 5)
                {
                    Console.WriteLine("Invalid List , Please Retry !");
                    continue;
                }
                var numbers = new List<int>();
                foreach (var num in inputArray) numbers.Add(Convert.ToInt32(num));
                var smallest = new List<int>();
                while (smallest.Count < 3)
                {
                    var min = numbers[0];
                    foreach (var num in numbers)
                    {
                        if (num < min) min = num;
                    }
                    smallest.Add(min);
                    numbers.Remove(min);
                }
                Array.Sort(inputArray);
                Console.WriteLine("The minimum 3 numbers are :");
                foreach (var number in smallest) Console.WriteLine(number);
                break;
            }
            
            
        }
        static void Main(string[] args)
        {
            //Exercise1();
            //Exercise2();
            //Exercise3();
            // Exercise4();
            Exercise5();
        }
    }
}
/*
 Note: For any of these exercises, ignore input validation unless otherwise directed. Assume the user enters values in the format that the program expects.



1- When you post a message on Facebook, depending on the number of people who like your post, Facebook displays different information.

If no one likes your post, it doesn't display anything.
If only one person likes your post, it displays: [Friend's Name] likes your post.
If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.
Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name). Depending on the number of names provided, display a message based on the above pattern.



2- Write a program and ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. Display the reversed name on the console.



3- Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and display the result on the console.



4- Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may include duplicates. Display the unique numbers that the user has entered.



5- Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display the 3 smallest numbers in the list.
 */