using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLib;

namespace DragonsLair
{
    public class Controller
    {
        private TournamentRepo tournamentRepository = new TournamentRepo();

        public void ShowScore(string tournamentName)
        {
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            int rounds = tournament.GetNumberOfRounds();            
            Dictionary<string, int> winningTeamsAndVictorys = new Dictionary<string, int>();
            int numVictorys = 0;
            List<Team> winningTeams = new List<Team>();
            Round currentRound = null;
            for (int q = 0; q < rounds; q++)
            {
                Console.Clear();
                currentRound = tournament.GetRound(q);
                winningTeams = currentRound.GetWinningTeams();
                numVictorys = 1;
                if (q >= 1)
                {
                    if (!winningTeamsAndVictorys.ContainsKey(winningTeams.ToString()))
                    {
                        foreach(Team team in winningTeams)
                        {
                            int moreVictorys = 0;
                            winningTeamsAndVictorys.TryGetValue(team.ToString(), out moreVictorys);
                            winningTeamsAndVictorys[team.ToString()] = moreVictorys + 1;
                        }                        
                    } 
                }                
                foreach(Team team in winningTeams)
                {
                    if(q >= 1)
                    {
                        if (winningTeamsAndVictorys.ContainsKey(winningTeams.ToString()))
                        {
                            winningTeamsAndVictorys.Add(team.ToString(), numVictorys);
                        }
                    }
                    else if(q < 1)
                    {
                        winningTeamsAndVictorys.Add(team.ToString(), numVictorys);
                    }
                }
                var standing = from pair in winningTeamsAndVictorys
                               orderby pair.Value descending
                               select pair;
                foreach (KeyValuePair<string, int> pair in standing)
                {                    
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);                    
                }                
            }             
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
        }

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}
