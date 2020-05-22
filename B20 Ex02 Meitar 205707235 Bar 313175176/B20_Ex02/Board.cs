namespace B20_Ex02
{
    internal class Board
    {
        private int m_Height;
        private int m_Width;

        internal Board(int i_Height, int i_Width)
        {
            m_Height = i_Height;
            m_Width = i_Width;
        }

        internal int Height
        {
            get
            {
                return m_Height;
            }
        }

        internal int Width
        {
            get
            {
                return m_Width;
            }
        }
    }
}
