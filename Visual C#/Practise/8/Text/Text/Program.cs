using System.Net.WebSockets;

namespace Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //======================= String =====================//
            // var fullName = "  Karim Ali  +  ";
            var fullName = "  Karim Ali  ";
            //===================================
            Console.WriteLine("Trim: '{0}'",fullName.Trim()); 
            Console.WriteLine("ToUpper: '{0}'",fullName.Trim().ToUpper());

            // How to get firstName and lastName ?
            //=========first method=========//
            //var index = fullName.Trim().IndexOf(' ');
            //var firstName = fullName.Trim().Substring(0,index);
            //var lastName = fullName.Trim().Substring(index + 1);
            //Console.WriteLine("First Name : '{0}'", firstName);
            //Console.WriteLine("Last Name : '{0}'", lastName);
            //=========second method=========//
            var arr = fullName.Trim().Split(' ');
            var firstName = arr[0];
            var lastName = arr[1];
            Console.WriteLine("First Name : '{0}'", firstName);
            Console.WriteLine("Last Name : '{0}'", lastName);

            // REPLACE
            Console.WriteLine("REPLACE:  '{0}'" , fullName.Trim().Replace("Karim", "Krsha"));
            // check if the string is null
            Console.Write("Enter your name..      ");
            var input = Console.ReadLine();
            if (String.IsNullOrEmpty(input)) Console.WriteLine("fadya !!"); // null or ""
            // String.IsNullOrEmpty ( str.Trim() ) === String.IsNullOrWhiteSpace( str )
            if (String.IsNullOrWhiteSpace(input)) Console.WriteLine("kolo masafat !!"); // null or "" or "{whitespace}"

            // Converting String to Number and vice versa
            //======== string => number =======//
            var str = "25";
            var age = Convert.ToByte(str);
            Console.WriteLine(age);
            //======== number => string =======//
            float price = 19432.52f;
            Console.WriteLine(price.ToString("C")); // ToString() method is available for all objects in c#
            Console.WriteLine(price.ToString("C0")); 
            Console.WriteLine(price.ToString("C1")); 
            Console.WriteLine(price.ToString("C2")); 
            Console.WriteLine(price.ToString("C3"));
            // string format modifiers => Standard numeric format strings => https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
            Console.WriteLine("The price is {0:C}",price.ToString());
            Console.WriteLine("The price is {0:C1}",price); // Console.WriteLine automatically does price.ToString()

        }
    }
}