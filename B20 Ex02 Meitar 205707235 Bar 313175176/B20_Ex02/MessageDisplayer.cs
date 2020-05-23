using System;
using System.Collections.Generic;

namespace B20_Ex02
{
    internal class MessageDisplayer
    {
        private const string k_EnterPlayer = "Please Enter Player Name: (no spaces, max 20 chars)";
        private const string k_ChooseOpponentType = "Choose your oponnent:\t1.Human\t2.Computer";
        private const string k_NameTooLarge = "Invalid Name: More than 20 chars";
        private const string k_NameContainsSpaces = "Invalid Name: Contains spaces";
        private const string k_InvalidOpponent = "Invalid Oponnent: Choose 1/2";
        private const string k_EnterBoardWidth = "Please enter the board's width: (4-6)";
        private const string k_EnterBoardHeight = "Please enter the board's height: (4-6)";
        private const string k_NotANumber = "Invalid input: Not a Number";
        private const string k_InvalidWidth = "Invalid Width: Not in range 4-6";
        private const string k_InvalidHeight = "Invalid Height: Not in range 4-6";
        private const string k_InvalidSize = "Invalid Size: Width X Height is not even";
        private const string k_PlayerMove = "'s turn: select a cell to reveal:";
        private const string k_InvalidMoveOutOfRange = "Invalid move: You entered a cell out of the board's range";
        private const string k_InvalidMoveCellReveal = "Invalid move: You entered a cell which is revealed";
        private const string k_TheWinnerIs = "The winner is: ";
        private const string k_CongratulationsToWinner = "Congratulations to the winner";
        private const string k_ThereIsADraw = "There is a drow so maybe next time";
        private const string k_PlayAnotherGame = "Play another game? insert: yes/no";
        private const string k_InvalidPlayAnotherGame = "Invalid input if you wont to play another game? insert: yes/no";


        internal static string EnterPlayer
        {
            get
            {
                return k_EnterPlayer;
            }
        }
        
        internal static string ChooseOpponentType
        {
            get
            {
                return k_ChooseOpponentType;
            }
        }
        
        internal static string NameTooLarge
        {
            get
            {
                return k_NameTooLarge;
            }
        }
        
        internal static string NameContainsSpaces
        {
            get
            {
                return k_NameContainsSpaces;
            }
        }
        
        internal static string InvalidOpponent
        {
            get
            {
                return k_InvalidOpponent;
            }
        }

        internal static string EnterBoardWidth
        {
            get
            {
                return k_EnterBoardWidth;
            }
        }

        internal static string EnterBoardHeight
        {
            get
            {
                return k_EnterBoardHeight;
            }
        }

        internal static string NotANumber
        {
            get
            {
                return k_NotANumber;
            }
        }

        internal static string InvalidWidth
        {
            get
            {
                return k_InvalidWidth;
            }
        }

        internal static string InvalidHeight
        {
            get
            {
                return k_InvalidHeight;
            }
        }
        
        internal static string InvalidSize
        {
            get
            {
                return k_InvalidSize;
            }
        }

        internal static string PlayerMove
        {
            get
            {
                return k_PlayerMove;
            }
        }

        internal static string InvalidMoveOutOfRange
        {
            get
            {
                return k_InvalidMoveOutOfRange;
            }
        }

        internal static string InvalidMoveCellReveal
        {
            get
            {
                return k_InvalidMoveCellReveal;
            }
        }

        internal static string TheWinnerIs
        {
            get
            {
                return k_TheWinnerIs;
            }
        }

        internal static string CongratulationsToWinner
        {
            get
            {
                return k_CongratulationsToWinner;
            }
        }

        internal static string ThereIsADraw
        {
            get
            {
                return k_ThereIsADraw;
            }
        }

        internal static string PlayAnotherGame
        {
            get
            {
                return k_PlayAnotherGame;
            }
        }

        internal static string InvalidPlayAnotherGame
        {
            get
            {
                return k_InvalidPlayAnotherGame;
            }
        }

        internal static void DisplayMessage(string i_Msg)
        {
            Console.WriteLine(i_Msg);
        }
    }
}
