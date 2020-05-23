
namespace B20_Ex02
{
    internal class GameManager
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private Board m_board;

        internal GameManager(Player i_FirstPlayer, Player i_SecondPlayer, Board i_board)
        {
            m_FirstPlayer = i_FirstPlayer;
            m_SecondPlayer = i_SecondPlayer;
            m_board = i_board;
        }

        internal void StartGame()
        {
            bool gameStillActive = true;
            bool playerOneTurn = true;

            while(gameStillActive)
            {
                // show board
                if(playerOneTurn)
                {
                    MessageDisplayer.DisplayMessage(m_FirstPlayer.PlayerName + MessageDisplayer.PlayerMove);
                    /*
                    cell = playerMove(); 1
                    clear boar
                    cell = playerMove(); 2
                    if(match)
                    {
                        m_FirstPlayer.Score++;
                        m_board.
                    }
                    else
                    {
                        sleep 2 sec
                    }

                    clear boar
                    */
                }
                else
                {
                    MessageDisplayer.DisplayMessage(m_SecondPlayer.PlayerName + MessageDisplayer.PlayerMove);
                    /*
                    cell = playerMove(); 1
                    clear boar
                    if(m_SecondPlayer.PlayerType.Computer)
                    {
                        
                    }
                    cell = playerMove(); 2
                    if(match)
                    {
                        m_FirstPlayer.Score++;
                        m_board.
                    }
                    else
                    {
]                        sleep 2 sec
                    }

                    clear boar
                    */
                }

            }
        }

        private GameCell playerMove()
        {
            // validMove();
            // move
        }



    }
}
