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

        /*
        Bruger m som parameter til at søge hvert added match igennem i matches listen. 
        Derefter sætter jeg hver opponentnavn = teamnavn. Hvis dette er true, så returnerer jeg m, hvis ikke, så null.
        */
        public Match GetMatch(string teamName1, string teamName2)
        {
            foreach (Match m in matches)
            {
                if(m.FirstOpponent.Name == teamName1 && m.SecondOpponent.Name == teamName2)
                {
                    return m;
                }
            }
            return null;
        }
        
        public bool IsMatchesFinished()
        {
            /*
           Her laver jeg et foreach loop på samme måde som ovenover.
           Jeg spørger om der er en vinder på det det valgte match.
           Hvis m = null, altså at der ikke findes en winner, så skal den være false - ellers true.
            */
            foreach (Match m in matches)
            {
                if(m.Winner == null)
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
