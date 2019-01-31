using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Game : IGame
    {
        private int winner = 0;
        private Dictionary<int, string> boardPosition = new Dictionary<int, string>();

        #region Constructors
        public Game() {
            Start();
        }
        #endregion

        #region Properties
        public int Player { get; private set; } = 1;

        public string Winner 
        {
            get
            {
                switch(winner) 
                {
                    case 1:
                        return "Player X Won";
                    case 2:
                        return "Player O Won";
                    case -1:
                        return "Cat’s Game!";
                    default:
                        return String.Empty;
                }
            }
        }

        public string this[int position] => boardPosition[position];
        #endregion

        #region Private Methods
        private void Start()
        {
            boardPosition = new Dictionary<int, string>();
            for (int i = 0; i < 9; i++) boardPosition.Add(i + 1, (i + 1).ToString());

            winner = 0;
        }

        private int Validate()
        {
            for (int x = 1; x < 4; x++)
            {
                //Checking Horizontal Win
                if(boardPosition[x] == boardPosition[x*2] && boardPosition[x * 2] == boardPosition[x*3])
                {
                    if (boardPosition[x] == "X") winner = 1;
                    else winner = 2;
                    return winner;
                }

                //Checking Vertical Win
                if (boardPosition[x] == boardPosition[x + 3] && boardPosition[x + 3] == boardPosition[x + 6])
                {
                    if (boardPosition[x] == "X") winner = 1;
                    else winner = 2;
                    return winner;
                }
            }

            bool catsGame = true;
            for (int i = 0; i < 9; i++)
            {
                if (boardPosition[i + 1] == (i + 1).ToString()) catsGame = false;
            }

            if (catsGame) winner = -1;
            else winner = 0;

            return winner;
        }
        #endregion

        #region Public Methods
        public Boolean Play(Int32 Position)
        {
            if (Position > 0 && Position < 10)
            {
                string playerValue = "X";
                if (Player == 2) playerValue = "O";

                if (boardPosition[Position] == String.Format("{0}", Position.ToString()))
                {
                    boardPosition[Position] = playerValue;

                    if (Player == 1) Player = 2;
                    else Player = 1;

                    Validate();

                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
