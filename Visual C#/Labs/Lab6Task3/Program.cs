using System;
//Write a class “point” has 2 points as generic type.
//In the constructor take 2 points as a parameter
//And print the position is x and y as string

namespace Lab6Task3
{
    class Point<M>
    {
        M x;
        M y;
        public Point(M x, M y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "X= " + x.ToString() + ", Y = " + y.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter X coordinate :");
            float x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y coordinate :");
            float y = float.Parse(Console.ReadLine());
            Point<float> karim = new Point<float>(x, y);
            Console.WriteLine(karim.ToString());
        }
    }
}
