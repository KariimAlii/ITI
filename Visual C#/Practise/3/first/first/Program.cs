using System;
namespace first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("{0} {1}",byte.MaxValue,byte.MinValue);
            // Console.WriteLine("{0} {1}",float.MinValue,float.MaxValue);
            const float b = 3.495f;
            // b = 1; // a constant can't be reassigned
            Console.WriteLine(b);
            //========================Type Conversion========================//
            //Not Compatible types
            string s = "23";
            int i = Convert.ToInt32(s); // string => integer
            int j = int.Parse(s); // string => integer
            Console.WriteLine(i);
            Console.WriteLine(j);
            // Implicit casting for compatible types  small to large
            byte h = 22;
            int p = h;
            Console.WriteLine(p);
            // Explicit casting for compatible types ignoring storage loss large to small
            int w = 1000;
            byte r = (byte) w;
            Console.WriteLine(r);
            try
            {
                string number = "1234";
                // int q = (int)number;
                // int q = Convert.ToInt32(number);
                byte q = Convert.ToByte(number);
                Console.WriteLine(q);

            }
            catch (Exception)
            {
                Console.WriteLine("The Number couldnot be converted to a byte!!");
            }
            string t = "true";
            bool toto = Convert.ToBoolean(t);
            Console.WriteLine(toto); // converted to boolean=>True

        }
    }
}