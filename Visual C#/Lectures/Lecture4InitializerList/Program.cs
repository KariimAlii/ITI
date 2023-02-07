using System;
namespace Lecture4InitializerList
{
    public class Date
    {
        private int Year;
        private int Month;
        private int Day;
        public Date() : this(1991, 6, 30)
        {
            Console.WriteLine("Welcome in Original Constructor");
        }
        public Date(int Year, int Month, int Day)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            Console.WriteLine("Welcome in Forwarded Constructor");
        }
        public int getYear() { return Year; }
        public int getMonth() { return Month; }
        public int getDay() { return Day; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // I.Declaration
            Date BirthDay;
            // II. Creation
            // a.Allocation using new keyword
            // b.Initialization using the constructor
            BirthDay = new Date();
            Console.WriteLine(BirthDay);
            Console.WriteLine($"BirthDay Year:{BirthDay.getYear()}"); // 1991
            Console.WriteLine($"BirthDay Month:{BirthDay.getMonth()}"); // 6
            Console.WriteLine($"BirthDay Day:{BirthDay.getDay()}"); // 30
        }
    }
}
