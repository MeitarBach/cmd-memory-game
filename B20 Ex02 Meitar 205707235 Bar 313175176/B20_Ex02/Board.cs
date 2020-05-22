namespace B20_Ex02
{
    internal class Board
    {
        private int m_Height;
        private int m_Width;
        private GameCell[,] m_BoardCells;

        internal Board(int i_Height, int i_Width)
        {
            m_Height = i_Height;
            m_Width = i_Width;
            m_BoardCells = new GameCell[m_Height, m_Width];

            //createRandomizeBoard
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

        internal GameCell this[int i_Height, int i_Width]
        {
            get
            {
                return m_BoardCells(i_Height, i_Width);
            }

            set
            {
                m_BoardCells(i_Height, i_Width) = value;
            }
        }


        private void createRandomizeBoard()
        {
            bool isEven = false;
            List<char> listOfChar = new List<Char>();

            for(int i = 0; i < m_Height; i++)
            {
                for(int j = 0; j < m_Width; j++)
                {
                    if(!isEven)
                    {
                        m_BoardCells[i, j].letter = (char)charRandom.Next('a', 'Z');
                    }
                    else
                    {
                        
                    }

                }
            }
            // Random charRandom = new Random(); 
            // m_BoardCells[i, j].letter = (char)charRandom.Next('A', 'Z');


            

        }
    }
}
