using System;


namespace Lab1
{
    public enum Position { Manager = 1, Senior, Junior, NA };
    public enum Job { FullTime = 1, PartTime }
    public struct Employee
    {
        public string Name;
        public string Address;
        public Job job;
        public Position position;
        public long Salary;

    }
    internal class Program
    {

        //public static Employee InsertData()
        //{
        //    Employee emp;

        //    Console.WriteLine("Enter Employee's Name.. ");
        //    emp.Name = Console.ReadLine();

        //    Console.WriteLine("Enter Employee's Address.. ");
        //    emp.Address = Console.ReadLine();

        //    Console.WriteLine("Enter Employee's Job.. ");
        //    Console.WriteLine("1.FullTime");
        //    Console.WriteLine("2.PartTime");
        //    int j = int.Parse(Console.ReadLine());
        //    if (j >= 1 && j <= 2)
        //    {
        //        emp.job = (Job)j;
        //    }
        //    else
        //    {
        //        emp.job = (Job)1; // emp.job = Job.FullTime
        //    }

        //    Console.WriteLine("Enter Employee's Position.. ");
        //    Console.WriteLine("1.Manager");
        //    Console.WriteLine("2.Senior");
        //    Console.WriteLine("3.Junior");
        //    int P = int.Parse(Console.ReadLine());
        //    if (P >= 1 && P <= 3)
        //    {
        //        emp.position = (Position)P;
        //    }
        //    else
        //    {
        //        emp.position = (Position)4; // emp.position = Position.NA
        //    }


        //    Console.WriteLine("Enter Employee's Salary.. ");
        //    emp.Salary = long.Parse(Console.ReadLine());

        //    return emp;
        //}
        public static Employee InsertData()
        {
            Employee emp;

            Console.WriteLine("Enter Employee's Name.. ");
            emp.Name = Console.ReadLine();

            Console.WriteLine("Enter Employee's Address.. ");
            emp.Address = Console.ReadLine();

            Console.WriteLine("Enter Employee's Job.. ");
            Console.WriteLine("1.FullTime");
            Console.WriteLine("2.PartTime");
            string JobType = Console.ReadLine();
            if (JobType.ToLower() == "fulltime")
            {
                emp.job = Job.FullTime;
            }
            else if (JobType.ToLower() == "parttime")
            {
                emp.job = Job.PartTime;
            }
            else
            {
                emp.job = Job.FullTime;
            }

            Console.WriteLine("Enter Employee's Position.. ");
            Console.WriteLine("1.Manager");
            Console.WriteLine("2.Senior");
            Console.WriteLine("3.Junior");
            string PositionType = Console.ReadLine();
            switch (PositionType.ToLower())
            {
                case "manager":
                    emp.position = Position.Manager;
                    break;
                case "senior":
                    emp.position = Position.Senior;
                    break;
                case "junior":
                    emp.position = Position.Junior;
                    break;
                default:
                    emp.position = Position.NA;
                    break;
            }


            Console.WriteLine("Enter Employee's Salary.. ");
            emp.Salary = long.Parse(Console.ReadLine());

            return emp;
        }
        public static void PrintData(Employee emp)
        {
            Console.WriteLine($"Employee Name: {emp.Name}");
            Console.WriteLine($"Employee Address: {emp.Address}");
            Console.WriteLine($"Employee Job: {emp.job}");
            Console.WriteLine($"Employee Position: {emp.position}");
            Console.WriteLine($"Employee Salary: {emp.Salary}");
        }
        static void Main(string[] args)
        {
            Employee karim = InsertData();
            PrintData(karim);

        }
    }
}
