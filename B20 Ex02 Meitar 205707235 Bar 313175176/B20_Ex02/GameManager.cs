using System;
using System.Text;

namespace B20_Ex02
{
    internal class GameManager
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Board m_Board;

        internal GameManager(Player i_FirstPlayer, Player i_SecondPlayer, Board i_board)
        {
            m_FirstPlayer = i_FirstPlayer;
            m_SecondPlayer = i_SecondPlayer;
            m_Board = i_board;
        }

        internal Player ExecuteMove(Player i_CurrentPlayer, GameCell i_FirstCell, GameCell i_SecondCell)
        {
            Player nextPlayer = i_CurrentPlayer;

            if (i_FirstCell.Letter == i_SecondCell.Letter)
            {
                i_CurrentPlayer.Score++;
                m_Board.RemainingCouples--;
            }
            else
            {
                coverCell(i_FirstCell, i_SecondCell);
                nextPlayer = togglePlayer(i_CurrentPlayer);
            }

            System.Threading.Thread.Sleep(2000);

            return nextPlayer;
        }

        internal bool IsGameOver()
        {
            return m_Board.RemainingCouples == 0;
        }

        private Player togglePlayer(Player i_Player)
        {
            Player newPlayer = m_FirstPlayer;
            if(i_Player == m_FirstPlayer)
            {
                newPlayer = m_SecondPlayer;
            }

            return newPlayer;
        }

        private void coverCell(GameCell i_CellOne, GameCell i_CellTwo)
        {
            m_Board.UnRevealedCells.Add(i_CellOne);
            m_Board.UnRevealedCells.Add(i_CellTwo);
            i_CellOne.IsRevealed = false;
            i_CellTwo.IsRevealed = false;
        }

    }
}
