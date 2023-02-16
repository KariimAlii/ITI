using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture11Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() => Print());
            t.Wait(10000);
            Task.WaitAll(t);
            Console.ReadLine();
        }
        public static void Print()
        {
            for (int i = 0; i < 1000; i++) Console.Write('X');
        }
    }
}


#region Single Thread
//for (int i = 0; i < 10000; i++) Console.WriteLine(i);
//Console.ReadLine();
#endregion

#region Single Thread - 2
//Print();
//for (int i = 0; i < 1000; i++) Console.Write('Y');
//public static void Print()
//{
//    for (int i = 0; i < 1000; i++) Console.Write('X');
//} 
#endregion

#region Sub-Thread
//ThreadStart start = new ThreadStart(Print);
//Thread th = new Thread(start);
//th.Start();
//for (int i = 0; i < 1000; i++) Console.Write('Y'); 
#endregion

#region Thread Abortion
//ThreadStart start = new ThreadStart(Print);
//Thread th = new Thread(start);
//th.Start();
//for (int i = 0; i < 1000; i++)
//{
//    if (i == 100) th.Abort();
//    Console.Write('Y');
//} 
#endregion

#region Thread Join
//ThreadStart start = new ThreadStart(Print);
//Thread th = new Thread(start);
//th.IsBackground = true;
//th.Start();
//th.Join();
//for (int i = 0; i < 1000; i++)
//{
//    Console.Write('Y');
//}
//public static void Print()
//{
//    Thread.Sleep(1000);
//    for (int i = 0; i < 1000; i++)
//    {
//        Console.Write('X');
//    }
//}
#endregion

#region 2 Threads with Local Variables
//ThreadStart start = new ThreadStart(Print);
//Thread th = new Thread(start);
//th.Start();
//th.Join();
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();
//Print();
//public static void Print()
//{
//    for (int i = 0; i < 1000; i++)
//    {
//        Console.Write($"{i}-");
//    }
//} 
#endregion

#region Shared Variable
//bool isPrinted = false;
//Program P = new Program();
//ThreadStart start = new ThreadStart(P.SayHello);
//Thread th = new Thread(start);
//th.Start();
//P.SayHello();
//public void SayHello()
//{
//    if (!isPrinted)
//    {
//        Console.WriteLine("Hello!");
//        isPrinted = true;
//    }
//} 
#endregion

#region Parameterized Threat Start
////ParameterizedThreadStart start = new ParameterizedThreadStart(Print);
////Thread th = new Thread(start);
//Thread th = new Thread(Print);
//th.Start(10);
//public static void Print(Object obj)
//{
//    for (int i = 0; i < (int)obj; i++)
//    {
//        Console.Write('X');
//    }
//} 
#endregion

#region Parameterized Threat Start - 2
//Thread th = new Thread(Print);
//th.Start("Karim Ali");
//public static void Print(Object obj)
//{
//    Console.WriteLine(obj);
//} 
#endregion

#region Lambda Expression
//Thread th = new Thread((object obj) => Console.WriteLine(obj));
//th.Start("Karim Ali");

//Thread th = new Thread(() => Console.WriteLine('X'));
//th.Start(); 
#endregion

#region Lambda Expression (Multiple Parameters)
//string name = "Karim Ali";
//int age = 26;
//string address = "23 Cairo Street,Alexandria";

//Thread th = new Thread
//(
//    () =>
//    {
//        Console.WriteLine($"Student Name:{name}");
//        Console.WriteLine($"Student Age:{age}");
//        Console.WriteLine($"Student Address:{address}");

//    }
//);
//th.Start(); 
#endregion

#region Error Handling (Thread)
//try
//{
//    Thread th = new Thread(() => Console.WriteLine("I'm in Sub-Thread :)!"));
//    Thread th = new Thread(() => throw null);
//    th.Start();
//    throw null;
//}
//catch
//{
//    Console.WriteLine("Ooops! Error Occured! :(");
//}
#endregion

#region Task
//Task.Factory.StartNew(() => Print());
//Task.Run(() => Print());
//Console.ReadLine();
//public static void Print()
//{
//    for (int i = 0; i < 1000; i++) Console.Write('X');
//} 
#endregion

#region Waiting Task
//Task t = Task.Run(() => Print());
//t.Wait(10000);
//Task.WaitAll(t);
//Console.ReadLine();
//public static void Print()
//{
//    for (int i = 0; i < 1000; i++) Console.Write('X');
//}
#endregion