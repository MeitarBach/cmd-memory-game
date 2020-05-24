using System;
using System.Collections;
using System.Collections.Generic;

namespace B20_Ex02
{
    internal class ComputerPlayer
    {
        private ushort m_Score;
        private readonly eGameLevel r_GameLevel;
        private Dictionary<char, GameCell> m_RevealedCells;
        private Stack<GameCell> m_RevealedCouples;
        private char m_lastGameCellSelected = '0'; // A char which isn't on the board

        internal ComputerPlayer(eGameLevel i_GameLevel)
        {
            m_Score = 0;
            r_GameLevel = i_GameLevel;
            m_RevealedCells = new Dictionary<char, GameCell>();
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

            if(m_lastGameCellSelected == '0') // First half of turn
            {
                if(unRevealedCoupleInStack()) // There is an unrevealed couple
                {
                    gameCellSelect = m_RevealedCouples.Pop(); // Pop first cell of the couple
                }
                else
                {
                    gameCellSelect = chooseRandomCell(i_Board);
                    AnalyzeMove(i_Board, gameCellSelect);
                }

                m_lastGameCellSelected = gameCellSelect.Letter;
            }
            else // Second half turn
            {
                if((gameCellSelect = findMatch()) == null) // If there is a match
                {
                    gameCellSelect = chooseRandomCell(i_Board);
                    AnalyzeMove(i_Board, gameCellSelect);
                }

                m_lastGameCellSelected = '0';
            }

            

            return gameCellSelect;
        }

        internal void AnalyzeMove(Board i_Board, GameCell i_GameCell)
        {
            GameCell gameCellMatch;

            if (m_RevealedCells.TryGetValue(i_GameCell.Letter, out gameCellMatch)) // check if i
            {
                if(m_lastGameCellSelected == gameCellMatch.Letter)
                {
                    m_RevealedCouples.Push(gameCellMatch);
                }
                else
                {
                    m_RevealedCouples.Push(i_GameCell);
                    m_RevealedCouples.Push(gameCellMatch);
                }
                
                i_Board.UnRevealedCells.Remove(i_GameCell);
            }
            else
            {
                addByLevelGame(i_Board, i_GameCell); // Add to the revealed list by the difficulty of the game level
            }
        }

        private void addByLevelGame(Board i_Board, GameCell i_GameCell)
        {
            Random random = new Random();
            int rememberProbability = random.Next(10);
            bool rememberCell = false;

            switch (r_GameLevel)
            {
                case eGameLevel.Easy:
                    rememberCell = rememberProbability <= 4; // 50% (Half) of the times algorithm will add
                    break;
                case eGameLevel.Medium:
                    rememberCell = rememberProbability <= 7; // 80% of the times algorithm will add
                    break;
                case eGameLevel.Hard: // 100% of the times algorithm will add
                    rememberCell = true;
                    break;
            }

            if(rememberCell)
            {
                m_RevealedCells.Add(i_GameCell.Letter, i_GameCell);
                i_Board.UnRevealedCells.Remove(i_GameCell);
            }
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
                m_RevealedCells.TryGetValue(m_lastGameCellSelected, out gameCellMatch);
            }

            return gameCellMatch;
        }

        private GameCell chooseRandomCell(Board i_Board)
        {
            Random random = new Random();
            int gameCellIndex = random.Next(i_Board.UnRevealedCells.Count);
            return i_Board.UnRevealedCells[gameCellIndex];
        }

        private bool unRevealedCoupleInStack()
        {
            bool existsCouple = false;
            while(m_RevealedCouples.Count != 0) // stack isn't empty
            {
                if (!m_RevealedCouples.Peek().IsRevealed)
                {
                    existsCouple = true;
                    break;
                }
                
                //// Remove Revealed couple from stack
                m_RevealedCouples.Pop();
                m_RevealedCouples.Pop();
            }

            return existsCouple;
        }
    }
}
