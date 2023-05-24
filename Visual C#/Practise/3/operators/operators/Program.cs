using System;
namespace operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Postfix Increment => first a is assigned to b then it's incremented by 1
            int a = 1;
            int b = a++;
            // Console.WriteLine(a); // 2
            // Console.WriteLine(b); // 1

            // Prefix Increment => first c is incremented by 1 then it's assigned to b
            int c = 1;
            int d = ++c;
            // Console.WriteLine(c); // 2
            // Console.WriteLine(d); // 2

            // Arithmetic Operators
            var x = 3;
            var y = 10;

            // Console.WriteLine(y / x);  // if y , x are integers => y/x must be integer => 10/3 = 3
            // to catch its decimal value use float
            Console.WriteLine((float)y / (float)x );  // 3.33333333333

            // Precedence
            var z = 5;
            Console.WriteLine(z + x * y); // 35


            // Comparison Operators

            Console.WriteLine(x > y); // False

            byte q = 4;
            int p = 4;
            Console.WriteLine(q == p); //True
            Console.WriteLine(q != p); //False

        }
    }
}