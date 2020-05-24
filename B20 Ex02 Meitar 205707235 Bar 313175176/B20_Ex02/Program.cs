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

            GameUI memoryGame = new GameUI();
            memoryGame.RunGame();
            Console.ReadLine();
        }
    }
}
