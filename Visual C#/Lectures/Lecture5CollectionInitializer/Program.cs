using Lecture5CollectionInitializer;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Lecture5CollectionInitializer
{
    public class Team
    {
        private string name;
        private List<string> players = new List<string>();
        public string Name { get { return name; } set { name = value; } }
        public List<string> Players { get { return players; } }
        public void PrintTeam()
        {
            Console.WriteLine($"Team Name:{this.Name}");
            Console.WriteLine($"{this.Name} Players:");
            foreach (var player in this.Players) Console.WriteLine(player);
            Console.WriteLine("**************************************");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> PremierLeague = new List<Team>
            {
                new Team { Name = "RealMadridFC", Players = { "Bakka", "Roro" } },
                new Team { Name = "ManchesterUnitedFC", Players = { "Cristiano Ronaldo", "Sanchez" } }
            };
            foreach (var team in PremierLeague) team.PrintTeam();
        }
    }
}


//Team RealMadrid = new Team();
//RealMadrid.Name = "RealMadridFC";
//RealMadrid.Players.Add("Bakka");
//RealMadrid.Players.Add("Roro");
////RealMadrid.PrintTeam();

//Team ManchesterUtd = new Team();
//ManchesterUtd.Name = "ManchesterUnitedFC";
//ManchesterUtd.Players.Add("Cristiano Ronaldo");
//ManchesterUtd.Players.Add("Sanchez");
////ManchesterUtd.PrintTeam();

//List<Team> ChampiounsLeague = new List<Team>();
//ChampiounsLeague.Add(RealMadrid);
//ChampiounsLeague.Add(ManchesterUtd);
////foreach (var team in ChampiounsLeague) team.PrintTeam();
///

//List<Team> PremierLeague = new List<Team> { new Team { Name = "RealMadridFC", Players = { "Bakka", "Roro" } }, new Team { Name = "ManchesterUnitedFC", Players = { "Cristiano Ronaldo", "Sanchez" } } };
//foreach (var team in PremierLeague) team.PrintTeam();
