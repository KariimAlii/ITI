using System;
using nonprimitive.Math;


namespace nonprimitive
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //======== using Person class =======//
            Person karim = new Person(); // or var karim = new Person();
            karim.FirstName = "Karim";
            karim.LastName = "Ali";
            karim.Introduce();
            Console.WriteLine(karim.FirstName);
            //====== using Calculator class =====//
            int result = Calculator.Add(1, 2);
            Console.WriteLine(result);
            //===== using Teacher class ====//
            var roro = new Teacher();
            roro.Age = 24;
            roro.School = "Rolan";
            Console.WriteLine(roro.Age);
            Console.WriteLine(roro.School);
            //===== Declaring an array =====//
            int[] numbers = new int[3] { 1, 2, 3 }; // we can use var numbers = new int[3] { 1, 2, 3 };
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine(numbers[2]);

            var players = new int[3];
            players[0] = 5;
            Console.WriteLine(players[0]);
            Console.WriteLine(players[1]);
            Console.WriteLine(players[2]);

            var flags = new bool[3];
            flags[2] = true;
            Console.WriteLine(flags[0]);
            Console.WriteLine(flags[1]);
            Console.WriteLine(flags[2]);

            var names = new string[3] { "mero", "kiko", "nino" };
            names[1] = "krsha";
            Console.WriteLine(names[0]);
            Console.WriteLine(names[1]);
            Console.WriteLine(names[2]);

            //===== Declaring a string =====//
            string firstName = "krsha"; // or var firstName = "krsha";
            Console.WriteLine(firstName);
            Console.WriteLine(firstName[0]);
            //  strings are classes (System.String)
            String lastName = "3loka"; //  string lastName == String lastName
            Console.WriteLine(lastName);
            // integers are structures System.Int32
            // int number == Int32 number
            Int32 number = 32;
            Console.WriteLine(number);

            // string concatenation
            var fullName = firstName + " " + lastName;
            Console.WriteLine(fullName);
            // string formatting using a format template
            var myFullName = string.Format("My Name is {0} {1}", firstName, lastName);
            Console.WriteLine(myFullName);
            // string joining an array
            var hobbers = new string[3] { "krsha", "roro", "moataz" };
            string hobberList = string.Join("|", hobbers);
            Console.WriteLine(hobberList);
            // hobberList[0] = "Z"; strings can't be edited
            
            // Escape Characters
            var sentence = "We are \n a good mother \n fuck you at path c:folder1\\folder2\\folder3 \t here you are mother fucker";
            // Verbatim String
            var sentence2 = @"We are
a good mother
fuck you at path c:folder1\folder2\folder3  here you are mother fucker";
            Console.WriteLine(sentence);
            Console.WriteLine(sentence2);

            //======= Enum ======//
            var method = ShippingMethod.Express; // internally stored as integer
            
            Console.WriteLine((int)method); // casting into integer 3
            Console.WriteLine( method.ToString() ); // casting into a string "Express"
            Console.WriteLine(method); // Console.WriteLine by default converts everything passed to it to a string => it will automatically convert the enum ShippingMethod.Express to a string "Express"
            Console.WriteLine((int)ShippingMethod.RegularAirMail); // casting into integer 1
            Console.WriteLine((int)ShippingMethod.RegisteredAirMail); // casting into integer 2

            // casting integer into enum
            var mobileDeliveryID = 3;
            Console.WriteLine((ShippingMethod)mobileDeliveryID); // express

            // parsing string into enum
            // Enum.parse[string => object] , (ShippingMethod) [object => enum]
            var tvDeliveryMethod = "Express";
            // Console.WriteLine(typeof(ShippingMethod)); // nonprimitive.ShippingMethod
            // Enum.Parse(typeof(ShippingMethod), tvDeliveryMethod); => enumerated object that needs to be casted to enum
            // casting the enumerated object to enum of type ShippingMethod
            var tvEnum = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), tvDeliveryMethod);
            Console.WriteLine(tvEnum); // Express
            // Enum.parse[string => object] , (ShippingMethod) [object => enum]


            //======= REFERENCE types VS VALUE types ======//
            //===== first : VALUE types ex:integer =====//
            int a = 10; // memory is allocated in the stack automatically
            int b = a; // the value is copied and the 2 variables are not connected to eachother
            b++;
            Console.WriteLine( String.Format("a: {0} , b: {1}", a , b) ); // a = 10 not changed , b = 11 changed alone

            //====== secong : REFERENCE types ex:class => Array ans Strings are classes => System.Array , System.String =====//
            var array1 = new int[3] { 1, 2, 3 }; // we use new because we need to allocate memory manually
            Console.WriteLine(array1[0]); // 1
            var array2 = array1;
            Console.WriteLine(array2[0]); // 1
            array2[0] = 9;
            Console.WriteLine(array2[0]); // 9
            Console.WriteLine(array1[0]); // 9 it changed !!!
            Console.WriteLine( String.Format("array1[0]: {0} , array2[0]: {1}", array1[0], array2[0]) );
            // Arrays are classes => classes are reference type 
            // When we copy reference type objects => their reference or their memory address is copied not the actual value
            // both array1 and array2 point to => the same object => with the same memory address [reference]
        }
    }
}