using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird
{
    internal class Veggie : Sprite
    {
        public Veggie(Game game, string name, string imageName) 
            : base(game, name, imageName) 
        {
            NumberOfImages = new Point(3,1);
        }
    }
}
