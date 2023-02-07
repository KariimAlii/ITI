using System;
using System.Collections.Generic;

namespace Lecture5List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> Team = new List<string>();
            Team.Add("Krsha");
            Team.Add("Rorito");
            Team.Remove("Krsha");
            Team.Remove("yaya");
            Team.Add("Maro");
            Team.Add("Motaz");

            for (var i = 0; i < Team.Count; i++)
            {
                string member = Team[i];
                Console.WriteLine(member);
            }
        }
    }
}
//foreach (string member in Team) Console.WriteLine(member);
