﻿using System;

namespace B20_Ex02
{
    internal class MainMenu
    {
        internal static Player getHumanPlayer()
        {
            string playerName;
            const bool v_InvalidName = true;

            //// Get Player #1 name from user
            while (v_InvalidName)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.EnterPlayer);
                playerName = Console.ReadLine();
                if(validatePlayerName(playerName))
                {
                    break;
                }
            }

            return new Player(playerName, ePlayerType.Human);
        }

        internal static Player getSecondPlayer()
        {
            Player secondPlayer = null;
            const bool v_InvalidType = true;
            string playerTypeString;

            //// Get input type from user: 1.Human / 2.Computer
            while (v_InvalidType)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.ChooseOpponentType);
                playerTypeString = Console.ReadLine();
                if (validatePlayerType(playerTypeString))
                {
                    break;
                }
            }

            //// Convert input to ePlayerType
            int playerTypeNum;
            int.TryParse(playerTypeString, out playerTypeNum);
            ePlayerType playerType = (ePlayerType)playerTypeNum;

            // Create and return Player #2
            switch(playerType)
            {
                case ePlayerType.Computer:
                    secondPlayer = new Player("COMPUTER", ePlayerType.Computer);
                    break;
                case ePlayerType.Human:
                    secondPlayer = getHumanPlayer();
                    break;
            }

            return secondPlayer;
        }

        internal static Board getBoard()
        {
            const bool v_InvalidBoard = true;
            int boardWidth;
            int boardHeight;
            
            while(v_InvalidBoard)
            {
                //// Get board's Width and Height from user
                MessageDisplayer.DisplayMessage(MessageDisplayer.EnterBoardWidth);
                if (!int.TryParse(Console.ReadLine(), out boardWidth))
                {
                    MessageDisplayer.DisplayMessage(MessageDisplayer.NotANumber);
                    continue;
                }

                MessageDisplayer.DisplayMessage(MessageDisplayer.EnterBoardHeight);
                if(!int.TryParse(Console.ReadLine(), out boardHeight))
                {
                    MessageDisplayer.DisplayMessage(MessageDisplayer.NotANumber);
                    continue;
                }

                //// Validate Board
                if (validateBoard(boardWidth, boardHeight))
                {
                    break;
                }
            }

            return new Board(boardWidth, boardHeight);
        }

        private static bool validatePlayerName(string i_PlayerName)
        {
            bool validName = true;
            if(i_PlayerName.Length > 20)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.NameTooLarge);
                validName = false;
            }

            if(i_PlayerName.Contains(" "))
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.NameContainsSpaces);
                validName = false;
            }

            return validName;
        }
        
        private static bool validatePlayerType(string i_TypeNum)
        {
            bool validOponnent = i_TypeNum == "1" || i_TypeNum == "2";
            if(!validOponnent)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidOpponent);
            }

            return validOponnent;
        }

        private static bool validateBoard(int i_boardWidth, int i_boardHeight)
        {
            bool validBoardWidth = i_boardWidth >= 4 && i_boardWidth <= 6;
            bool validBoardHeight = i_boardHeight >= 4 && i_boardHeight <= 6;
            bool validBoardSize = (i_boardHeight * i_boardWidth) % 2 == 0;

            if(!validBoardWidth)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidWidth);
            }
            
            if(!validBoardHeight)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidHeight);
            }
            
            if(!validBoardSize)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidSize);
            }

            return validBoardWidth && validBoardHeight && validBoardSize;
        }
    }
}
