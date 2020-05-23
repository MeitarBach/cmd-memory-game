
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
                }
                else
                {
                    coverCell(cellOne, cellTwo);
                    System.Threading.Thread.Sleep(2000);
                }
            }

            gameStillActive = howWon();

            return gameStillActive;
        }

        private bool stillWontToplay()
        {

        }

        private howWon()
        {
            string winnerPlayer;

            if(m_FirstPlayer.Score < m_SecondPlayer.Score)
            {
                winnerPlayer = m_SecondPlayer.PlayerName;
            }

            if(m_FirstPlayer.Score > m_SecondPlayer.Score)
            {
                winnerPlayer = m_SecondPlayer.PlayerName;
            }

            if(m_FirstPlayer.Score == m_SecondPlayer.Score)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.ThereIsADraw);
            }
            else
            {

                MessageDisplayer.DisplayMessage()
            }
        }

        private void coverCell(GameCell i_CellOne, GameCell i_CellTwo)
        {
            i_CellOne.IsRevealed = false;
            i_CellTwo.IsRevealed = false;
        }

        private void clearAndPainterBoard(BoardPainter i_BoardPainter)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            i_BoardPainter.PaintBoard();
        }

    }
}
