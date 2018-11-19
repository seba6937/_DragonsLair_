using System;
using System.Collections.Generic;
using System.IO;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private string newTour = "";
        Tournament TEST = new Tournament("Test");
        private Tournament newTournament;        
        private List<Tournament> tournaments = new List<Tournament>();
        string path = Path.GetFullPath("TournamentDB.txt"); //Gives the path to the TournamentDB file.

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

        public void GetTournaments()
        {
            List<string> temp2 = new List<string>();
            StreamReader sr = new StreamReader(path);
            string line = "";
            string lineToArray = "";
           
            while((line = sr.ReadLine()) != null)
            {
                lineToArray = line;
                temp2.Add(lineToArray);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                string subString = temp2[i].Remove(temp2[i].Length - 1); 

                string tourName = subString.Substring(subString.LastIndexOf(';')+1);
                Console.WriteLine("\n"+ (i+1) + ". " + tourName + "\n");
            }
            
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
            Console.WriteLine("Name can not be empty");
            return null;
          
        }

        string path2 = Path.GetFullPath("RoundDB.txt");
        string tourPath = Path.GetFullPath("TournamentDB.txt");
       List<string> newR = new List<string>();
        Round newRound = new Round();
        public Round CreateRound(string tournamentName)
        {
            if (tournamentName != null)
            {
                string line = "";
                int counter = 1;
                StreamReader file = new StreamReader(path2);
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                }
                file.Close();
                StreamReader tourFile = new StreamReader(tourPath);
                string tourLine = "";
                while ((tourLine = tourFile.ReadLine()) != null)
                {
                    newR.Add(line);
                }
                for (int i = 0; i < newR.Count; i++)
                {
                    string subString = newR[i].Remove(newR[i].Length - 1);

                    string tourName = subString.Substring(subString.LastIndexOf(';') + 1);
                    if (tourName == tournamentName)
                    {
                        newRound = new Round();
                        TextWriter tw = new StreamWriter(path, true);
                        tw.WriteLine("{0};{1},", counter, tournamentName);
                        tw.Close();
                        return newRound;
                    }
                }



            }
            return null;
        }

        public string returnTournament(int index)
        {
            List<string> temp2 = new List<string>();
            StreamReader sr = new StreamReader(path);
            string line = "";
            string lineToArray = "";
            List<string> listOfTeams = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                lineToArray = line;
                temp2.Add(lineToArray);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                string subString = temp2[i].Remove(temp2[i].Length - 1);

                string tourName = subString.Substring(subString.LastIndexOf(';') + 1);
                listOfTeams.Add(tourName);
            }
            return listOfTeams[index];
        }

        public List<string> returnListOfTournaments()
        {
            List<string> temp2 = new List<string>();
            StreamReader sr = new StreamReader(path);
            string line = "";
            string lineToArray = "";
            List<string> listOfTeams = new List<string>();

            while ((line = sr.ReadLine()) != null)
            {
                lineToArray = line;
                temp2.Add(lineToArray);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                string subString = temp2[i].Remove(temp2[i].Length - 1);

                string tourName = subString.Substring(subString.LastIndexOf(';') + 1);
                listOfTeams.Add(tourName);
            }
            return listOfTeams;
        }
    }
}