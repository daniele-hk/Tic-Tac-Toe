using System;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        // 2.Set the playField as an 2D array
        static char[,] playField =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };
        
        // 8.Variable for the draw
        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // Two players, the first starts
            int input = 0;
            bool isInputValid = true;

            do
            {
                // 3.Changes of players
                if (player == 2)
                {
                    player = 1;
                    XOrO('X', input);
                }
                else if(player == 1)
                {
                    player = 2;
                    XOrO('O', input);
                }

                // The board has to run in the loop and after the selection of the player to be updated correctly
                Board();

                // 6.Check winning condition
                char[] boardChars = { 'X', 'O' };

                foreach (char c in boardChars)
                {
                    if (((playField[0, 0] == c) && (playField[0, 1] == c) && (playField[0, 2] == c))
                        || (playField[1, 0] == c) && (playField[1, 1] == c) && (playField[1, 2] == c)
                        || (playField[2, 0] == c) && (playField[2, 1] == c) && (playField[2, 2] == c)
                        || (playField[0, 0] == c) && (playField[1, 0] == c) && (playField[2, 0] == c)
                        || (playField[0, 1] == c) && (playField[1, 1] == c) && (playField[2, 1] == c)
                        || (playField[0, 2] == c) && (playField[2, 1] == c) && (playField[2, 2] == c)
                        || (playField[0, 0] == c) && (playField[1, 1] == c) && (playField[2, 2] == c)
                        || (playField[0, 2] == c) && (playField[1, 1] == c) && (playField[2, 0] == c)
                        )
                    {
                        if(c == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 is the Winner!!!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 is the Winner!!!");
                        }
                        //7.2 Resetting the game
                        Console.WriteLine("Please enter any key to Reset the Game");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                    // 8.3.Statement for draw
                    else if (turns == 10)
                    {
                        Console.WriteLine("It's a Draw!!");
                        Console.WriteLine("Please enter any key to Reset the Game");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }

                // 5.Handle input
                do
                {
                    Console.WriteLine($"\nPlayer {player}: Choose your field!");
                    try
                    {
                    input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a number from 1 to 9!");
                    }

                    // 5.1Check if the field is available
                    if ((input == 1) && (playField[0, 0] == '1'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 2) && (playField[0, 1] == '2'))
                    {
                        isInputValid= true;
                    }
                    else if ((input == 3) && (playField[0, 2] == '3'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 4) && (playField[1, 0] == '4'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 5) && (playField[1, 1] == '5'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 6) && (playField[1, 2] == '6'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 7) && (playField[2, 0] == '7'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 8) && (playField[2, 1] == '8'))
                    {
                        isInputValid = true;
                    }
                    else if ((input == 9) && (playField[2, 2] == '9'))
                    {
                        isInputValid = true;
                    }
                    else if(input < 1 || input > 9)
                    {
                        isInputValid = false;
                        Console.WriteLine("Input incorrect! Please choose a number from 1 to 9!");
                    }
                    else
                    {
                        Console.WriteLine("\nThe field is already taken! Please choose another field.");
                        isInputValid = false;
                    }

                } while (!isInputValid);


            } while (true); // To send always and input and don't crash the game

        }

        // 7.Resetting the field
        public static void ResetField()
        {
            // Using this copy to reset the game
            char[,] playFieldCopy =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };

            playField = playFieldCopy;
            Board();
            // 8.2.Reset the counter for a new game
            turns = 0;
        }

        public static void Board()
        {
            Console.Clear();
            // 1.Create the visual board and enter the input value
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[0,0], playField[0,1], playField[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[1,0], playField[1,1], playField[1,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |    ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", playField[2,0], playField[2,1], playField[2,2]);
            Console.WriteLine("     |     |    ");
            // 8.1.Incremental
            turns++;

        }

        // 4.Change input of players
        public static void XOrO(char playerChar, int input)
        {

            switch (input)
            {
                case 1:
                    playField[0, 0] = playerChar; break;
                case 2:
                    playField[0, 1] = playerChar; break;
                case 3:
                    playField[0, 2] = playerChar; break;
                case 4:
                    playField[1, 0] = playerChar; break;
                case 5:
                    playField[1, 1] = playerChar; break;
                case 6:
                    playField[1, 2] = playerChar; break;
                case 7:
                    playField[2, 0] = playerChar; break;
                case 8:
                    playField[2, 1] = playerChar; break;
                case 9:
                    playField[2, 2] = playerChar; break;
            }
        }
    }
}
