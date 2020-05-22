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

        internal void PaintBoard()
        {
            StringBuilder firstLine = new StringBuilder(" ");
            char columnLetter = 'A';
            for(int i = 0; i < m_Board.Width; i++)
            {
                firstLine.Append("   " + columnLetter);
                columnLetter++;
            }

            Console.WriteLine(firstLine);
        }
    }
}
