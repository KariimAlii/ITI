using System;
namespace Lecture4StaticCLass
{
    public static class Calculator
    {
        private static int Result = 0;
        public static string Type = "Scientific Calculator";
        public static int Add(ref int a, ref int b)
        {
            Result = a + b;
            return Result;
        }
        public static int Multiply(ref int a, ref int b)
        {
            Result = a * b;
            return Result;
        }
        public static int getResult()
        {
            return Result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5, b = 4;
            Console.WriteLine(Calculator.Type);
            var Sum = Calculator.Add(ref a, ref b);
            Console.WriteLine($"Sum:{Sum}");
            Console.WriteLine($"Stored Result:{Calculator.getResult()}");
            Console.WriteLine("=======================================");
            var Product = Calculator.Multiply(ref a, ref b);
            Console.WriteLine($"Product:{Product}");
            Console.WriteLine($"Stored Result:{Calculator.getResult()}");
        }
    }
}
