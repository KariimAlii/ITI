using System;

namespace Lab4Task2
{
    public class Student
    {
        int id;
        string name;
        int[] grades;
        public int Id
        {
            set
            {
                Id = value;
            }
            get
            {
                return Id;
            }
        }
        public string Name
        {
            set
            {
                Name = value;
            }
            get
            {
                return Name;
            }
        }
        public int[] Grades
        {
            set
            {
                Grades = value;
            }
            get
            {
                return Grades;
            }
        }
        public Student()
        {
            Id = 0;
            Name = "N/A";
            Grades = new int[] { 0, 0, 0 };
        }
        public Student(int id, string name, int[] grades)
        {
            this.id = id;
            this.name = name;
            this.grades = grades;
        }
        public void print()
        {
            Console.WriteLine($"ID:{id}");
            Console.WriteLine($"Name:{name}");
            Console.WriteLine($"Grades:");
            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] grades = new int[] { 100, 200, 300 };
            Student Karim = new Student(1, "Karim", grades);
            Karim.print();
        }
    }
}
