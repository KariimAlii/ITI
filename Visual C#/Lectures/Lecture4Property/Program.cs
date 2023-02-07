using System;
namespace Lecture4Property
{
    public class Point
    {

        public int X { set; get; }
        public int Y { set; get; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point { X = 2, Y = 4 };
            Console.WriteLine($"X:{p.X}");
            Console.WriteLine($"Y:{p.Y}");
        }
    }
}
