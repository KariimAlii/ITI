using System;

namespace Lecture6Events
{
    public class Receiver
    {
        public static void Main(string[] args)
        {
            Sender s = new Sender();
            s.Low += new ValueHandler(OnLow);
            s.High += new ValueHandler(OnHigh);
            s.ReadData();
        }
        public static void OnLow(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void OnHigh(string msg)
        {
            Console.WriteLine(msg);
        }
    }

}
