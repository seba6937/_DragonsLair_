﻿using System;

namespace DragonsLair
{
    public class Menu
    {
        private Controller control = new Controller();
        
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
                        ShowTournaments();
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
            Console.WriteLine("2. Vis Turneringer");
            Console.WriteLine("3. Registrér afviklet kamp");
            Console.WriteLine("4. Opret tom Turnering");
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

        private void ShowTournaments()
        {

            control.GetTournamentRepository().GetTournaments();
            int choice = int.Parse(GetUserChoice());

              
                    if (choice != 0)
                {
                    string tournament = control.GetTournamentRepository().returnTournament(choice-1);
                    Console.WriteLine("Turneringen valgt er: " + tournament);
                } else 
                {
                    Console.WriteLine("Ugyldigt valg.");
                    Console.ReadLine();
                }     
               

               
            string tournamentName = Console.ReadLine();
            Console.Clear();
          
            control.ScheduleNewRound(tournamentName);
            control.GetTournamentRepository().CreateRound(tournamentName);

            
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
            Console.Write("Angiv navn på turnering: ");
            string tournamentName = Console.ReadLine();
            control.GetTournamentRepository().CreateTournament(tournamentName);
            Console.Clear();
        }

    }
}