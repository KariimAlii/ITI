using System;
namespace referencetype
{
    public class Person
    {
        public int age;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //====== VALUE TYPE ======//
            int num = 4;
            Increment(num);
            Console.WriteLine(num); // 4 Not changed

            //====== REFERENCE TYPE ======//
            var karim = new Person() { age = 20 };
            Decrement(karim);
            Console.WriteLine(karim.age); // 10 changed
        }
        public static void Increment(int number)
        {
            number += 10;
        }

        public static void Decrement(Person person)
        {
            person.age -= 10;
        }
    }
}