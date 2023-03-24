using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[] { 20, 42, 54, 77, 82 };
            var scoreQuery = from score in scores
                             where score > 45
                             select score;

            foreach (var i in scoreQuery) Console.Write(i + ",");
            Console.WriteLine();


            scores[2] = 60;
            foreach (var i in scoreQuery) Console.Write(i + ",");
            Console.WriteLine();
        }
    }
}
