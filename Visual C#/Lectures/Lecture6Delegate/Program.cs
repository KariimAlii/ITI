using System;
namespace Lecture6Delegate
{
    public class Test
    {
        public static int Welcome()
        {
            Console.WriteLine("Welcome!!");
            return 1;
        }
        public static int GoodBye()
        {
            Console.WriteLine("GoodBye!!");
            return 2;
        }
        public static void Print(MyDelegate m)
        {
            Console.WriteLine("Hello From Test Function..");
            int retVal = m();
            Console.WriteLine($"Return Value:{retVal}");
        }
    }
    public delegate int MyDelegate();
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Value of I..");
            int I = int.Parse(Console.ReadLine());
            MyDelegate m = null;
            if (I < 5)
            {
                m += new MyDelegate(Test.Welcome); // returns 1
                m += new MyDelegate(Test.GoodBye); // returns 2

            }
            else
            {
                m += new MyDelegate(Test.GoodBye); // returns 2
                m += new MyDelegate(Test.Welcome); // returns 1
            }
            Test.Print(m);
        }
    }
}
