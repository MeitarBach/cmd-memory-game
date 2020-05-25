using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B20_Ex02
{
    internal class GameUI
    {
        internal void RunGames()
        {
            Player firstPlayer = MainMenu.getHumanPlayer();
            Player secondPlayer = MainMenu.getSecondPlayer();
            bool playAnotherGame;
            do
            {
                resetGame(firstPlayer, secondPlayer);
                Board board = MainMenu.getBoard();
                playAnotherGame = startSingleGame(firstPlayer, secondPlayer, board);
            }
            while(playAnotherGame);
        }


        private bool startSingleGame(Player i_FirstPlayer, Player i_SecondPlayer, Board i_Board)
        {
            GameManager gameManager = new GameManager(i_FirstPlayer, i_SecondPlayer, i_Board);

            bool gameStillActive = true;
            Player currentPlayer = i_FirstPlayer;
            BoardPainter boardPainter = new BoardPainter(i_Board);

            while (gameStillActive)
            {
                GameCell firstCell = null;
                GameCell secondCell = null;

                //// Get First Half of Move
                boardPainter.ClearAndPaintBoard();
                gameStillActive = getPlayerHalfMove(currentPlayer, i_Board, ref firstCell);
                if(!gameStillActive)
                {
                    break;
                }

                //// Show Board Between the moves
                boardPainter.ClearAndPaintBoard();


                //// Make computer sleep between moves
                if (currentPlayer.PlayerType == ePlayerType.Computer)
                {
                    Thread.Sleep(2000);
                }

                //// Get Second Half of Move
                if(currentPlayer.PlayerType == ePlayerType.Human)
                {
                    gameStillActive = getPlayerHalfMove(currentPlayer, i_Board, ref secondCell);
                }
                else
                {
                    secondCell = currentPlayer.ComputerAiMove(i_Board, firstCell);
                }

                //// Remember uncovered cells with 50% probability
                if (i_SecondPlayer.PlayerType == ePlayerType.Computer)
                {
                    Player.ComputerRememberCell(firstCell);
                    Player.ComputerRememberCell(secondCell);
                }

                boardPainter.ClearAndPaintBoard();

                currentPlayer = gameManager.ExecuteMove(currentPlayer, firstCell, secondCell);
                if(gameManager.IsGameOver())
                {
                    break;
                }
            }

            if(gameStillActive)
            {
                announceWinner(i_FirstPlayer, i_SecondPlayer);
                gameStillActive = stillWantToPlay();
            }

            return gameStillActive;
        }

        private bool getPlayerHalfMove(Player i_Player, Board i_Board, ref GameCell io_SelectedCell)
        {
            MessageDisplayer.DisplayMessage(i_Player.PlayerName + MessageDisplayer.PlayerMove);
            io_SelectedCell = i_Player.PlayerMove(i_Board);
            bool wantsToPlay = io_SelectedCell != null;

            return wantsToPlay;
        }

        private bool stillWantToPlay()
        {
            string yesOrNoInput;
            bool anotherGame, firstTimeMessage = true;
            const bool v_NotYetAnswered = true;

            MessageDisplayer.DisplayMessage(MessageDisplayer.PlayAnotherGame);
            while (v_NotYetAnswered)
            {
                if (!firstTimeMessage)
                {
                    MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidPlayAnotherGame);
                }
                else
                {
                    firstTimeMessage = false;
                }

                // Get player's decision
                yesOrNoInput = Console.ReadLine().ToLower();
                if (yesOrNoInput.Equals("yes"))
                {
                    anotherGame = true;
                    break;
                }

                if (yesOrNoInput.Equals("no"))
                {
                    anotherGame = false;
                    break;
                }
            }

            return anotherGame;
        }

        private void announceWinner(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            string winnerPlayer = "";

            if (i_FirstPlayer.Score < i_SecondPlayer.Score)
            {
                winnerPlayer = i_SecondPlayer.PlayerName;
            }

            if (i_FirstPlayer.Score > i_SecondPlayer.Score)
            {
                winnerPlayer = i_FirstPlayer.PlayerName;
            }

            if (i_FirstPlayer.Score == i_SecondPlayer.Score)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.ThereIsADraw);
            }
            else
            {
                string msg = string.Format(
                    @"{0} {1}
Final score:  {2} : {3} Points
              {4} : {5} Points
             {6}", MessageDisplayer.TheWinnerIs, winnerPlayer,
                    i_FirstPlayer.PlayerName, i_FirstPlayer.Score,
                    i_SecondPlayer.PlayerName, i_SecondPlayer.Score,
                    MessageDisplayer.CongratulationsToWinner);
                MessageDisplayer.DisplayMessage(msg);
            }
        }

        private void resetGame(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            i_FirstPlayer.Score = 0;
            i_SecondPlayer.Score = 0;
            if(i_SecondPlayer.PlayerType == ePlayerType.Computer)
            {
                Player.ResetComputerMemory();
            }
        }
    }
}
