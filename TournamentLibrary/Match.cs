using System;
using System.IO;
namespace TournamentLib
{
    public class Match
    {
        public Team FirstOpponent { get; set; }
        public Team SecondOpponent { get; set; }
        public Team Winner { get; set; } = null;

        string path = @"D:\datamatiker\_DragonsLair_\TournamentLibrary\MatchDB.txt";
        string roundPath = @"D:\datamatiker\_DragonsLair_\TournamentLibrary\RoundDB.txt";
        string[] newM;
        Match newMatch = new Match();
        public Match CreateMatch(string roundNumber)
        {
            if (roundNumber != null)
            {
                string line = "";
                int counter = 1;
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                }
                file.Close();
                StreamReader roundFile = new StreamReader(roundPath);
                string tourLine = "";
                while ((tourLine = roundFile.ReadLine()) != null)
                {
                    newM = tourLine.Split(',');
                }
                for (int i = 0; i < newM.Length; i++)
                {
                    string tourName = newM[i].Substring(';');
                    if (tourName == roundNumber)
                    {
                        newMatch = new Match();
                        TextWriter tw = new StreamWriter(path, true);
                        tw.WriteLine("{0};{1},", counter, roundNumber);
                        tw.Close();
                        return newMatch;
                    }
                }
            }
            return null;
        }
    }
}
