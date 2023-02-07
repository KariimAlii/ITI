using System;


namespace Lecture4
{
    class Employee
    {
        private double Salary;
        private static int Count;
        public double getSalary()
        {
            return Salary;
        }
        public void setSalary(double Salary)
        {
            this.Salary = Salary;
        }

    }
    class Senior
    {
        public static void CustomizeSalary(out Employee emp)
        {
            emp = new Employee();
            emp.setSalary(7500);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee karim = new Employee();
            Console.WriteLine($"Salary:{karim.getSalary()}"); // 0
            karim.setSalary(5000);
            Console.WriteLine($"Salary:{karim.getSalary()}"); // 5000
            Senior.CustomizeSalary(out karim);
            Console.WriteLine($"Salary:{karim.getSalary()}"); // 7500
        }
    }
}



//var StudentNumber = 7;
//var StudentName = "Karim";

//var StudentsIDList = new[] { 1, 2, 3, 4, 5 };

//var StudentsNameList = new[] { "Karim", null, "Moataz" };
//foreach (var name in StudentsNameList) Console.WriteLine(name);

////var myName = null; // ERROR

//var x = 5;

//Console.WriteLine($"X:{x}");
//var y = x++;
//Console.WriteLine("var y = x++;");
//Console.WriteLine($"X:{x}");
//Console.WriteLine($"Y:{y}");
//var z = ++x;
//Console.WriteLine("var z = ++x;");
//Console.WriteLine($"X:{x}");
//Console.WriteLine($"Z:{z}");

//var a = 2;
////a = "krkr"; //ERROR
//a = 5; // ok
