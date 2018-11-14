using System;
using System.Collections.Generic;
using System.IO;

namespace TournamentLib
{
    public class Round
    {

        public Team FreeRider { get; set; }


        public Team GetFreerRider()
        {
            return FreeRider;
        }

        public Team SetFreeRider(Team freeRider)
        {
           return FreeRider = freeRider;
        }

        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
        }

        public Match GetMatch(string team)
        {
            foreach (Match mac in matches)
            {
                if (mac.FirstOpponent.ToString().Equals(team) || mac.SecondOpponent.ToString().Equals(team))
                {
                    return mac;
                }
            }
            return null;
        }

        public Match GetMatch(string teamName1, string teamName2)
        {
            foreach(Match mac in matches)
            {
                if(mac.FirstOpponent.ToString() == teamName1 && mac.SecondOpponent.ToString() == teamName2)
                {
                    return mac;

                }
            }            
            return null;
        }

        

        public bool IsMatchesFinished()
        {
            foreach(Match mac in matches)
            {
                if(mac.Winner == null)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Team> GetWinningTeams()
        {
            List<Team> winners = new List<Team>();
            foreach(Match mac in matches)
            {
                if(mac.Winner != null)
                {
                    winners.Add(mac.Winner);
                }
            }
            return winners;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> loosers = new List<Team>();
            foreach (Match mac in matches)
            {
                if (mac.Winner == mac.FirstOpponent)
                {
                    loosers.Add(mac.SecondOpponent);
                }
                else if(mac.Winner == mac.SecondOpponent)
                {
                    loosers.Add(mac.FirstOpponent);
                }
            }
            return loosers;
        }
        string path = @"D:\datamatiker\_DragonsLair_\TournamentLibrary\RoundDB.txt";
        string tourPath = @"D:\datamatiker\_DragonsLair_\TournamentLibrary\TournamentDB.txt";
        string[] newR;
        Round newRound = new Round();
        public Round CreateRound(string tournamentName)
        {
            if (tournamentName != null)
            {
                string line = "";
                int counter = 1;
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                }
                file.Close();
                StreamReader tourFile = new StreamReader(tourPath);
                string tourLine = "";
                while ((tourLine = tourFile.ReadLine()) != null)
                {
                    newR = tourLine.Split(',');
                }
                for (int i = 0; i < newR.Length; i++)
                {
                    string tourName = newR[i].Substring(';');
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
    }
}
