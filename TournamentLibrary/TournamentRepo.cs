using System.Collections.Generic;

namespace TournamentLib
{
    public class TournamentRepo
    {
        private Tournament newTournament;
        private List<Tournament> tournaments = new List<Tournament>();
        private string newTour = "";

        public Tournament GetTournament(string name)
        {
           foreach(Tournament tournament in tournaments)
            {
                if(name == tournament.Name)
                {
                    return tournament;
                }
            }
            return null;
        }

        public Tournament CreateTournament(string name)
        {
            if(name != null)
            {
                newTour = name;
                newTournament = new Tournament(newTour);
                return newTournament;
            }
            return null;
        }
        

        
    }
}