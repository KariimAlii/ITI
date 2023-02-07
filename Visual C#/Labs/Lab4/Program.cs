using System;



namespace Lab4Task1
{
    public class Person
    {
        protected int Id;
        protected string Name;

        public Person()
        {
            this.Id = 0;
            this.Name = "N/A";
        }
        public Person(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public virtual void Print()
        {
            Console.WriteLine($"ID:{Id}");
            Console.WriteLine($"Name:{Name}");
        }
    }
    public class Employee : Person
    {
        int MobileNumber;
        public Employee(int Id, string Name, int MobileNumber) : base(Id, Name)
        {
            this.MobileNumber = MobileNumber;
        }
        public override void Print()
        {
            Console.WriteLine($"ID:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"MobileNumber:{MobileNumber}");

        }
    }
    public class Customer : Person
    {
        int Budget;
        public Customer(int Id, string Name, int Budget) : base(Id, Name)
        {
            this.Budget = Budget;
        }
        public override void Print()
        {
            Console.WriteLine($"ID:{Id}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Budget:{Budget}");

        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("===============Person Class===============");
            Person Karim = new Person(1, "Karim");
            Karim.Print();
            Console.WriteLine("===============Employee Class===============");
            Employee Ahmed = new Employee(2, "Ahmed", 1222345);
            Ahmed.Print();
            Console.WriteLine("===============Customer Class===============");
            Customer Mariem = new Customer(3, "Mariem", 945268);
            Mariem.Print();
        }
    }
}
