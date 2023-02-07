using System;
using System.Text;

//Write a method (calculations) take 3 parameters “
//operation + -* \ , num 1 , num 2 )
//• Delegate
//• Anonymous method
//• Lambda operator

namespace Lab6Task2
{
    public delegate float Calculation(int a, int b);
    public class CalculatorFunctions
    {
        public static float Add(int a, int b)
        {
            return a + b;
        }
        public static float Subtract(int a, int b)
        {
            return a - b;
        }
        public static float Multiply(int a, int b)
        {
            return a * b;
        }
        public static float Devide(int a, int b)
        {
            return a / b;
        }
        public static float operate(int a, int b, Calculation f)
        {
            return f(a, b);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = Console.ReadLine();
                int a = int.Parse(s[0].ToString());
                int b = int.Parse(s[2].ToString());
                string operation = s[1].ToString();
                Calculation f = new Calculation(CalculatorFunctions.Add);
                switch (operation)
                {
                    case "+":
                        f = new Calculation(CalculatorFunctions.Add);
                        break;
                    case "-":
                        f = new Calculation(CalculatorFunctions.Subtract);
                        break;
                    case "*":
                        f = new Calculation(CalculatorFunctions.Multiply);
                        break;
                    case "/":
                        f = new Calculation(CalculatorFunctions.Devide);
                        break;
                }
                float Result = CalculatorFunctions.operate(a, b, f);
                Console.WriteLine(Result);

                Console.WriteLine("******Using Anonymous Method*******");
                float Result2 = CalculatorFunctions.operate(4, 5, delegate (int x, int y) { return x + y; });
                Console.WriteLine(Result2);
                Console.WriteLine("******Using Lambpa Expression*******");
                float Result3 = CalculatorFunctions.operate(4, 5, (int q, int z) => q / z);
                Console.WriteLine(Result3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try Again!! like 1+2");
            }

        }
    }
}

//StringBuilder s = new StringBuilder();
//char a = Console.ReadKey().KeyChar;
//char b = Console.ReadKey().KeyChar;
//char c = Console.ReadKey().KeyChar;
//s.Append(a);
//s.Append(b);
//s.Append(c);
//Console.WriteLine(s);
