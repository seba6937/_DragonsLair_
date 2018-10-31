using System;
using System.Collections.Generic;
using System.Linq;
using TournamentLib;
using static System.Math;

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
            int games = 0;
            List<Team> losers = new List<Team>();
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
                        losers = currentRound.GetLosingTeams();
                    }
                }
                var standing = from pair in winningTeamsAndVictorys
                               orderby pair.Value descending
                               select pair;

                if (q == rounds - 1)
                {
                    foreach (KeyValuePair<string, int> pair in standing)
                    {
                        games += pair.Value;
                    }
                }
                Console.WriteLine("  #####                                      ");
                Console.WriteLine(" #     # ##### # #      #      # #    #  ####");
                Console.WriteLine(" #         #   # #      #      # ##   # #    #");
                Console.WriteLine("  #####    #   # #      #      # # #  # #     ");
                Console.WriteLine("       #   #   # #      #      # #  # # #  ###");
                Console.WriteLine(" #     #   #   # #      #      # #   ## #    #");
                Console.WriteLine("  #####    #   # ###### ###### # #    #  #### ");
                Console.WriteLine("0-----------------------------------------------0");
                Console.WriteLine("| 	Turnering: " + tournamentName + " 	        |");
                Console.WriteLine("| 	Spillede runder: " + rounds + "		        |");
                Console.WriteLine("| 	Spillede kampe: " + games +"		        |");
                Console.WriteLine("|-------------------------------| VUNDNE KAMPE  |");

                int position = 1;
                foreach (KeyValuePair<string, int> pair in standing)
                {
                    Console.WriteLine("| "+ position +". {0}" + "\t\t" + "| {1}" + "\t\t" +"|", pair.Key, pair.Value);
                    position++;
                }

                foreach(Team team in losers)
                {
                    Console.WriteLine("| "+ position +". {0}" + "\t\t" + "| 0" + "\t\t" + "|",team);
                    position++;
                }
                Console.WriteLine("0-----------------------------------------------0\n");
            }             
        }

        public TournamentRepo GetTournamentRepository()
        {
            return tournamentRepository;
        }

        public List<Team> ScrambleTeamsRandomly(List<Team> team)
        {
            List<Team> randomList = new List<Team>(); 
            Random random = new Random();
            int randomIndex = 0;


            foreach(Team teams in team)
            {
                randomList.Add(teams);
            }
            //while(team.Count > 0)
            //{
            //    //randomIndex = random.Next(0, team.Count);
            //    //randomList.Add(team[randomIndex]);
            //    //team.RemoveAt(randomIndex);
            //}
            return randomList;
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            int numberOfRounds = tournament.GetNumberOfRounds();
            Round lastRound;
            bool isRoundFinished = false;
            List<Team> teams = new List<Team>();
            Team oldFreeRider, newFreeRider;
            if (numberOfRounds == 0)
            {
                lastRound = null;
                isRoundFinished = true;
            } else
            {
                lastRound = tournament.GetRound(numberOfRounds-1);
                isRoundFinished = lastRound.IsMatchesFinished();
            }

            if (isRoundFinished)
            {
                if (lastRound == null)
                {
                    teams = tournament.GetTeams();
                }
                else
                {
                    teams = lastRound.GetWinningTeams();
                    if (lastRound.FreeRider != null)
                    {
                        teams.Add(lastRound.FreeRider);
                    }
                }

                if (teams.Count >= 2)
                {
                    List<Team> scrambled = ScrambleTeamsRandomly(teams);
                    Round newRound = new Round();

                    if (scrambled.Count %2 != 0)
                    {
                        if (numberOfRounds > 0)
                        {
                            oldFreeRider = lastRound.GetFreerRider(); 
                            newFreeRider = scrambled[0];
                        } else
                        {
                            oldFreeRider = null;
                            newFreeRider = scrambled[0];
                        }

                        int x = 0;
                        while(newFreeRider == oldFreeRider)
                        {
                            newFreeRider = scrambled[x];
                            x++;
                        }

                        newRound.SetFreeRider(newFreeRider);
                        scrambled.Remove(newFreeRider);

                    }
                    Match match = new Match();
                    for (int i = 0; i < scrambled.Count; i += 2)
                    {
                        
                        match.FirstOpponent = scrambled[i];
                        match.SecondOpponent = scrambled[i + 1];
                        newRound.AddMatch(match);

                    }

                    tournament.AddRound(newRound);
                    
                    Console.WriteLine("{0} - {1}", match.FirstOpponent, match.SecondOpponent);

                } else
                {
                    throw new Exception("Tournament is finished");
                }
            }
            else
            {
                throw new Exception("lastRound is not finished");
            }

            
        }

        public void SaveMatch(string tournamentName, int roundNumber, string winningTeam)
        {
            Tournament tournament = tournamentRepository.GetTournament(tournamentName);
            Round round = tournament.GetRound(roundNumber);
            Match match = round.GetMatch(winningTeam);
            if (match != null && match.Winner == null)
            {
                Team winner = tournament.GetTeam(winningTeam);
                match.Winner = winner;
                Console.WriteLine("Success");
            }
            else
            {
                throw new Exception("Match not found");
            }
        }
    }
}
