namespace loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //============For Loop=============//
            for (var i = 0; i < 10; i++)
            {
                if (i % 2 == 0) 
                    Console.WriteLine(i);
            }
            Console.WriteLine("=============================================");
            //=============While Loop=============//
            var x = 10;
            while (x >= 0)
            {
                if (x % 2 == 0)
                    Console.WriteLine(x);
                x--;
            }
            Console.WriteLine("=============================================");

            //============Foreach Loop=============//
            // on Array
            var numbers = new int[4] { 1, 2, 3, 4 }; 
            foreach(var y in numbers)
            {
                Console.WriteLine(y);
            }
            Console.WriteLine("=============================================");
            for (var y = 0; y < numbers.Length; y++)
            {
                Console.WriteLine(numbers[y]);
            }
            Console.WriteLine("=============================================");
            // on String ... Note: String is enumerable object which is treated like array as it represents a list of elements .. A string is a sequence of charachters => we can iterate over it
            string name = "krsha krkr";
            foreach(var y in name)
            {
                Console.WriteLine(y);
            }
            Console.WriteLine("=============================================");
            for (var y = 0; y < name.Length;y++)
            {
                Console.WriteLine(name[y]);
            }
            Console.WriteLine("=============================================");
            //=============While Loop=============//
            /*
            while (true)
            {
                Console.Write("Enter Your Name");
                string person = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(person))
                {
                    break;
                }
                Console.WriteLine("Echo: " + person);

            }
            */
            Console.WriteLine("=============================================");
            while (true)
            {
                Console.Write("Enter Your Name..");
                string person = Console.ReadLine();
                if ( !String.IsNullOrWhiteSpace(person) )
                {
                    Console.WriteLine("@Echo: " + person);
                    continue; // goes to the beginning of the loop again
                }
                break; // terminates the loop
            }
        }
    }
}