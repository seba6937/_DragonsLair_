using System.Collections.Generic;

namespace TournamentLib
{
    public class Round
    {
        private List<Match> matches = new List<Match>();
        
        public void AddMatch(Match m)
        {
            matches.Add(m);
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
            foreach (Match mac in matches)
            {
                if (mac.Winner != null)
                {
                    winners.Add(mac.Winner);
                }
            }
            return winners;
        }

        public List<Team> GetLosingTeams()
        {
            List<Team> losers = new List<Team>();
            foreach (Match mac in matches)
            {
                if (mac.FirstOpponent == mac.Winner)
                {
                    losers.Add(mac.SecondOpponent);
                }
                else
                {
                    losers.Add(mac.FirstOpponent);
                }
            }
            return losers;
        }
    }
}
