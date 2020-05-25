using System;

namespace B20_Ex02
{
    internal class MessageDisplayer
    {
        private const string k_Welcome = "Welcome to Meitar&Bar's Memory Game!";
        private const string k_EnterPlayer = "Please Enter Player Name: (no spaces, max 20 Letters)";
        private const string k_ChooseOpponentType = "Choose your oponnent:  1.Human  2.Computer";
        private const string k_NameTooLarge = "Invalid Name: More than 20 chars";
        private const string k_NameContainsSpaces = "Invalid Name: Contains spaces";
        private const string k_InvalidOpponent = "Invalid Oponnent: Choose 1/2";
        private const string k_EnterBoardWidth = "Please enter the board's width: (4-6)";
        private const string k_EnterBoardHeight = "Please enter the board's height: (4-6)";
        private const string k_NotANumber = "Invalid input: Not a Number";
        private const string k_InvalidWidth = "Invalid Width: Not in range 4-6";
        private const string k_InvalidHeight = "Invalid Height: Not in range 4-6";
        private const string k_InvalidSize = "Invalid Size: Width X Height is not even";
        private const string k_Turn = "'s turn:";
        private const string k_EnterMove = "Enter a cell (i.e: B3) or Q to exit";
        private const string k_InvalidMoveSyntaxError = "Invalid move: Enter a cell in the correct syntax (i.e: B3) or Q to exit";
        private const string k_InvalidMoveOutOfRange = "Invalid move: You entered a cell which is not in the board's range";
        private const string k_InvalidMoveCellRevealed = "Invalid move: You entered a cell which is revealed";
        private const string k_TheWinnerIs = "The winner is: ";
        private const string k_CongratulationsToWinner = "$$$ Congratulations to the winner $$$";
        private const string k_Draw = "It's a draw, maybe next time we'll have a winner :-(";
        private const string k_PlayAnotherGame = "Play another game? insert: YES/NO";
        private const string k_InvalidPlayAnotherGame = "Invalid input: insert: YES/NO";
        private const string k_GoodBye = "Thanks for playing, See you later :-)";

        internal static string Welcome
        {
            get
            {
                return k_Welcome;
            }
        }
        
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

        internal static string Turn
        {
            get
            {
                return k_Turn;
            }
        }
        
        internal static string EnterMove
        {
            get
            {
                return k_EnterMove;
            }
        }

        internal static string InvalidMoveOutOfRange
        {
            get
            {
                return k_InvalidMoveOutOfRange;
            }
        }
        
        internal static string InvalidMoveSyntaxError
        {
            get
            {
                return k_InvalidMoveSyntaxError;
            }
        }

        internal static string InvalidMoveCellRevealed
        {
            get
            {
                return k_InvalidMoveCellRevealed;
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

        internal static string Draw
        {
            get
            {
                return k_Draw;
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

        internal static string GoodBye
        {
            get
            {
                return k_GoodBye;
            }
        }

        internal static void DisplayMessage(string i_Msg)
        {
            Console.WriteLine(i_Msg);
        }
    }
}
