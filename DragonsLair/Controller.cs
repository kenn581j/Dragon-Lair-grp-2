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
            Tournament tName = tournamentRepository.GetTournament(tournamentName);
            Team[] allTeams = tName.GetTeams().ToArray();
            int[] allScores = new int[allTeams.Length];

            for (int i = 0; i < tName.GetNumberOfRounds(); i++)
            {
                Round round = tName.GetRound(i);
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
