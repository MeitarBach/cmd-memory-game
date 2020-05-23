namespace B20_Ex02
{
    internal class Player
    {
        private readonly string r_PlayerName;
        private ePlayerType m_PlayerType;
        private ushort m_Score;

        internal Player(string i_PlayerName, ePlayerType i_PlayerType)
        {
            m_PlayerName = i_PlayerName;
            m_PlayerType = i_PlayerType;
            m_Score = 0;
        }

        internal ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }
        }

        internal string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }

        internal ushort Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

    }
}
