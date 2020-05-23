using System;
using System.Text;

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
            bool playerFirstTurn = true;
            BoardPainter boardPainter = new BoardPainter(m_board);

            while(gameStillActive)
            {
                GameCell cellOne, cellTwo;

                // show board
                clearAndPainterBoard(boardPainter);
                Player currentPlayer = playerFirstTurn ? m_FirstPlayer : m_SecondPlayer;

                if((cellOne = currentPlayer.PlayerMove(m_board)) == null)
                {
                    gameStillActive = false;
                    break;
                }

                // show board after pick one cell
                clearAndPainterBoard(boardPainter);

                if (currentPlayer.PlayerType == ePlayerType.Computer)
                {
                    System.Threading.Thread.Sleep(1000);
                }

                if ((cellTwo = currentPlayer.PlayerMove(m_board)) == null)
                {
                    gameStillActive = false;
                    break;
                }

                // show board after pick second cell
                clearAndPainterBoard(boardPainter);

                if (cellOne.Letter == cellTwo.Letter)
                {
                    currentPlayer.Score++;
                }
                else
                {
                    coverCell(cellOne, cellTwo);
                    System.Threading.Thread.Sleep(2000);
                }

                playerFirstTurn = (!playerFirstTurn);
            }

            if(gameStillActive)
            {
                howWon();
                gameStillActive = stillWontToPlay();
            }

            return gameStillActive;
        }

        private bool stillWontToPlay()
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

        private void howWon()
        {
            string winnerPlayer = "";

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
                string msg = string.Format(
 @"{0} {1}
 {2}", MessageDisplayer.TheWinnerIs, winnerPlayer, MessageDisplayer.CongratulationsToWinner);
                MessageDisplayer.DisplayMessage(msg);
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
