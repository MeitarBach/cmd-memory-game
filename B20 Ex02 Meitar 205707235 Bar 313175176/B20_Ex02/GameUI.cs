using System;
using System.Threading;

namespace B20_Ex02
{
    internal class GameUI
    {
        internal void RunGames()
        {
            MessageDisplayer.DisplayMessage(MessageDisplayer.Welcome);
            Player firstPlayer = MainMenu.getHumanPlayer();
            Player secondPlayer = MainMenu.getSecondPlayer();
            bool playAnotherGame;
            do
            {
                resetGame(firstPlayer, secondPlayer);
                Board board = MainMenu.getBoard();
                playAnotherGame = runSingleGame(firstPlayer, secondPlayer, board);
            }
            while(playAnotherGame);
        }

        private bool runSingleGame(Player i_FirstPlayer, Player i_SecondPlayer, Board i_Board)
        {
            GameManager gameManager = new GameManager(i_FirstPlayer, i_SecondPlayer, i_Board);
            bool gameStillActive = true;
            Player currentPlayer = i_FirstPlayer;
            BoardPainter boardPainter = new BoardPainter(i_Board);

            while (gameStillActive)
            {
                GameCell firstCell = null;
                GameCell secondCell = null;

                //// Get a move from the player / computer - if player quits returns false
                gameStillActive = getPlayerMove(currentPlayer, i_Board, boardPainter, ref firstCell, ref secondCell);
                if(!gameStillActive)
                {
                    break;
                }

                if (i_SecondPlayer.Type == ePlayerType.Computer)
                {
                    i_SecondPlayer.ComputerRememberCell(firstCell);
                    i_SecondPlayer.ComputerRememberCell(secondCell);
                }

                boardPainter.ClearAndPaintBoard();

                currentPlayer = gameManager.ExecuteMove(currentPlayer, firstCell, secondCell);
                if(gameManager.IsGameOver())
                {
                    break;
                }
            }

            if(gameStillActive)
            { // Finished game without quitting
                announceWinner(i_FirstPlayer, i_SecondPlayer);
                gameStillActive = stillWantToPlay();
            }

            return gameStillActive;
        }

        private bool getPlayerHalfMove(Player i_Player, Board i_Board, ref GameCell io_SelectedCell)
        {
            MessageDisplayer.DisplayMessage(i_Player.Name + MessageDisplayer.Turn);
            if(i_Player.Type == ePlayerType.Human)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.EnterMove);
            }

            io_SelectedCell = i_Player.PlayerMove(i_Board);
            bool wantsToPlay = io_SelectedCell != null;

            return wantsToPlay;
        }

        private bool getPlayerMove(Player i_Player, Board i_Board, BoardPainter i_BoardPainter,
                                   ref GameCell io_FirstCell, ref GameCell io_SecondCell)
        {
            bool isHuman = i_Player.Type == ePlayerType.Human;

            //// Get First Half of Move - Human + Computer
            i_BoardPainter.ClearAndPaintBoard();
            bool didNotQuit = getPlayerHalfMove(i_Player, i_Board, ref io_FirstCell);
            if (didNotQuit)
            {
                //// Show Board Between the moves
                i_BoardPainter.ClearAndPaintBoard();

                //// Make computer sleep between moves
                if (!isHuman)
                {
                    Thread.Sleep(2000);
                }

                //// Get Second Half of Move
                if (isHuman)
                {
                    didNotQuit = getPlayerHalfMove(i_Player, i_Board, ref io_SecondCell);
                }
                else
                {
                    io_SecondCell = i_Player.ComputerAiMove(i_Board, io_FirstCell);
                }
            }

            return didNotQuit;
        }

        private bool stillWantToPlay()
        {
            bool anotherGame;
            const bool v_NotYetAnswered = true;

            MessageDisplayer.DisplayMessage(MessageDisplayer.PlayAnotherGame);
            while (v_NotYetAnswered)
            {
                // Get player's decision
                string yesOrNoInput = Console.ReadLine().ToLower();
                if(validateYesNo(yesOrNoInput))
                {
                    anotherGame = yesOrNoInput.Equals("yes");
                    break;
                }
            }

            return anotherGame;
        }

        private static bool validateYesNo(string i_Decision)
        {
            i_Decision = i_Decision.ToLower();
            bool validChoice = i_Decision.Equals("yes") || i_Decision.Equals("no");
            if (!validChoice)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.InvalidPlayAnotherGame);
            }

            return validChoice;
        }

        private void announceWinner(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            string winnerPlayer = string.Empty;

            if (i_FirstPlayer.Score < i_SecondPlayer.Score)
            {
                winnerPlayer = i_SecondPlayer.Name;
            }
            else if (i_FirstPlayer.Score > i_SecondPlayer.Score)
            {
                winnerPlayer = i_FirstPlayer.Name;
            }

            if (i_FirstPlayer.Score == i_SecondPlayer.Score)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.Draw);
            }
            else
            {
                string msg = string.Format(
                    @"{0} {1}
Final score:  {2} : {3} Points
              {4} : {5} Points
           {6}", MessageDisplayer.TheWinnerIs, winnerPlayer,
                    i_FirstPlayer.Name, i_FirstPlayer.Score,
                    i_SecondPlayer.Name, i_SecondPlayer.Score,
                    MessageDisplayer.CongratulationsToWinner);

                MessageDisplayer.DisplayMessage(msg);
            }
        }

        private void resetGame(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            i_FirstPlayer.Score = 0;
            i_SecondPlayer.Score = 0;
            if(i_SecondPlayer.Type == ePlayerType.Computer)
            {
                i_SecondPlayer.ResetComputerMemory();
            }
        }
    }
}
