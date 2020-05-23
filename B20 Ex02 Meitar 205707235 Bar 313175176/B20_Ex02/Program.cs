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

            MemoryGame memoryGame = new MemoryGame();
            memoryGame.RunGame();
            Console.ReadLine();
        }
    }
}
