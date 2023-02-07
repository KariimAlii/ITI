using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture1CS
{
    internal class Program
    {
        struct Employee
        {
            public string fullName;
            public int age;

        }
        static void Main(string[] args)
        {

            Employee Developer;
            Developer.fullName = "Karim Ali";
            Console.WriteLine($"Karim.firstName: {Developer.fullName}");
        }

    }
}







