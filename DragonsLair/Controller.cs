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
            Tournament t = tournamentRepository.GetTournament(tournamentName);
            Team[] allTeams = t.GetTeams().ToArray();
            int[] allScores = new int[allTeams.Length];

            for (int i = 0; i < t.GetNumberOfRounds(); i++)
            {
                Round round = t.GetRound(i);
                List<Team> winningTeams = round.GetWinningTeams();
                for (int teamI = 0; teamI < allTeams.Length; teamI++)
                {
                    for (int winningTeamI = 0; winningTeamI < winningTeams.Count; winningTeamI++)
                    {
                        if (allTeams[teamI].Name == winningTeams[winningTeamI].Name)
                        {
                            allScores[teamI]++;
                        }
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("0------------------------------------------------------0");
            Console.WriteLine("|  #####                                               |");     
            Console.WriteLine("| #     #  ######  #  #       #       #  #    #  ####  |");
            Console.WriteLine("| #          #     #  #       #       #  ##   # #    # |");
            Console.WriteLine("|  #####     #     #  #       #       #  # #  # #      |");
            Console.WriteLine("|       #    #     #  #       #       #  #  # # #  ### |");
            Console.WriteLine("| #     #    #     #  #       #       #  #   ## #    # |");
            Console.WriteLine("|  #####     #     #  ######  ######  #  #    #  ####  |");
            Console.WriteLine("0------------------------------------------------------0");
            for (int num = allScores.Max(); num >= 0; num--)
            {
                for (int i = 0; i < allTeams.Length; i++)
                {
                    if (allScores[i] == num)
                    {
                        Console.WriteLine($"            Team: '{allTeams[i]}' - Score: {allScores[i]} point");
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

        public void SaveMatch(string tournamentName, int roundNumber, string team1, string team2, string winningTeam)
        {
            // Do not implement this method
        }
    }
}
