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

        internal bool StartGame()
        {
            bool gameStillActive = true;
            Player currentPlayer = m_FirstPlayer;
            BoardPainter boardPainter = new BoardPainter(m_Board);

            while(gameStillActive && m_Board.RemainingCouples != 0)
            {
                GameCell cellOne, cellTwo;

                // show board
                boardPainter.ClearAndPaintBoard();
                MessageDisplayer.DisplayMessage(currentPlayer.PlayerName + MessageDisplayer.PlayerMove);
                if ((cellOne = currentPlayer.PlayerMove(m_Board)) == null)
                {
                    gameStillActive = false;
                    break;
                }

                // show board after pick one cell
                boardPainter.ClearAndPaintBoard();
                MessageDisplayer.DisplayMessage(currentPlayer.PlayerName + MessageDisplayer.PlayerMove);
                if (currentPlayer.PlayerType == ePlayerType.Computer)
                {
                    System.Threading.Thread.Sleep(2000);
                }

                if ((cellTwo = currentPlayer.PlayerMove(m_Board)) == null)
                {
                    gameStillActive = false;
                    break;
                }

                // show board after pick second cell
                boardPainter.ClearAndPaintBoard();

                if (cellOne.Letter == cellTwo.Letter)
                {
                    currentPlayer.Score++;
                    m_Board.RemainingCouples--;
                    continue;
                }

                coverCell(cellOne, cellTwo);
                System.Threading.Thread.Sleep(2000);
                currentPlayer = togglePlayer(currentPlayer);
            }

            if(gameStillActive)
            {
                AnnounceWinner();
                gameStillActive = stillWantToPlay();
            }

            return gameStillActive;
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

        //private bool cellIsEqual(Player i_currentPlayer ,GameCell i_cellOne, GameCell i_cellTwo)
        //{
        //    bool isEqual = false;

        //    if (i_cellOne.Letter == i_cellTwo.Letter)
        //    {
        //        i_currentPlayer.Score++;
        //        m_Board.RemainingCouples--;
        //        isEqual = true;
        //    }
        //    else
        //    {
        //        coverCell(i_cellOne, i_cellTwo);
        //        System.Threading.Thread.Sleep(2000);
        //    }

        //    return isEqual;
        //}

        private bool stillWantToPlay()
        {
            string yesOrNoInput;
            bool wontAnotherGame, firstTimeMessage = true;
            const bool v_NotYetAnswered = true;

            MessageDisplayer.DisplayMessage(MessageDisplayer.PlayAnotherGame);
            while (v_NotYetAnswered)
            {
                if(!firstTimeMessage)
                {
                    MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidPlayAnotherGame);
                }
                else
                {
                    firstTimeMessage = false;
                }

                yesOrNoInput = Console.ReadLine();
                if(yesOrNoInput.Equals("yes") || yesOrNoInput.Equals("YES"))
                {
                    wontAnotherGame = true;
                    break;
                }

                if (yesOrNoInput.Equals("no") || yesOrNoInput.Equals("NO"))
                {
                    wontAnotherGame = false;
                    break;
                }

            }

            return wontAnotherGame;
        }

        internal void AnnounceWinner()
        {
            string winnerPlayer = "";

            if(m_FirstPlayer.Score < m_SecondPlayer.Score)
            {
                winnerPlayer = m_SecondPlayer.PlayerName;
            }

            if(m_FirstPlayer.Score > m_SecondPlayer.Score)
            {
                winnerPlayer = m_FirstPlayer.PlayerName;
            }

            if(m_FirstPlayer.Score == m_SecondPlayer.Score)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.ThereIsADraw);
            }
            else
            {
                string msg = string.Format(
 @"{0} {1}
             {2}", MessageDisplayer.TheWinnerIs, winnerPlayer, MessageDisplayer.CongratulationsToWinner);
                MessageDisplayer.DisplayMessage(msg);
            }
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
