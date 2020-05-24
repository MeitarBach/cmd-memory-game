using System;
using System.Threading;

namespace B20_Ex02
{
    public class Program
    {
        public static void Main()
        {
            GameUI memoryGame = new GameUI();
            memoryGame.RunGame();
            MessageDisplayer.DisplayMessage(MessageDisplayer.GoodBye);
            Thread.Sleep(3000);
        }
    }
}
