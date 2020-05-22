using System;

namespace B20_Ex02
{
    internal class MainMenu
    {
        internal void CreateGameManager()
        {
            Player firstPlayer = getFirstPlayer();
            Player secondPlayer = getSecondPlayer();
            eGameLevel gameLevel = getGameLevel();
        }

        private Player getFirstPlayer()
        {
            string playerName;
            const bool v_InvalidName = true;

            while (v_InvalidName)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.EnterPlayer);
                playerName = Console.ReadLine();
                if(validatePlayerName(playerName))
                {
                    break;
                }
            }

            return new Player(playerName, ePlayerType.Human);
        }

        private Player getSecondPlayer()
        {
            Player secondPlayer = null;
            const bool v_InvalidType = true;
            string playerTypeString;

            //// Validate Type 1.Human / 2.Computer
            while (v_InvalidType)
            {
                MessageDisplayer.DisplayMessage(MessageDisplayer.ChooseOpponentType);
                playerTypeString = Console.ReadLine();
                if (validatePlayerType(playerTypeString))
                {
                    break;
                }
            }

            //// Convert input to ePlayerType
            int playerTypeNum;
            int.TryParse(playerTypeString, out playerTypeNum);
            ePlayerType playerType = (ePlayerType)playerTypeNum;
            switch(playerType)
            {
                case ePlayerType.Computer:
                    secondPlayer = new Player("COMPUTER", ePlayerType.Computer);
                    break;
                case ePlayerType.Human:
                    secondPlayer = getFirstPlayer();
                    break;
            }

            return secondPlayer;
        }

        private static bool validatePlayerName(string i_PlayerName)
        {
            return (i_PlayerName.Length <= 20) && !(i_PlayerName.Contains(" "));
        }
        
        private static bool validatePlayerType(string i_TypeNum)
        {
            return i_TypeNum == "1" || i_TypeNum == "2";
        }
    }
}
