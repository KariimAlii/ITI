using System;

namespace Lecture6Events
{
    public delegate void ValueHandler(string msg);
    public class Sender
    {
        public event ValueHandler Low;
        public event ValueHandler High;
        public void ReadData()
        {
            Console.WriteLine("Enter Your Score..");
            int I = int.Parse(Console.ReadLine());

            if (I < 5)
            {
                if (Low != null) Low("Your Score is very Low :(");
            }
            else
            {
                if (High != null) High("Your Score is very High! :)");
            }
        }
    }
}
