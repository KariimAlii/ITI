using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private int[] Grades = new int[3];
        public List<string> Hobbies { get; set; }
        public int this[int index]
        {
            get
            {
                return Grades[index];
            }
            set
            {
                Grades[index] = value;
            }


        }

        public void print()
        {
            Console.WriteLine($"ID:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Grades:");
            foreach (int grade in Grades)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine($"Hobbies:");
            foreach (var hobby in Hobbies)
            {
                Console.WriteLine(hobby);
            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] grades = new int[] { 100, 200, 300 };
                List<string> hobbies = new List<string>();
                hobbies.Add("Football");
                hobbies.Add("Music Production");
                // Using Object Initializer

                Student Karim = new Student() { Id = 1, Name = "Karim", Hobbies = hobbies };
                Karim[0] = grades[0];
                Karim[1] = grades[1];
                Karim[2] = grades[2];
                Karim[3] = grades[2];
                Karim.print();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("OUT OF RANGE!!!!!!!!!!!!!!!!!!!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
