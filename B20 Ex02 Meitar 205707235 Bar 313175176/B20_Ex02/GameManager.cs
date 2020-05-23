
using System;
using Microsoft.Win32;

namespace B20_Ex02
{
    internal class GameManager
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Board m_board;

        internal GameManager(Player i_FirstPlayer, Player i_SecondPlayer, Board i_board)
        {
            m_FirstPlayer = i_FirstPlayer;
            m_SecondPlayer = i_SecondPlayer;
            m_board = i_board;
        }

        internal bool StartGame()
        {
            bool gameStillActive = true;
            bool playerOneTurn = true;
            BoardPainter boardPainter = new BoardPainter(m_board);

            while(gameStillActive)
            {
                GameCell cellOne, cellTwo;

                // show board
                clearAndPainterBoard(boardPainter);
                Player currentPlayer = playerOneTurn ? m_FirstPlayer : m_SecondPlayer;

                if((cellOne = playerMove(currentPlayer)) == null)
                {
                    gameStillActive = false;
                    break;
                }

                // show board after pick one cell
                clearAndPainterBoard(boardPainter);

                if ((cellTwo = playerMove(currentPlayer)) == null)
                {
                    gameStillActive = false;
                    break;
                }

                // show board after pick second cell
                clearAndPainterBoard(boardPainter);

                if (cellOne.Letter == cellTwo.Letter)
                {
                    m_FirstPlayer.Score++;
]                }
                else
                {
                    coverCell(cellOne, cellTwo);
                    System.Threading.Thread.Sleep(2000);
                }
            }

            howWon();

            return gameStillActive;
        }

        private void coverCell(GameCell i_CellOne, GameCell i_CellTwo)
        {
            i_CellOne.CellIsShow = false;
            i_CellTwo.CellIsShow = false;
        }

        private void clearAndPainterBoard(BoardPainter i_BoardPainter)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            i_BoardPainter.PaintBoard();
        }

        private GameCell playerMove(Player i_currentPlayer)
        {
            GameCell selectedCall = null;
            bool inputIsValid = false;

            MessageDisplayer.DisplayMessage(i_currentPlayer.PlayerName + MessageDisplayer.PlayerMove);

            while (!inputIsValid)
            {
                string inputMoveFromUser = Console.ReadLine();

                inputIsValid = isLeaving(inputMoveFromUser);

                if(validMove(inputMoveFromUser))
                {
                    selectedCall = m_board.BoardCells[inputMoveFromUser[1] - 1, inputMoveFromUser[0] - 'A'];
                    inputIsValid = true;
                }
            }

            if(selectedCall != null)
            {
                selectedCall.CellIsShow = true;
            }

            return selectedCall;
        }

        private bool validMove(string i_MoveInput)
        {
            bool isValidMove = (i_MoveInput.Length == 2);
            isValidMove &= (i_MoveInput[0] >= 'A' || i_MoveInput[0] <= ('A' + m_board.Width - 1));
            isValidMove &= (i_MoveInput[1] >= 0 || i_MoveInput[1] <= (m_board.Height + 1));

            return isValidMove;
        }

        private bool isLeaving(string i_MoveInput)
        {
            return (i_MoveInput.Length == 1) && (i_MoveInput[0] == 'Q');
        }
    }
}
