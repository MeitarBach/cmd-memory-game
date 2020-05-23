using System;

namespace B20_Ex02
{
    internal class Board
    {
        private readonly int r_Height;
        private readonly int r_Width;
        private GameCell[,] m_BoardCells;
        private int m_RestOfCellsToRevealed;

        internal Board(int i_Height, int i_Width)
        {

            r_Height = i_Height;
            r_Width = i_Width;
            m_BoardCells = new GameCell[r_Height, r_Width];
            m_RestOfCellsToRevealed = r_Height * r_Width;

            createRandomizeBoard();
        }

        internal int Height
        {
            get
            {
                return r_Height;
            }
        }

        internal int Width
        {
            get
            {
                return r_Width;
            }
        }

        internal GameCell[,] BoardCells
        {
            get
            {
                return m_BoardCells;
            }
        }

        internal int RestOfCellsToRevealed
        {
            get
            {
                return m_RestOfCellsToRevealed;
            }
            set
            {
                RestOfCellsToRevealed = value;
            }
        }

        private void createRandomizeBoard()
        {
            int counterOfFilledCells = 0;

            for(int i = 0; i < r_Height; i++)
            {
                for(int j = 0; j < r_Width; j++)
                {
                    char temporaryChar = (char) ('A' + (counterOfFilledCells / 2));
                    m_BoardCells[i, j] = new GameCell(temporaryChar);
                    counterOfFilledCells++;
                }
            }
            
            shuffle();
        }

        private void shuffle()
        {
            int numberOfCells = r_Height * r_Width;
            Random random = new Random();

            for(int i = 0; i < numberOfCells - 1; i++)
            {
                int firstRow = i / r_Width;
                int firstColumn = i % r_Width;

                // Pick a random cell between i and the end of the array.
                int randomizeSecondIndex = random.Next(i + 1);
                int secondRow = randomizeSecondIndex / r_Width;
                int secondColumn = randomizeSecondIndex % r_Width;

                GameCell temp = m_BoardCells[firstRow, firstColumn];
                m_BoardCells[firstRow, firstColumn] = m_BoardCells[secondRow, secondColumn];
                m_BoardCells[secondRow, secondColumn] = temp;
            }
        }
    }
}
