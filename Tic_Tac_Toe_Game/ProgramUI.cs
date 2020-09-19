using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    class ProgramUI
    {

        static string[] arr = { "0","1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static int player = 1;
        static int choice;
        static int flag = 0;

        // Setting scores to zero 
        int scorePlayerX = 0;
        int scorePlayerO = 0;



        public void Run()
        {
            Display();


        }

        public void Display()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Player 1: X  Player 2: O\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }

                int playerTurnCounter = 0;
                playerTurnCounter += 1;
                string nextPlayer;

                if (playerTurnCounter % 2 == 0)
                {
                    nextPlayer = "Player O";
                }
                else
                {
                    nextPlayer = "Player X";
                }
                Console.WriteLine($"{playerTurnCounter}");
                // Display instructions
                Console.WriteLine("TIC-TAC-TOE\n" +
                    "by Victor Casilla & Ricardo Blanco\n\n" +
                    "INSTRUCTIONS:\n" +
                    "The first player to get 3 marks in a row wins.\n" +
                    "When all squares are full the game is over.\n" +
                    "Enter a square's number and press enter.\n" +
                    "10. To play again.\n" +
                    "20. Exit.\n");

                // Display score
                Console.WriteLine("SCORE: \n" +
                    $"Player X: {scorePlayerX} Player O: {scorePlayerO}\n");

                // Display board
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[1], arr[2], arr[3]);
                Console.WriteLine("_____|_____|_____");
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[4], arr[5], arr[6]);
                Console.WriteLine("_____|_____|_____");
                Console.WriteLine("     |     |     ");
                Console.WriteLine("  {0}  |  {1}  |  {2}  ", arr[7], arr[8], arr[9]);
                Console.WriteLine("     |     |     \n");

                // Display turn
                Console.WriteLine($"TURN: {nextPlayer}"); // {nextPlayer}");

                // Get the player's input
                string playerInputAsString = Console.ReadLine();
                int playerInput = int.Parse(playerInputAsString);
                //string playerInput.Count

                // checking that position where user want to run is marked (with X or O) or not

                if (arr[playerInput] != "X" && arr[playerInput] != "O")
                {
                    if (playerTurnCounter % 2 == 0) //if chance is of player 2 then mark O else mark X  
                    {
                        arr[playerInput] = "O";
                        playerTurnCounter++;
                    }
                    else
                    {
                        arr[playerInput] = "X";
                        playerTurnCounter++;
                    }
                }
                else //If there is any possition where user want to run and that is already marked then show message and load board again  
                {
                    Console.WriteLine("Sorry that square is already marked.\n");
                }








                // Evaluate the player input and act accordingly
                switch (playerInputAsString)
                {
                    // Put player's mark
                    case "1":
                        // Square 1
                        arr[1] = "O";
                        break;
                    case "2":
                        // Square 2
                        arr[2] = "X";
                        break;
                    case "3":
                        // Square 3
                        arr[3] = "X";
                        break;
                    case "4":
                        // Square 4
                        arr[4] = "X";
                        break;
                    case "5":
                        // Square 5
                        arr[5] = "X";
                        break;
                    case "6":
                        // Square 6
                        arr[6] = "X";
                        break;
                    case "7":
                        // Square 7
                        arr[7] = "X";
                        break;
                    case "8":
                        // Square 8
                        arr[8] = "X";
                        break;
                    case "9":
                        // Square 9
                        arr[9] = "X";
                        break;
                    case "20":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid option, please.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
