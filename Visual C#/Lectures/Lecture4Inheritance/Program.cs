using System;
namespace Lecture4Inheritance
{
    public class MyCLass
    {
        private int id;
        protected string name;
        public MyCLass()
        {
            id = 1;
            name = "Karim";
            Console.WriteLine("Hi from MyCLass Default Constructor!");
        }
        public MyCLass(int id, string name)
        {
            this.id = id;
            this.name = name;
            Console.WriteLine("Hi from MyCLass Parameterized Constructor!");
        }
        public virtual void Sing(string name)
        {
            Console.WriteLine($"La la la la Base Class Capten {name}");
        }
    }
    public class Derived1 : MyCLass
    {
        public Derived1()
        {
            Console.WriteLine("Hi from Derived1 Default Constructor!");
        }
        public Derived1(int id, string name) : base(id, name)
        {
            Console.WriteLine("Hi from Derived1 Parameterized Constructor!");
        }
        public override void Sing(string name)
        {
            Console.WriteLine($"La la la la Derived1 Class Capten {name}");
        }
    }
    public class Derived2 : Derived1
    {
        public Derived2()
        {
            Console.WriteLine("Hi from Derived2 Default Constructor!");
        }
        public Derived2(int id, string name) : base(id, name)
        {
            Console.WriteLine("Hi from Derived2 Parameterized Constructor!");
        }
        public override void Sing(string name)
        {
            Console.WriteLine($"La la la la Derived2 Class Capten {name}");
        }
    }
    public class Derived3 : Derived2
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Derived2 Karim = new Derived2();
            Karim.Sing("Krakirooooooooo");

            Derived1 Marawan = new Derived1(4, "Marawan");
            Marawan.Sing("Maroooooooooooo");
        }
    }
}
