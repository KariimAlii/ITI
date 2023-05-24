using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;

namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //======================= EXERCISE 1 =======================// 
            // ask the user to enter a few numbers separated by a hyphen.
            // Work out if the numbers are consecutive.
            // if the input is "5-6-7-8-9" or "20-19-18-17-16",
            // display a message: "Consecutive";
            // otherwise, display "Not Consecutive".

            // My Solution
            //Console.WriteLine("Enter a few numbers separated by hyphen(-)");
            //var inputString =  Console.ReadLine();
            //var inputArray = inputString.Split('-');
            //var numbers = new int[inputArray.Length];
            //for (var i = 0; i < inputArray.Length; i++)
            //{
            //    var num = Convert.ToInt32(inputArray[i]);
            //    numbers[i] = num;
            //}
            //for (var i = 0; i < numbers.Length; i++)
            //{
            //    if (i == numbers.Length - 1)
            //    {
            //        Console.WriteLine("Consecutive");
            //        break;
            //    }
            //    if ( (numbers[i + 1] - numbers[i] == 1) || (numbers[i + 1] - numbers[i] == -1) ) continue;
            //    else
            //    {
            //        Console.WriteLine("Not Consecutive");
            //        break;
            //    }

            //}
             // ***********************OPTIMUM SOLUTION********************* //
            Console.Write("Enter a set of consecutive numbers separated by (-) (eg:1-2-3-4-5)");
            var inputString = Console.ReadLine();
            //Console.WriteLine(Consecutive(inputString));
            //======================= EXERCISE 2 =======================// 
            //ask the user to enter a few numbers separated by a hyphen.
            //If the user simply presses Enter, without supplying an input, exit immediately;
            //otherwise, check to see if there are duplicates.
            //If so, display "Duplicate" on the console.
            Console.Write("Enter a set of consecutive numbers separated by (-) (eg:1-2-3-4-5)");
            var input = Console.ReadLine();
            //Console.WriteLine(Duplicate(input));

            //======================= EXERCISE 3 =======================// 
            //ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
            //A valid time should be between 00:00 and 23:59.
            //If the time is valid, display "Ok";
            //otherwise, display "Invalid Time".
            //If the user doesn't provide any values,
            //consider it as invalid time.
            Console.Write("Enter Time in the 24-hour time format (e.g. 19:00)..                ");
            var inputDate = Console.ReadLine().Trim();
            Console.WriteLine(CheckTime(inputDate)); 



            //======================= EXERCISE 4 =======================//
            //ask the user to enter a few words separated by a space.
            //Use the words to create a variable name with PascalCase.
            //EX : if the user types: "number of students", display "NumberOfStudents".
            //Make sure that the program is not dependent on the input.
            //So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".
            Console.Write("Enter few words separated by spaces (eg: krkr krakiro roro)...          ");
            var inp = Console.ReadLine().ToLower();
            //Console.WriteLine(PascalCase(inp));

            //======================= EXERCISE 5 =======================//
            //ask the user to enter an English word.
            //Count the number of vowels (a, e, o, u, i) in the word.
            //So, if the user enters "inadequate",
            //the program should display 6 on the console.
            Console.Write("Enter a word containing vowels....      ");
            var word = Console.ReadLine();
            //Console.WriteLine(CountVowels(word));
        }
        //==========EX1===========//
        public static string Consecutive(string inputString) 
        {
            var numbers = new List<int>();
            foreach (var num in inputString.Split('-')) numbers.Add(Convert.ToInt32(num));
            numbers.Sort();
            var isConsecutive = true;
            for (var i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] - numbers[i - 1] != 1)
                {
                    isConsecutive = false;
                    break;
                }
            }
            var message = (isConsecutive) ? "Consecutive" : "Not Consecutive";
            return message;
        }
        //==========EX2===========//
        public static string Duplicate(string inputString)
        {
            
            if (String.IsNullOrWhiteSpace(inputString)) return "exit!";
            var numbers = new List<int>();
            foreach (var num in inputString.Split('-')) numbers.Add(Convert.ToInt32(num));
            //========first solution========//
            //numbers.Sort();
            //var isDuplicate = false;
            //for (int i = 1; i < numbers.Count; i++)
            //{
            //    if (numbers[i] == numbers[i - 1]) isDuplicate = true;
            //}
            //var message = (isDuplicate) ? "Duplicate" : "Non Duplicate";
            //return message;
            //========second solution========//
            var uniques = new List<int>();
            var isDuplicate = false;
            foreach (var num in numbers)
            {
                if (!uniques.Contains(num))
                {
                    uniques.Add(num);
                }
                else
                {
                    isDuplicate = true;
                    break;
                }
            }
            var message = (isDuplicate) ? "Duplicate" : "Non Duplicate";
            return message;
        }
        //==================EX3==================//

        public static string CheckTime(string inputDate)
        {
            if (String.IsNullOrWhiteSpace(inputDate))
            {
                return "No Answer !!";
            }


            var components = inputDate.Split(':');
            // foreach (var k in components) Console.WriteLine("\'{0}\'",k);
            // Console.WriteLine("Components Array Length : {0}",components.Length);      // even if the user inputs (22:) the components array length = 2 , components are '22' and ''
            if (components.Length != 2)
            {
                return "Invalid Time Format ..." ;
            }
            try
            {
                var hour = components[0];
                var minute = components[1];
                if (Convert.ToInt32(hour) > 23 || Convert.ToInt32(hour) < 0 || Convert.ToInt32(minute) > 59 || Convert.ToInt32(minute) < 0) return "Invalid Time ...";
                else return "OK! :)" ;
            }
            catch (Exception)
            {
                return "Invalid Time Format ..." ;
            }
        }
        //==================EX4==================//
        public static string PascalCase (string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return "";
            var words = new List<string>();
            foreach (var word in input.Split(' ')) words.Add(word);
            for (var i = 0; i < words.Count; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return String.Join("", words);
        }
        //================EX5===================//
        public static string CountVowels (string word)
        {
            var vowels = new List<char>() {'a' , 'e' , 'i' , 'u' , 'o' };
            var vowelsIncluded = new List<char>();
            foreach (var character in word.ToLower())
            {
                if (vowels.Contains(character)) vowelsIncluded.Add(character);
            }
            return $"Number of vowels is: {vowelsIncluded.Count}";
        }
    }
}