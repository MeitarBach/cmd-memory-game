using System;

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
                return m_BoardCells;
            }
        }

        private void createRandomizeBoard()
        {
            int counterOfChars = 0;

            for(int i = 0; i < m_Height; i++)
            {
                for(int j = 0; j < m_Width; j++)
                {
                    char temporaryChar = (char) ('A' + (counterOfChars / 2));

                    if(counterOfChars % 2 == 0)
                    {
                        m_BoardCells[i, j] = new GameCell(temporaryChar);
                    }
                    else
                    {
                        m_BoardCells[i, j] = new GameCell(temporaryChar);
                    }

                    counterOfChars++;
                }
            }
            
            shuffle();
        }

        private void shuffle()
        {
            int numberOfCells = m_Height * m_Width;
            Random random = new Random();

            for(int i = 0; i < numberOfCells - 1; i++)
            {
                // Pick a random cell between i and the end of the array.
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
