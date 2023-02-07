using System;
using static Lecture4StaticConstructor.Program;

namespace Lecture4StaticConstructor
{
    internal class Program
    {
        public class Student
        {
            private int Id;
            private string Name;
            public static string Department;
            static Student()
            {
                Department = "Science";
                Console.WriteLine("Hey from Static Constructor!");
            }
            public Student(int Id, string Name)
            {
                this.Id = Id;
                this.Name = Name;
                Console.WriteLine("Hey from Instance Constructor!");
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Student.Department);
            // I. Declaration
            Student karim;
            // II. Creation
            // a. Allocation using new Keyword
            // b. Initialization using the constructor
            karim = new Student(2, "karim");
        }
    }
}
//Student.Department = "Mathematics";

