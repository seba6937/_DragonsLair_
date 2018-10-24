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
            // TODO: Implement this method
            return null;
        }

        public List<Team> GetLosingTeams()
        {
            // TODO: Implement this method
            return null;
        }
    }
}
