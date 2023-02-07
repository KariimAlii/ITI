using System;
namespace Lecture3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ar;
            ar = new int[5] { 1, 2, 3, 4, 5 };
            //ar = new int[5] { 1, 2, 3, 4 }; // ERROR : No Partial Initialization
            //Console.WriteLine(ar[5]); // ERROR: OUT OF BOUNDARIES

            Console.WriteLine("Elements of the original array with Size 5 :");
            foreach (int i in ar)
            {
                Console.WriteLine(i);
            }
            int[] ar1;
            ar1 = new int[7];
            for (int i = 0; i < ar.Length; i++) ar1[i] = ar[i];
            ar = ar1;
            ar1[5] = 6;
            ar1[6] = 7;
            Console.WriteLine("Elements of the copy array with Size 7 :");
            foreach (int i in ar1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Elements of the original array with Size 5 :");
            foreach (int i in ar)
            {
                Console.WriteLine(i);
            }

        }
    }
}
