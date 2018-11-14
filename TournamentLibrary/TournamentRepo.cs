using System.Collections.Generic;
using System.IO;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private string newTour = "";
        private Tournament newTournament;
        private List<Tournament> tournaments = new List<Tournament>();
        string path = @"D:\datamatiker\_DragonsLair_\TournamentLibrary\TournamentDB.txt";

        public Tournament GetTournament(string name)
        {
            foreach (Tournament tournament in tournaments)
            {
                if (name == tournament.Name)
                {
                    return tournament;
                }                
            }
            return null;
        }

        public Tournament CreateTournament(string name)
        {
            if (name != null)
            {
                string line = "";
                int counter = 1;
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine())!= null)
                {
                    counter++;
                }
                file.Close();
                newTour = name;
                newTournament = new Tournament(newTour);
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine("{0};{1},", counter,newTournament.Name);
                tw.Close();
                
                return newTournament;
            }
            return null;
        }
    }
}