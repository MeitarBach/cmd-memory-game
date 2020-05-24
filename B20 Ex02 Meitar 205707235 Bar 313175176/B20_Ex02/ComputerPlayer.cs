using System;
using System.Collections;
using System.Collections.Generic;

namespace B20_Ex02
{
    internal class ComputerPlayer
    {
        private ushort m_Score;
        private readonly eGameLevel r_GameLevel;
        private List<GameCell> m_RevealedCells;
        private Stack<GameCell> m_RevealedCouples;
        private char m_lastGameCellSelected = '\0';

        internal ComputerPlayer(ushort i_Score, eGameLevel i_GameLevel)
        {
            m_Score = i_Score;
            r_GameLevel = i_GameLevel;
            m_RevealedCells = new List<GameCell>();
            m_RevealedCouples = new Stack<GameCell>();
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

        internal eGameLevel GameLevel
        {
            get
            {
                return r_GameLevel;
            }
        }

        internal GameCell PlayerMove(Board i_Board)
        {
            GameCell gameCellSelect;

            if(m_lastGameCellSelected == '\0') // First turn
            {
                if(coupleRevealedinStack()) // If there is a revealed couple
                {
                    gameCellSelect = m_RevealedCouples.Pop();
                }
                else
                {
                    gameCellSelect = randomizeCell(i_Board);
                }

                m_lastGameCellSelected = gameCellSelect.Letter;
            }
            else // second turn
            {
                if((gameCellSelect = findMatch()) == null) // If there is a match
                {
                    gameCellSelect = randomizeCell(i_Board);
                }

                m_lastGameCellSelected = '\0';
            }

            AnalyzeMove(i_Board, gameCellSelect);

            return gameCellSelect;
        }

        {
            GameCell gameCellMatch = null;

            if ((gameCellMatch = gameCellContainsAndMatch(i_GameCell.Letter)) != null)
            {
                m_RevealedCouples.Push(i_GameCell);
                m_RevealedCouples.Push(gameCellMatch);
            }
            else
            {
                addByLevelGame(i_GameCell); // Add by the difficulty of the game level
            }

            i_Board.UnRevealedCells.Remove(i_GameCell);
        }

        private void addByLevelGame(GameCell i_GameCell)
        {
            Random random = new Random();
            int randomizeToAdd = random.Next(10);

            switch (r_GameLevel)
            {
                case eGameLevel.Easy:
                    if(randomizeToAdd <= 4) // 50% (Half) of the times algorithm will add
                    {
                        m_RevealedCells.Add(i_GameCell);
                    }

                    break;
                case eGameLevel.Medium:
                    if (randomizeToAdd <= 7) // 80% the times algorithm will add
                    {
                        m_RevealedCells.Add(i_GameCell);
                    }

                    break;
                case eGameLevel.Hard: // 100% the times algorithm will add
                    m_RevealedCells.Add(i_GameCell);
                    break;
            }

        }

        private GameCell gameCellContainsAndMatch(char i_CharToCheck)
        {
            GameCell gameCellMatch = null;

            foreach (GameCell gameCell in m_RevealedCells)
            {
                if (i_CharToCheck == gameCell.Letter)
                {
                    gameCellMatch = gameCell;
                }
            }

            return gameCellMatch;
        }

        private GameCell findMatch()
        {
            GameCell gameCellMatch = null;

            if(m_lastGameCellSelected == m_RevealedCouples.Peek().Letter)
            {
                gameCellMatch = m_RevealedCouples.Pop();
            }
            else
            {
                gameCellMatch = gameCellContainsAndMatch(m_lastGameCellSelected);
            }

            return gameCellMatch;
        }

        private GameCell randomizeCell(Board i_Board)
        {
            Random random = new Random();
            int gameCellIndex = random.Next(i_Board.UnRevealedCells.Count);
            return i_Board.UnRevealedCells[gameCellIndex];
        }

        private bool coupleRevealedinStack()
        {
            bool existsCouple = false;
            while(m_RevealedCouples.Count != 0)
            {
                if (m_RevealedCouples.Peek().IsRevealed == false)
                {
                    existsCouple = true;
                    break;
                }
                else // Clear 2 GameCell in the stack if there are cells that Revealed 
                {
                    m_RevealedCouples.Pop();
                    m_RevealedCouples.Pop();
                }
            }

            return existsCouple;
        }
    }
}
