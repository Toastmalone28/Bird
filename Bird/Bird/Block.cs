using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib.Bg.Xna2D;
using Microsoft.Xna.Framework;

namespace Bird
{
    internal class Block : Sprite
    {
        public Block(Game game, string name, string imageName, Vector2 startPosition) : base(game, name, imageName, startPosition)
        {
            this.Position = startPosition;
            this.NumberOfImages = new Point(1, 1);
        }
    }
}
