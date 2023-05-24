using System;
using System.Reflection.Metadata.Ecma335;

namespace loopexercise
{
    
    internal class Program
    {
        public static void Exercise1()
        {
            var count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0) count++;
            }
            Console.WriteLine("There are {0} numbers devisible by 3 between 1 and 100",count);
        }
        public static void Exercise2()
        {
            var sum = 0;
            //============== using While loop , break keyword ========//
            
            while (true)
            {
                Console.Write("Enter a Number or OK to exit..");
                var inputString = Console.ReadLine();
                int result;
                if (int.TryParse(inputString, out result) == false && inputString.ToLower() != "ok")
                {
                    Console.WriteLine("Please enter a correct input !!");
                    continue;
                }
                else if (inputString.ToLower() == "ok")
                {
                    break;
                }
                var inputNumber = Convert.ToInt32( inputString );
                sum += inputNumber;
                
            }
            Console.WriteLine("Sum of your numbers is {0}", sum);
            
            //============== using While loop , break & continue keyword ========//
            /*
            while (true)
            {
                Console.Write("Enter a Number or OK to exit..");
                var inputString = Console.ReadLine();
                int result;
                if (inputString.ToLower() != "ok")
                {
                    if (int.TryParse(inputString, out result) == false)
                    {
                        Console.WriteLine("please enter a correct respond!!");
                        continue;
                    } else
                    {
                        var inputNumber = Convert.ToInt32(inputString);
                        sum += inputNumber;
                        continue;
                    }
                    
                }
                Console.WriteLine("Sum of your numbers is {0}", sum);
                break;
            }
            */
        }
        public static void Exercise3()
        {
            while(true)
            {
                Console.Write("Please enter a positive number! ..");
                var number = Convert.ToInt32(Console.ReadLine());
                if ( number <= 0)
                {
                    continue;
                }
                var factorial = 1;
                for (var i = number; i >= 1; i--)
                {
                    factorial *= i;
                }
                Console.WriteLine("{0}! = {1}",number,factorial);
                break;
            }

        }
        public static void Exercise4()
        {
            var random = new Random();
            var num = random.Next(1,10);
            Console.WriteLine("The random number is {0}",num);
            var guess = 0;
            while (guess < 4)
            {
                Console.Write("Guess the random number between 1 and 10 ! you have {0} left chances !", 4 - guess);
                var guessNum = Convert.ToInt32( Console.ReadLine() );
                guess += 1;
                if (guessNum == num)
                {
                    Console.WriteLine("You won !!");
                    break;
                } else if (guess == 4)
                {
                    Console.WriteLine("Good luck next time !:)");
                }
                else
                {
                    Console.WriteLine("Oh naa :(");
                    continue;
                }
            }
        }
        public static void Exercise5()
        { 
            Console.Write("Enter a series of numbers separated by commas (,) ..");
            var inputString = Console.ReadLine();
            var stringsArray = inputString.Split(",");
            var numbersArray = new int[stringsArray.Length];
            for (var i = 0; i < stringsArray.Length;i++)
            {
                numbersArray[i] = Convert.ToInt32(stringsArray[i]);
            }
            var maxNum = numbersArray[0];
            for (var i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] > maxNum) maxNum = numbersArray[i];
            }
            Console.WriteLine("Maximum Number is {0}" , maxNum);
        }
        static void Main(string[] args)
        {
            // Exercise1();
            // Exercise2();
            // int x = 3;
            // console.writeline(x.gettype());
            // Exercise3();
            /* //====== EX5 =======//
            var krsha = new string[4] { "1" , "2" , "7" , "4"};
            var krkr = new int[krsha.Length];
            for (var i = 0; i < krsha.Length;i++)
            {
                krkr[i] = Convert.ToInt32(krsha[i]);
            }
            var maxim = krkr[0];
            // foreach (var k in krkr) Console.WriteLine(k);
            for (var i = 0; i < krkr.Length;i++)
            {
                if (krkr[i] > maxim) maxim = krkr[i];
            }
            Console.WriteLine("Maximum Number is {0}" , maxim);
            */
            Exercise5();
        }
    }
}