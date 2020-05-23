using System.Text;

namespace B20_Ex02
{
    internal class GameCell
    {
        private readonly char r_Letter;
        private bool m_IsRevealed;

        internal GameCell(char i_Letter)
        {
            r_Letter = i_Letter;
            m_IsRevealed = false;
        }

        internal char Letter
        {
            get
            {
                return r_Letter;
            }
        }

        internal bool IsRevealed
        {
            get
            {
                return m_IsRevealed;
            }

            set
            {
                m_IsRevealed = value;
            }
        }

        public override string ToString()
        {
            StringBuilder cellSB = new StringBuilder(" ");
            if(m_IsRevealed)
            {
                cellSB.Append(r_Letter);
            }
            else
            {
                cellSB.Append(" ");
            }

            cellSB.Append(" ");

            return cellSB.ToString();
        }
    }
}