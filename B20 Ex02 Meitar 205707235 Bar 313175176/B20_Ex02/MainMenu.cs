using System;

namespace B20_Ex02
{
    internal enum eGameLevel
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }

    internal enum ePlayerType
    {
        Human = 1,
        Computer = 2
    }

    internal class MainMenu
    {
        internal static GameManager CreateGameManager()
        {
            Player firstPlayer = getFirstPlayer();
            Player secondPlayer = getSecondPlayer();
            eGameLevel gameLevel = getGameLevel();
        }

        internal Player getFirstPlayer()
        {
            string playerName;
            const bool v_InvalidName = true;

            while (v_InvalidName)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.EnterPlayerOne);
                playerName = Console.ReadLine();
                if(validateName(playerName))
                {
                    break;
                }
            }


            return new Player(playerName, ePlayerType.Human);
        }
    }
}
