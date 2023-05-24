using System;
namespace nonprimitive
{

    public class Person
    {
        public string FirstName;
        public string LastName;
        public void Introduce()
        {
            Console.WriteLine("Hey there ! My Name is " + FirstName + " " + LastName);
        }
    }
}