using System.IO.Pipes;
using System;

namespace ex9
{
    internal class Program
    {
        private static bool isGame = true;
        private static string playerInput;
        private static bool hasPlayed = false;
        private static string userSelection;
        private static string computerSelection;
        private static int playerScore;
        private static int computerScore;
        static void Main(string[] args)
        {
            Game();
        }
        private static void Game()
        {
            Console.WriteLine($"Hello and welcome to Rock Paper Scissors\nPlease enter your play!");
            while (isGame)
            {
                playerInput = Console.ReadLine();
                playerInput = playerInput.ToLower();
                if (playerInput == null || playerInput.Equals(""))
                {
                    Console.WriteLine("Please enter text!");
                }
                else if (playerInput.Equals("paper")|| playerInput.Equals("scissors")|| playerInput.Equals("rock"))
                {
                    userSelection = playerInput;
                    getComputerPlay();
                    hasPlayed = true;
                }
                else if (playerInput.Contains("exit") || playerInput.Contains("leave") || playerInput.Contains("bye"))
                {
                    Console.WriteLine("Come back later!");
                    System.Threading.Thread.Sleep(3000);
                    isGame = false;
                }
                if (hasPlayed)
                {
                    getWinner();
                    hasPlayed = false;
                }
            }
        }
        private static void getComputerPlay()
        {
            Random rnd = new Random();
            float rand = rnd.Next(0, 101);
            if (rand <= 34) { computerSelection = "paper"; }
            else if(rand <= 67) { computerSelection = "scissors"; }
            else if (rand <= 100) { computerSelection = "rock"; }

        }
        private static void getWinner()
        {
            Console.WriteLine($"Player played {userSelection} & Computer played {computerSelection}!");
            if (computerSelection.Equals("paper"))
            {
                if (userSelection.Equals("paper"))
                {
                    Console.WriteLine("It is a tie!");
                }
                else if (userSelection.Equals("scissors"))
                {
                    Console.WriteLine("Player Wins!");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Computer Wins!");
                    computerScore++;
                }
            }
            else if (computerSelection.Equals("scissors"))
            {
                if (userSelection.Equals("scissors"))
                {
                    Console.WriteLine("It is a tie!");
                }
                else if (userSelection.Equals("rock"))
                {
                    Console.WriteLine("Player Wins!");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Computer Wins!");
                    computerScore++;
                }
            }
            else if (computerSelection.Equals("rock"))
            {
                if (userSelection.Equals("rock"))
                {
                    Console.WriteLine("It is a tie!");
                }
                else if (userSelection.Equals("paper"))
                {
                    Console.WriteLine("Player Wins!");
                    playerScore ++;
                }
                else
                {
                    Console.WriteLine("Computer Wins!");
                    computerScore ++;
                }
            }
            Console.WriteLine($"Player score: {playerScore}\nComputer score: {computerScore}\n");
        }
    }
}