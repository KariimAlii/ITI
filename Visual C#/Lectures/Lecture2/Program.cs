using System;


namespace Lecture2
{
    internal class Program
    {

        public static int Sum(float a , long b , params int[]numbers)
        {
            int S = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                S += numbers[i];
            }
            return S;
        }
        static void Main(string[] args)
        {
            int y = Sum(5.0f,2000,1, 2, 3, 4);
            Console.WriteLine($"Sum of Y = {y}");
        }
    }
}

//public static void Converter(out int n)
//{
//    n = 7;
//}
//static void Main(string[] args)
//{
    //int x;
    //Converter(out x);
    //Console.WriteLine($"x: {x}");
//}