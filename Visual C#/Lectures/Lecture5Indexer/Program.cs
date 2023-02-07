using System;
namespace Lecture4Indexer
{
    internal class Program
    {
        public class Team
        {
            private string[] names;
            public string this[int index]
            {
                get
                {
                    if (index >= 0 && index < names.Length) return names[index];
                    else return "";
                }
                set { if (index >= 0 && index < names.Length) names[index] = value; }
            }
            public Team(int Size)
            {
                names = new string[Size];
                for (int i = 0; i < Size; i++) names[i] = "N/A";
                Console.WriteLine("Hello From Your Instance Constructor !");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Team");
            var TeamNumber = int.Parse(Console.ReadLine());
            Team MyTeam = new Team(TeamNumber);
            MyTeam[0] = "Karim";
            MyTeam[1] = "Rana";
            MyTeam[2] = "Marawan";

            MyTeam[7] = "Zeyad";
            MyTeam[8] = "7amza";
            for (int i = 0; i < TeamNumber + 2; i++) Console.WriteLine(MyTeam[i]);
        }
    }
}

//ERRORS
//foreach (var member in MyTeam) Console.WriteLine(member);

//foreach (var name in names) name = "N/A";