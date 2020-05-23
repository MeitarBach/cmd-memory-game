using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B20_Ex02
{
    internal class MemoryGame
    {
        internal void RunGame()
        {
            Player firstPlayer = MainMenu.getHumanPlayer();
            Player secondPlayer = MainMenu.getSecondPlayer();
            bool keepGameAlive;
            do
            {
                Board board = MainMenu.getBoard();
                GameManager gameManager = new GameManager(firstPlayer, secondPlayer, board);
                keepGameAlive = gameManager.StartGame();

                new BoardPainter(board).PaintBoard();
                Console.WriteLine("Playing...");
                Thread.Sleep(100000);
            }
            while(keepGameAlive);
        }
    }
}
