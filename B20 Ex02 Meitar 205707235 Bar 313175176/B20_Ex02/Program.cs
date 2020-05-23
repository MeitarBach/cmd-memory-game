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

            Board board = new Board(6,4);
            BoardPainter bp = new BoardPainter(board);
            bp.PaintBoard();
            Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared...");
            Console.ReadLine();
        }
    }
}
