using System;
using System.Collections;
namespace Lecture5Arraylist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList EmployeeNames = new ArrayList();
            EmployeeNames.Add("Karim");
            EmployeeNames.Add(1);
            EmployeeNames.Add(true);
            EmployeeNames.Add(null);
            foreach (object Employee in EmployeeNames) Console.WriteLine(Employee);
        }
    }
}
