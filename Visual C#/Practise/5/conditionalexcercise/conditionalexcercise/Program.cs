using System;
using static conditionalexcercise.Conditional;

namespace conditionalexcercise
{
    public class Conditional
    {
        public static void Exercise1()
        {
            Console.WriteLine("Insert a number!");
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            if (number >= 0 && number <= 10)
                Console.WriteLine("Valid :)");
            else
                Console.WriteLine("Not Valid!!");
        }
        public static void Exercise2()
        {
            Console.WriteLine("Insert 2 Numbers!!");
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            int a = Convert.ToInt32(input1);
            int b = Convert.ToInt32(input2);
            if (a > b) Console.WriteLine("{0} is the max" , input1);
            else Console.WriteLine("{0} is the max" , input2);
        }
        public enum imageOrientation
        {
            Landscape,
            Portrait
        }
        public static void Exercise3()
        {
            Console.WriteLine("Insert the height of the picture..");
            var height = Convert.ToInt32( Console.ReadLine() );
            Console.WriteLine("Insert the width of the picture..");
            var width = Convert.ToInt32( Console.ReadLine() );
            var max = (height > width) ? imageOrientation.Portrait : imageOrientation.Landscape;
            Console.WriteLine("Your Picture is {0}", max);

        }
        public static void Exercise4()
        {
            Console.WriteLine("Insert the speed limit!");
            var speedLimit = Convert.ToInt32( Console.ReadLine() );
            Console.WriteLine("Insert your car speed ..");
            var carSpeed = Convert.ToInt32(Console.ReadLine());
            if (carSpeed <= speedLimit)
                Console.WriteLine("OK :)");
            else
            {
                const int KMperDemeritPoint = 5;
                int pointsNumber = (carSpeed - speedLimit) / KMperDemeritPoint;
                if (pointsNumber > 12)
                    Console.WriteLine("Licensce suspended !!");
                else
                    Console.WriteLine("demerit points are {0} points", pointsNumber);
            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            //======= EX1 ======//
            Conditional.Exercise1();
            //======= EX2 ======//
            Conditional.Exercise2();
            //======= EX3 ======//
            Conditional.Exercise3();
            // Console.WriteLine(imageOrientation.Landscape);
            // Console.WriteLine(imageOrientation.Portrait);
            //======= EX4 ======//
            Conditional.Exercise4();
        }
    }
}