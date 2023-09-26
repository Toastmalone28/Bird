using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib.Bg.Xna2D;
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
        private bool dead = false;
        #endregion


        public Game Game { get { return game; } }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public GameStates GameState { get; set; }

        public GameManager(Game game)
        {
            instance = this;
            this.game = game;
        }
        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }


        public void Score(int p)
        {
            Points += p;
        }

        public bool CollidesWithPlayer(Player p)
        {
            foreach (var item in Game.Components)
            {
                if (item is Veggie v && v.Bounds.Intersects(p.Bounds))
                {                    
                    return true;
                }
            }
            return false;
        }
        public bool CollidesWithTongue(Game game, Player p)
        {
            foreach (var item in Game.Components)
            {
                if (item is Veggie v && v.Bounds.Intersects(p._Tongue.Bounds))
                {
                    game.Components.Remove(v);
                    return true;
                }
            }
            return false;
        }
        public bool CollidesWithBlock(Game game, BasicSpriteComponent[] b)
        {
            foreach (var item in Game.Components)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    if (item is Veggie v && v.Bounds.Intersects(b[i].Bounds))
                    {
                        game.Components.Remove(v);
                        return true;
                    }
                }

            }
            return false;
        }


    }
}
