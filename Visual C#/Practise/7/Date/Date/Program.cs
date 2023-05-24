using System;
namespace Date
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //======================= DateTime ========================//
            // Datetime represents a point of time
            var dateTime = new DateTime(2015, 1, 1);
            var now = DateTime.Now;
            var today = DateTime.Today;

            Console.WriteLine("Hour : " + now.Hour);
            Console.WriteLine("Minute : " + now.Minute);
            Console.WriteLine("Second : " + now.Second);

            var tomorrow = now.AddDays(1);
            var yesterday = now.AddDays(-1);
            // Only Date
            Console.WriteLine(now.ToLongDateString());
            Console.WriteLine(now.ToShortDateString());
            // Only Time
            Console.WriteLine(now.ToLongTimeString());
            Console.WriteLine(now.ToShortTimeString());
            // Both Date and Time using different format specifiers
            Console.WriteLine(now.ToString());
            Console.WriteLine(now.ToString("M"));
            Console.WriteLine(now.ToString("yyyy-MM-dd HH:mm "));

            //======================= TimeSpan ========================//
            // Time Span represents a duration
            // I. Creating
            //================
            var timeSpan = new TimeSpan(5, 40, 30);
            Console.WriteLine("Time Span : " + timeSpan.ToString() );

            var timeSpan1 = new TimeSpan(1, 0, 0);
            var timeSpan2 = TimeSpan.FromHours(1);

            // The difference between 2 datetime objects is a time span
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(1).AddMinutes(40);
            var duration = end - start;
            Console.WriteLine("Duration is : " + duration);

            // II. Properties
            //==================

            Console.WriteLine("Minutes : " + timeSpan.Minutes);
            Console.WriteLine("Total Minutes : " + timeSpan.TotalMinutes);

            // III. Add
            //=====================
            Console.WriteLine("Add Example : 5:40:30 + 0:30:0 = " + timeSpan.Add(TimeSpan.FromMinutes(30))); 
            Console.WriteLine("Subtract Example : 5:40:30 - 0:30:0 = " + timeSpan.Subtract(TimeSpan.FromMinutes(30)));


            // IV . Convert from time span to string
            Console.WriteLine("ToString():  " + timeSpan.ToString()); // you can use Console.WriteLine(timeSpan) because it converts the (timespan) to a (string) automatically

            // V . Parsing from string to timespan
            Console.WriteLine("Parse :  " + TimeSpan.Parse("05:40:30"));
            Console.WriteLine("Parse :  " + TimeSpan.Parse("5:40:30"));

            // Datetime and timespan are structures
            // Datetime and timespan are immutable : Once you set them you cannot modify them
            Console.WriteLine("Before Add : " + timeSpan);
            timeSpan.Add(TimeSpan.FromMinutes(30)); // it returns a new instance
            Console.WriteLine("After Add : " + timeSpan); // not changed
        }
    }
}