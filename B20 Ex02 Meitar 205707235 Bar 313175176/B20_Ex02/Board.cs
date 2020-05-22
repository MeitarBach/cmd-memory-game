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

            createRandomizeBoard();
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

        internal GameCell[,] BoardCells
        {
            get
            {
                return m_BoardCells(i_Height, i_Width);
            }
        }


        private void createRandomizeBoard()
        {
            bool counterOfChars = 0;
            char temporaryChar;
            List<char> listOfChar = new List<Char>();

            for(int i = 0; i < m_Height; i++)
            {
                for(int j = 0; j < m_Width; j++)
                {
                    if(counterOfChars % 2 == 0)
                    {
                        temporaryChar = (char) ('A' + counter);
                        m_BoardCells[i, j].letter = temporaryChar;
                        counter++;
                    }
                    else
                    {
                        m_BoardCells[i, j].letter = temporaryChar;
                    }
                }
            }

            shuffle();
        }

        private void shuffle()
        {
            numberOfCells = m_Height * m_Width;
            Random random = new Random();

            for(int i = 0; i < numberOfCells - 1; i++)
            {
                // Pick a random cell between i and the end of the array.
                int j = rand.Next(i, num_cells);
                int i0 = i / m_Width;
                int i1 = i % m_Width;

                int j = random.Next(i + 1);
                int j0 = j / m_Width;
                int j1 = j % m_Width;

                GameCell temp = m_BoardCells[i0, i1];
                m_BoardCells[i0, i1] = m_BoardCells[j0, j1];
                m_BoardCells[j0, j1] = temp;
            }
        }
    }
}
