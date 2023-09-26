using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Bird
{
    public class DisplayPoints : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 position = new Vector2(600, 30);

        public DisplayPoints(Game game) : base(game) 
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            font = Game.Content.Load<SpriteFont>("File");
        }

        protected override void LoadContent()
        {
            //
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, GameManager.instance.Points.ToString(), position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
