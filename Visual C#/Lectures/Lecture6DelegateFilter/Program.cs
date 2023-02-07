using System;
using System.Collections;

namespace Lecture6DelegateFilter
{
    public delegate bool FilterArray(int num);
    public class Utilities
    {
        public static int[] Filter(int[] numbers, FilterArray f)
        {
            ArrayList FilteredList = new ArrayList();
            foreach (var num in numbers)
            {
                if (f(num)) FilteredList.Add(num);
            }
            int[] FilteredArray = (int[])FilteredList.ToArray(typeof(int));
            return FilteredArray;
        }
    }
    public class FilterFunctions
    {
        public static bool isOdd(int num)
        {
            if (num % 2 != 0) return true;
            else return false;
        }
        public static bool isEven(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // First Method For Passing the method : Delegate Object
            //======================================================
            //FilterArray f = new FilterArray(FilterFunctions.isOdd);
            //int[] odds = Utilities.Filter(numbers, f);
            //Console.WriteLine("Odd:");
            //foreach (var odd in odds) Console.WriteLine(odd);
            //Console.WriteLine("Even:");
            //int[] evens = Utilities.Filter(numbers, FilterFunctions.isEven);
            //foreach (var even in evens) Console.WriteLine(even);
            // Second Method For Passing the method : Anonymous Method
            //===============================================================
            int[] odds = Utilities.Filter(numbers, delegate (int num) { return num % 2 != 0; });
            Console.WriteLine("Odd:");
            foreach (var odd in odds) Console.WriteLine(odd);
            // Third Method For Passing the method : Lambda Expression
            //===============================================================
            int[] evens = Utilities.Filter(numbers, (int num) => { return num % 2 == 0; });
            //int[] evens = Utilities.Filter(numbers, (int num) => (num % 2 == 0));
            //int[] evens = Utilities.Filter(numbers, (int num) => num % 2 == 0);
            Console.WriteLine("Even:");
            foreach (var even in evens) Console.WriteLine(even);

        }
    }
}





