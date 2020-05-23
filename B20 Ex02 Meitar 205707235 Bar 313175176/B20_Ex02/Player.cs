using System;

namespace B20_Ex02
{
    internal class Player
    {
        private readonly string r_PlayerName;
        private ePlayerType m_PlayerType;
        private ushort m_Score;

        internal Player(string i_PlayerName, ePlayerType i_PlayerType)
        {
            r_PlayerName = i_PlayerName;
            m_PlayerType = i_PlayerType;
            m_Score = 0;
        }

        internal ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }
        }

        internal string PlayerName
        {
            get
            {
                return r_PlayerName;
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

        internal GameCell PlayerMove(Board i_Board)
        {
            GameCell selectedCell = null;

            if(PlayerType == ePlayerType.Human)
            {
                const bool v_IvalidInput = true;

                while (v_IvalidInput)
                {
                    MessageDisplayer.DisplayMessage(PlayerName + MessageDisplayer.PlayerMove);
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

                if (selectedCell != null)
                {
                    selectedCell.IsRevealed = true;
                }
            }
            else // Computer Move
            {

            }
            
            return selectedCell;
        }

        private bool validateMove(string i_MoveInput, Board i_Board)
        {
            bool validMove = i_MoveInput.Length == 2 &&
                             i_MoveInput[0] >= 'A' && i_MoveInput[0] <= 'F' &&
                             i_MoveInput[1] >= '1' && i_MoveInput[1] <= '6';

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
                    validMove = inputCell.IsRevealed;
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
