using System;
using System.Text;

namespace B20_Ex02
{
    class BoardPainter
    {
        private Board m_Board;

        internal BoardPainter(Board i_Board)
        {
            m_Board = i_Board;
        }

        internal void ClearAndPaintBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder boardPainting = new StringBuilder();

            //// Create a row seperator
            int seperatorLineLength = (3 * m_Board.Width) + (m_Board.Width + 3); // Length of seperating line
            string rowSeperator = "  ".PadRight(seperatorLineLength, '=');

            //// Draw first line and append to painting
            StringBuilder firstLine = new StringBuilder(" ");
            char columnLetter = 'A';
            for(int i = 0; i < m_Board.Width; i++)
            {
                firstLine.Append("   " + columnLetter);
                columnLetter++;
            }
            boardPainting.Append(firstLine + Environment.NewLine);

            //// Draw all lines based on the board's Game Cells
            for(int i = 0; i < m_Board.Height; i++)
            {
                boardPainting.Append(rowSeperator + Environment.NewLine); // row seperator
                boardPainting.Append((i+1) + " "); // row number
                for(int j = 0; j < m_Board.Width; j++)
                {
                    boardPainting.Append("|" + m_Board.BoardCells[i,j]);
                }

                boardPainting.Append("|" + Environment.NewLine);
            }

            boardPainting.Append(rowSeperator); // closing row seperator

            Console.WriteLine(boardPainting);
        }
    }
}
