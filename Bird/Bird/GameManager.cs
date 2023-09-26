using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bird
{
    internal class GameManager
    {
        public static GameManager instance;

        #region Private Fields
        private Game game;
        private int points = 0;
        private GameStates gameState = GameStates.Starting;
        #endregion


        public Game Game { get { return game; } }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public GameManager(Game game)
        {
            instance = this;
            this.game = game;
        }

        public void Score()
        {
            Points += 100;
        }
    }
}
