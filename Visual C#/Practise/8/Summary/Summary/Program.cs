using System;
using System.Collections.Generic;
namespace Summary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var text = "This is a very very very very very very very very very very very very very long and intensive sentence.Thank you for your patience.Go Home";
            Console.WriteLine(SummarizeText.Summarize(text ,25) ); 
            Console.WriteLine(SummarizeText.Summarize(text ,15) ); 
            Console.WriteLine(SummarizeText.Summarize(text ,10) ); 
            Console.WriteLine(SummarizeText.Summarize(text ,5) ); 
        }
    }
}