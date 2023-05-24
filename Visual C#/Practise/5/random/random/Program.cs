namespace random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            var random = new Random();
            for (var i=0; i < 10;i++)
                // Console.WriteLine( 'a' + random.Next(1, 26) ); it gives you an integer because => (char + integer = integer) => NOTE: char is internally represented as a number
                Console.WriteLine((char) ('a' + random.Next(1, 26)));
            Console.WriteLine("==============================");
            Console.WriteLine((int)'a'); // ASCII https://www.ascii-code.com/
            Console.WriteLine((char)97);
            // a => z   ===   97 => 122 (26 characters starting with 'a')
            */
            //========== Generating a random password with length 10 characters ==========//
            var random = new Random();
            const int passwordLength = 10;
            var array = new char[passwordLength];
            // assigning values to the array
            for (var i = 0; i < passwordLength; i++)
            {
                array[i] = (char)('a' + random.Next(1, 26));
            }
            // array => string
            var password = new string(array);
            Console.WriteLine(password);

        }
    }
}