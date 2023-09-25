using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird
{
    public class Veggie : Sprite
    {
        public Veggie V { get; set; }
        public Veggie(Game game, string name, string imageName, Vector2 startPosition, Point numberOfImages)
            : base(game, name, imageName, startPosition, numberOfImages)
        {
            NumberOfImages = numberOfImages;
        }

        public void Move()
        {
            List<Veggie> toMove = new List<Veggie>();
            foreach (var V in Game.Components)
            {
                if (V is Veggie p)
                {
                    toMove.Add(p);
                }
            }
            foreach (var W in toMove)
            {
                W.Position = new Vector2(Position.X, Position.Y + 1);
            }            
        }

        public void Spawn()
        {
            Random rnd = new();
            V = new Veggie(Game, "block", "block", new Vector2(rnd.Next(200, 1000), -100), new Point(3,1));
            Game.Components.Add(V);
        }

    }
}
