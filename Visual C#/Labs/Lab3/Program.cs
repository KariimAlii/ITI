using System;

namespace Lab3
{

    internal class Program
    {
        public static void FillStudentsGrades(ref int[][] Students)
        {
            for (int iterator = 0; iterator < Students.Length; iterator++)
            {
                Console.WriteLine($"Enter The Subjects Number for Student No#{iterator + 1}");
                int SubjectsNumber = int.Parse(Console.ReadLine());
                Students[iterator] = new int[SubjectsNumber];
                for (int j = 0; j < SubjectsNumber; j++)
                {
                    Console.WriteLine($"Enter The Subject No#{j + 1} Grade");
                    int Grade = int.Parse(Console.ReadLine());
                    Students[iterator][j] = Grade;
                }
            }
        }
        public static int StudentGradesSum(int[] StudentGrades)
        {
            int Sum = 0;
            for (int iterator = 0; iterator < StudentGrades.Length; iterator++)
            {
                Sum += StudentGrades[iterator];
            }
            return Sum;
        }
        public static int StudentGradesAverage(int[] StudentGrades)
        {
            int Average;
            int Sum = StudentGradesSum(StudentGrades);
            Average = Sum / StudentGrades.Length;
            return Average;
        }
        public static void PrintStudentSumAndAverage(int[][] Students)
        {
            int Sum, Average;
            for (int iterator = 0; iterator < Students.Length; iterator++)
            {

                Sum = StudentGradesSum(Students[iterator]);
                Console.WriteLine($"The Student No # {iterator + 1} Sum : {Sum}");
                Average = StudentGradesAverage(Students[iterator]);
                Console.WriteLine($"The Student No # {iterator + 1} Average : {Average}");

            }
        }
        static void Main(string[] args)
        {
            int[][] Students;
            Students = new int[3][];
            FillStudentsGrades(ref Students);
            PrintStudentSumAndAverage(Students);
        }
    }
}
