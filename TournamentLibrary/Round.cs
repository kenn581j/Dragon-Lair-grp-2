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
        Bruger M som lokal variabel til at assigne hvert match i tournament. Dette gør at jeg kan søge igennem matches.
        Derefter sætter jeg hver opponentnavn = teamnavn. Hvis dette er true, så returnerer jeg m, hvis ikke, så null.
        */
        public Match GetMatch(string teamName1, string teamName2)
        {
            foreach (Match M in matches)
            {
                if(M.FirstOpponent.Name == teamName1 && M.SecondOpponent.Name == teamName2)
                {
                    return M;
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
            foreach (Match M in matches)
            {
                if(M.Winner == null)
                {
                    return false;
                }
            }
                return true;
        }

        public List<Team> GetWinningTeams()
        {
            /*
            Først opretter jeg en ny liste som jeg kalder 'winners'.
            Derefter benytter jeg samme foreach statement, som tidligere.
            Her fortæller jeg, at alle matches der har en vinder (m.Winner) skal tilføjes til min liste 'winners'.
            Herefter returnerer jeg listen.
            */
            List<Team> winners = new List<Team>();
            foreach (Match M in matches)
            {
                winners.Add(M.Winner);
            }
            return winners;
        }

        public List<Team> GetLosingTeams()
        {
            /*
            Her opretter jeg en liste kaldt 'losers'
            Laver samme foreach statement som tidligere.
            Så siger jeg: Hvis det valgte match's vinder er = den ene opponent, så skal den anden være andenplads og omvendt.
            Dette gøres således at den tager hver taber uanset hvad og adder til listen 'losers'
            Til sidst returneres listen.
            */
            List<Team> losers = new List<Team>();
            foreach (Match M in matches)
            {
                if(M.Winner == M.FirstOpponent)
                {
                    losers.Add(M.SecondOpponent);
                }
                else
                {
                    losers.Add(M.FirstOpponent);
                }
            }
            return losers;
        }
    }
}
