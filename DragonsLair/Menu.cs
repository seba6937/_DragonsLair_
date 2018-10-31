using System;
using System.Collections.Generic;

namespace DragonsLair
{
    public class Menu
    {
        private Controller control = new Controller();
        private List<string> teams = new List<string>();
        public void Show()
        {
            bool running = true;
            do
            {
                ShowMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        ShowScore();
                        break;
                    case "2":
                        ScheduleNewRound();
                        break;
                    case "3":
                        SaveMatch();
                        break;
                    case "4":
                        CreateTournament();
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }

        private void ShowMenu()
        {
            Console.WriteLine("Dragons Lair");
            Console.WriteLine();
            Console.WriteLine("1. Præsenter turneringsstilling");
            Console.WriteLine("2. Planlæg runde i turnering");
            Console.WriteLine("3. Registrér afviklet kamp");
            Console.WriteLine("4. Skab en turnering");
            Console.WriteLine("");
            Console.WriteLine("0. Exit");
        }

        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
        
        private void ShowScore()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ShowScore(tournamentName);
        }

        private void ScheduleNewRound()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Clear();
            control.ScheduleNewRound(tournamentName);
        }

        private void SaveMatch()
        {
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.Write("Angiv runde: ");
            int round = int.Parse(Console.ReadLine());
            Console.Write("Angiv vinderhold: ");
            string winner = Console.ReadLine();
            Console.Clear();
            control.SaveMatch(tournamentName, round, winner);
        }
        private void CreateTournament()
        {
            Console.WriteLine("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            Console.WriteLine("Angiv hold i turnering: ");
            string Input;
            bool done = false;
            while (done == false)
            {
                Input = Console.ReadLine();
                if (Input == "")
                {
                    if (teams.Count < 2)
                    {
                        Console.WriteLine("Not enough teams!");
                        Console.WriteLine("Please add more teams: ");
                    }
                    else
                    {
                        control.CreateTournament(tournamentName, teams);
                        done = true;
                    }
                }
                else
                {
                    teams.Add(Input);
                    Console.WriteLine("Angiv flere: ");
                }
            }
        }
    }
}