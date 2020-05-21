namespace B20_Ex02
{
    internal class Player
    {
        private string m_PlayerName;
        private ePlayerType m_playerType;

        internal Player(string i_PlayerName, ePlayerType i_PlayerType)
        {
            m_PlayerName = i_PlayerName;
            m_playerType = i_PlayerType;
        }
    }
}
