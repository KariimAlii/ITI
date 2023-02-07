using System;

namespace Lab2
{
    internal class Program
    {
        public class Student
        {
            private string Name;
            private int Password;
            public void setName(string Name)
            {
                this.Name = Name;
            }
            public void setPassword(int Password)
            {
                this.Password = Password;
            }
            public string getName()
            {
                return this.Name; //  return Name
            }
            public int getPassword()
            {
                return this.Password; // return Password
            }
            public Student()
            {
                Name = null;
                Password = 0;
            }
            public Student(string Name, int Password)
            {
                this.Name = Name;
                this.Password = Password;
            }
            public static Student InsertStudentData()
            {
                Student Std = new Student();
                Console.WriteLine("Enter Your Name..");
                Std.setName(Console.ReadLine());

                Console.WriteLine("Enter Your Password..");
                Std.setPassword(int.Parse(Console.ReadLine()));
                return Std;
            }
            public string CheckStudentData(Student CompareStd)
            {
                if (this.Name == CompareStd.getName() && this.Password == CompareStd.getPassword())
                {
                    return "Welcome! :)";
                }
                else
                {
                    return "Wrong Login !!";
                }
            }
        }


        static void Main(string[] args)
        {
            Student CompareStudent = new Student("Marawan Ali", 54326);

            Student InputStudent = Student.InsertStudentData();

            Console.WriteLine(InputStudent.CheckStudentData(CompareStudent));
        }
    }
}
//Student Karim = new Student();
//Console.WriteLine($"Karim's Name:{Karim.getName()}");
//Console.WriteLine($"Karim's Password:{Karim.getPassword()}");

//Console.WriteLine($"User's Name:{CompareStudent.getName()}");
//Console.WriteLine($"User's Password:{CompareStudent.getPassword()}");


//public static string CheckStudentData(Student InputStd, Student CompareStd)
//{
//    if (InputStd.getName() == CompareStd.getName() && InputStd.getPassword() == CompareStd.getPassword())
//    {
//        return "Welcome! :)";
//    }
//    else
//    {
//        return "Wrong Login !!";
//    }
//}
//Console.WriteLine(CheckStudentData(InputStudent, CompareStudent));
