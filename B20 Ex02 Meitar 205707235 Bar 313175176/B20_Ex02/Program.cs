using System;

namespace B20_Ex02
{
    public class Program
    {
        public static void Main()
        {
            //MainMenu mainMenu = new MainMenu();
            //mainMenu.CreateGameManager();
            //Console.ReadLine();

            Board board = new Board(4,6);
            BoardPainter bp = new BoardPainter(board);
            bp.PaintBoard();
            Console.ReadLine();
        }
    }
}
