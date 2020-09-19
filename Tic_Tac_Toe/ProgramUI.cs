using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class ProgramUI
    {
        // INITIAL VARIABLES AND SETTINGS

        // Creating and Initializing the array 
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // Creating and Initializing the player turn counter in 1
        static int playerTurnCounter = 1;

        // Creating the player input variable
        static int playerInput;

        // Creating and Initializing the game result variable 
        static char gameResult = 'G';

        // Creating the next player variable
        static char nextPlayer;

        // Creating player X counter variable
        static int playerXCounter = 0;

        // Creating player O counter variable
        static int playerOCounter = 0;

        // Creating tied counter variable
        static int tiedCounter = 0;

        // Creating total counter variable
        static int totalCounter = 0;


        public void Play()
        {   
            bool keepPlaying = true;
            while (keepPlaying == true)            {

                while (gameResult == 'G')
                {
                    Console.Clear();

                    // Calculates next player
                    if (playerTurnCounter % 2 == 0)
                    {
                        nextPlayer = 'O';
                    }
                    else
                    {
                        nextPlayer = 'X';
                    }

                    // Calling the Display method
                    Display();

                    // Taking and Checking player input 
                    string playerInputAsString = Console.ReadLine();

                    if (playerInputAsString == "1" ||
                        playerInputAsString == "2" ||
                        playerInputAsString == "3" ||
                        playerInputAsString == "4" ||
                        playerInputAsString == "5" ||
                        playerInputAsString == "6" ||
                        playerInputAsString == "7" ||
                        playerInputAsString == "8" ||
                        playerInputAsString == "9")
                    {
                        // Converts string to int
                        playerInput = int.Parse(playerInputAsString);

                        // Checks if the square is filled or empty
                        // If the square is empty
                        if (arr[playerInput] != 'X' && arr[playerInput] != 'O')
                        {
                            if (playerTurnCounter % 2 == 0)
                            {
                                arr[playerInput] = nextPlayer;
                                playerTurnCounter++;
                            }
                            else
                            {
                                arr[playerInput] = nextPlayer;
                                playerTurnCounter++;
                            }
                        }
                        // If the square is filled
                        else
                        {
                            Console.WriteLine($"Sorry the square {playerInput} is already marked with {arr[playerInput]}\n" +
                                "Press any key to continue...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid option, please.\n" +
                            "Press any key to continue...");
                        Console.ReadLine();
                    }

                    // Checking game result
                    gameResult = CheckWin();

                }

                Console.Clear();

                Display();

                // Update scores            
                switch (gameResult)
                {
                    case 'O':
                        Console.WriteLine("O has won!");
                        playerOCounter++;
                        break;
                    case 'X':
                        Console.WriteLine("X has won!");
                        playerXCounter++;
                        break;
                    case 'T':
                        Console.WriteLine("No one has won. The match is Tied.");
                        tiedCounter++;
                        break;
                }

                // Increase the total counter
                totalCounter++;

                Console.WriteLine("Press any key to continue...playing, or e for exit :)");                
                string playerAnswer = Console.ReadLine().ToLower();
                if (playerAnswer == "e")
                {
                    keepPlaying = false;
                }
                // Reset to initial values to play another match
                else
                {      
                    
                    arr[1] = '1';
                    arr[2] = '2';
                    arr[3] = '3';
                    arr[4] = '4';
                    arr[5] = '5';
                    arr[6] = '6';
                    arr[7] = '7';
                    arr[8] = '8';
                    arr[9] = '9';

                    playerTurnCounter = 1;

                    gameResult = 'G';
                }
            }
        }

        // Display instructions, player turn, score board and game board
        private static void Display()
        {
            // Instructions
            Console.WriteLine("TIC-TAC-TOE\n" +
                "by Victor Casilla & Ricardo Blanco\n\n" +
                "INSTRUCTIONS:\n" +
                "The first player to get three marks in a row, column, or diagonal wins.\n" +
                "When all squares are full the game is over.\n" +
                "Let's play!\n"
                );

            // Scores
            Console.WriteLine("SCORES:\n" +
                $"X: {playerXCounter}\n" +
                $"O: {playerOCounter}\n" +
                $"Tied: {tiedCounter}\n" +
                $"Total: {totalCounter}\n"
                );

            // Turn
            Console.WriteLine($"NEXT PLAYER: {nextPlayer}\n");

            // Board
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            Console.WriteLine("     |     |     \n");

            Console.WriteLine("Enter a square's number and press enter.\n");

        }

        // Checks if someone has won or tied 
        private static char CheckWin()
        {
            // HORIZONTAL WINNING CONDITION
            // 1st row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return arr[1];
            }
            // 2nd row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return arr[4];
            }
            // 3rd row
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return arr[6];
            }

            // VERTICAL WINNING CONDITION
            // 1st column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return arr[1];
            }
            // 2nd column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return arr[2];
            }
            // 3rd column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return arr[3];
            }

            // DIAGONAL WINNING CONDITION
            // 1st diagonal (from top-left to bottom-right)  
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return arr[1];
            }
            // 2nd diagonal (from bottom-left to top-right)
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return arr[3];
            }

            // TIED CONDITION
            // No player has won and all the squares are filled
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return 'T';
            }

            // DEFAULT CONDITION
            else
            {
                return 'G'; // for Gaming
            }

        }
    }
}

