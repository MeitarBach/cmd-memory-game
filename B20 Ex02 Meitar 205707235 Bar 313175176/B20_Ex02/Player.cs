namespace B20_Ex02
{
    internal class Player
    {
        private readonly string r_PlayerName;
        private ePlayerType m_PlayerType;
        private ushort m_Score;

        internal Player(string i_PlayerName, ePlayerType i_PlayerType)
        {
            r_PlayerName = i_PlayerName;
            m_PlayerType = i_PlayerType;
            m_Score = 0;
        }

        internal ePlayerType PlayerType
        {
            get
            {
                return m_PlayerType;
            }
        }

        internal string PlayerName
        {
            get
            {
                return r_PlayerName;
            }
        }

        internal ushort Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        internal GameCell PlayerMove(Board i_Board)
        {
            GameCell selectedCall = null;
            bool inputIsValid = false;

            MessageDisplayer.DisplayMessage(i_currentPlayer.PlayerName + MessageDisplayer.PlayerMove);

            while (!inputIsValid)
            {
                string inputMoveFromUser = Console.ReadLine();

                inputIsValid = isLeaving(inputMoveFromUser);

                if (validMove(inputMoveFromUser))
                {
                    selectedCall = m_board.BoardCells[inputMoveFromUser[1] - 1, inputMoveFromUser[0] - 'A'];
                    inputIsValid = true;
                }
            }

            if (selectedCall != null)
            {
                selectedCall.IsRevealed = true;
            }

            return selectedCall;
        }

        private bool validMove(string i_MoveInput)
        {
            bool isValidMove = (i_MoveInput.Length == 2);
            isValidMove = isValidMove && (i_MoveInput[0] >= 'A' || i_MoveInput[0] <= ('A' + m_board.Width - 1));
            isValidMove = (i_MoveInput[1] >= 0 || i_MoveInput[1] <= (m_board.Height + 1));

            return isValidMove;
        }

        private bool isLeaving(string i_MoveInput)
        {
            return (i_MoveInput.Length == 1) && (i_MoveInput[0] == 'Q');
        }
    }
}
