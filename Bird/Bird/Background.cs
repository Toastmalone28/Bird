using Bib.Bg.Xna2D;
using Microsoft.Xna.Framework;
using System;

namespace Bird
{
    public class Background : BasicSpriteComponent
    {
        public Background(Game game, String name, String imageName) :
                                 base(game, name, imageName)
        {
            this.Destination = game.GraphicsDevice.Viewport.Bounds;
        }
    }
}