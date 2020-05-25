using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace B20_Ex02
{
    internal class Player
    {
        private readonly string r_Name;
        private ePlayerType m_Type;
        private ushort m_Score;
        private static Dictionary<char, GameCell> s_ComputerMemory = null;


        internal Player(string i_PlayerName, ePlayerType i_PlayerType)
        {
            r_Name = i_PlayerName;
            m_Type = i_PlayerType;
            m_Score = 0;

            if(i_PlayerType == ePlayerType.Computer)
            {
                s_ComputerMemory = new Dictionary<char, GameCell>();
            }
        }

        internal ePlayerType Type
        {
            get
            {
                return m_Type;
            }
        }

        internal string Name
        {
            get
            {
                return r_Name;
            }
        }

        internal ushort Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        internal GameCell PlayerMove(Board i_Board) // Returns null if player quits
        {
            GameCell selectedCell = null;

            if (Type == ePlayerType.Human)
            {
                const bool v_IvalidInput = true;
                while (v_IvalidInput)
                {
                    string inputMoveFromUser = Console.ReadLine();

                    if (isLeaving(inputMoveFromUser))
                    {
                        break;
                    }

                    if (validateMove(inputMoveFromUser, i_Board))
                    {
                        selectedCell = i_Board.BoardCells[inputMoveFromUser[1] - '1', inputMoveFromUser[0] - 'A'];
                        break;
                    }
                }
            }
            else // Computer Move
            {
                selectedCell = ComputerRandomMove(i_Board);
            }

            if (selectedCell != null) // User Didn't Quit
            {
                selectedCell.IsRevealed = true;
                i_Board.UnRevealedCells.Remove(selectedCell);
            }

            return selectedCell;
        }

        internal GameCell ComputerRandomMove(Board i_Board)
        {
            Random random = new Random();
            int gameCellIndex = random.Next(i_Board.UnRevealedCells.Count);
            return i_Board.UnRevealedCells[gameCellIndex];
        }

        internal GameCell ComputerAiMove(Board i_Board, GameCell i_FirstRevealedCell)
        {
            GameCell selectedCell;

            if(s_ComputerMemory.TryGetValue(i_FirstRevealedCell.Letter, out selectedCell)) // Letter found in memory
            {
                //// Make sure it's not the same cell
                selectedCell = selectedCell != i_FirstRevealedCell ? selectedCell : ComputerRandomMove(i_Board);
            }
            else
            {
                Thread.Sleep(500); // wait a second before playing
                selectedCell = ComputerRandomMove(i_Board);
            }

            selectedCell.IsRevealed = true;
            i_Board.UnRevealedCells.Remove(selectedCell);

            return selectedCell;
        }

        internal static void ComputerRememberCell(GameCell i_GameCell) // computer remembers up to 1/2 of the board
        {
            if(!s_ComputerMemory.ContainsKey(i_GameCell.Letter))
            {
                s_ComputerMemory.Add(i_GameCell.Letter, i_GameCell);
            }
        }

        internal static void ResetComputerMemory()
        {
            s_ComputerMemory = new Dictionary<char, GameCell>();
        }

        private bool validateMove(string i_MoveInput, Board i_Board)
        {
            bool validMove = i_MoveInput.Length == 2 && char.IsUpper(i_MoveInput[0]) && char.IsDigit(i_MoveInput[1]);

            if(validMove) // valid syntax
            {
                int lineNum = i_MoveInput[1] - '1'; 
                int colNum = i_MoveInput[0] - 'A';
                validMove = lineNum >= 0 && lineNum < i_Board.Height && colNum >= 0 && colNum < i_Board.Width;
                if(!validMove) // Out of range
                {
                    MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidMoveOutOfRange);
                }
                else
                {
                    GameCell inputCell = i_Board.BoardCells[lineNum, colNum];
                    validMove = !inputCell.IsRevealed; // this should be false for a valid move!
                    if(!validMove) // Cell is Revealed
                    {
                        MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidMoveCellRevealed);
                    }
                }
            }
            else // invalid syntax
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidMoveSyntaxError);
            }

            return validMove;
        }

        private bool isLeaving(string i_MoveInput)
        {
            return (i_MoveInput.Length == 1) && (i_MoveInput[0] == 'Q');
        }
    }
}
