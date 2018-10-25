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

            List<Team> teams = tournament.GetTeams();
            Round currentRound = null;
            for (int q = 0; q < rounds; q++)
            {
                currentRound = tournament.GetRound(q);
                
            }
            List<Team> winningTeams = currentRound.GetWinningTeams(); //viser kun et hold 
            String[,] winningTeamsAndVictorys = new String[teams.Count,teams.Count];
            
            for (int i = 0; i < rounds; i++)
            {
                
                foreach (Team team in winningTeams)
                {
                    int numTeamVictory = 0;
                    Round matches = new Round();
                    List<Match> match = new List<Match>();
                    match.Add(matches.GetMatch(team.ToString(), teams[i].ToString()));
                    for(int j = 0; j < match.Count; j++)
                    {
                        if(winningTeams[j].ToString() == team.ToString())
                        {
                            numTeamVictory += 1;
                        }
                        winningTeamsAndVictorys.SetValue(""+ team.ToString() + "-"+ numTeamVictory.ToString() + "", j,j);
                    }                                        
                }
            }
            for(int l = 0; l < winningTeamsAndVictorys.Length; l++)
            {
                Console.WriteLine(winningTeamsAndVictorys[l,l]);
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
