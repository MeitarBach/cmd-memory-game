using System.Text;

namespace B20_Ex02
{
    public class GameCell
    {
        private readonly char r_Letter;
        private bool m_CellIsShow;

        internal GameCell(char i_Letter)
        {
            r_Letter = i_Letter;
            m_CellIsShow = false;
        }

        internal char Letter
        {
            get
            {
                return r_Letter;
            }
        }

        internal bool CellIsShow
        {
            get
            {
                return m_CellIsShow;
            }

            set
            {
                m_CellIsShow = value;
            }
        }

        public override string ToString()
        {
            StringBuilder cellSB = new StringBuilder(" ");
            if(m_CellIsShow)
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