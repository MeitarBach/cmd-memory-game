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
        internal void RunGame()
        {
            Player firstPlayer = MainMenu.getHumanPlayer();
            Player secondPlayer = MainMenu.getSecondPlayer();
            bool playAnotherGame;
            do
            {
                Board board = MainMenu.getBoard();
                playAnotherGame = startGame(firstPlayer, secondPlayer, board);
            }
            while(playAnotherGame);
        }


        private bool startGame(Player i_FirstPlayer, Player i_SecondPlayer, Board i_Board)
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
                gameStillActive = getPlayerHalfMove(currentPlayer, i_Board, ref secondCell);
                boardPainter.ClearAndPaintBoard();

                currentPlayer = gameManager.ExecuteMove(currentPlayer, firstCell, secondCell);
                if(gameManager.IsGameOver())
                {
                    break;
                }
            }

            if(gameStillActive)
            {
                gameManager.AnnounceWinner();
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

                yesOrNoInput = Console.ReadLine();
                if (yesOrNoInput.Equals("yes") || yesOrNoInput.Equals("YES"))
                {
                    anotherGame = true;
                    break;
                }

                if (yesOrNoInput.Equals("no") || yesOrNoInput.Equals("NO"))
                {
                    anotherGame = false;
                    break;
                }

            }

            return anotherGame;
        }
    }
}
