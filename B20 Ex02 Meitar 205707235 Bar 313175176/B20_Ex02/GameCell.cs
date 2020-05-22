namespace B20_Ex02
{
    public class GameCell
    {
        private readonly char r_Letter;
        private bool m_CellIsShow;

        internal Player(char i_Letter)
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
    }
}