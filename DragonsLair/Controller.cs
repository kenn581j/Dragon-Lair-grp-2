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
            Tournament t;
            t = tournamentRepository.GetTournament(tournamentName);
            t.SetupTestRounds();
            List<Team> winningTeams;
            Team[] teams = t.GetTeams().ToArray();
            int[] scores = new int[teams.Length];

            for (int i = 0; i < t.GetNumberOfRounds(); i++)
            {
                Round currentRound = t.GetRound(i);
                winningTeams = currentRound.GetWinningTeams();

                for (int a = 0; a < teams.Length; a++)
                {
                    for (int winningTeam = 0; winningTeam < winningTeams.Count; winningTeam++)
                    {
                        if (teams[a].Name == winningTeams[winningTeam].Name)
                        {
                            scores[a]++;
                        }
                    }
                }
            }

            for (int i = scores.Max(); i >= 0; i--)
            {
                for (int a = 0; a < teams.Length; a++)
                {
                    if (scores[a] == i)
                    {
                        Console.WriteLine("Team: " + teams[a] + " - Score: " + scores[a]);
                    }
                }
            }
            Console.Write("\nTryk på en vilkårlig tast for, at vende tilbage til menuen. . .");
            Console.ReadKey();
            Console.Clear();
        }

        public TournamentRepo GetTournamentRepository()
        {
            return tournamentRepository;
        }

        public void ScheduleNewRound(string tournamentName, bool printNewMatches = true)
        {
            // Do not implement this method
            Tournament t = GetTournamentRepository().GetTournament(tournamentName);
            if(tournamentName == t.Name)
            {
                if (t.GetNumberOfRounds() == 0)
                {
                    Round round = new Round();
                    t.AddRound(round);
                }
            }
        }

        public void SaveMatch(string tournamentName, int round, string winningTeamName)
        {
            //refaktore nedenstående senere
            Tournament t = tournamentRepository.GetTournament(tournamentName);
            Round r = t.GetRound(round);
            Match m = r.GetMatch(winningTeamName);
            
            if (m != null && m.Winner == null)
            {
                Team w = t.GetTeam(winningTeamName);
                //SetWinner(w) to m:Match
                Console.WriteLine("Winner has been set");
            }
            else
            {
                //Send error
                Console.WriteLine("Winner has NOT been set");
            }
        }
    }
}
