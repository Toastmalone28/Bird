using System.ComponentModel.Design.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace Bird
{
    public class Tongue : Player
    {
        public Tongue P {  get; set; }
        public Tongue(Game game, string name, string imageName, Vector2 startPosition, Point numberOfImages) 
            : base(game, name, imageName, startPosition, numberOfImages)
        {

        }

        public void Extend(GameTime gameTime, Player player)
        {
            this.Position = new Vector2(player.Position.X - Clipping.Width / 3, player.Position.Y);            

            if (player.SpriteEffect == SpriteEffects.FlipHorizontally)
            {
                this.SpriteEffect = SpriteEffects.FlipHorizontally;
                this.Position = new Vector2(player.Position.X + player.Clipping.Width / 2, player.Position.Y);
                P = new Tongue(Game, "tongue", "tongue", this.Position, new Point(2, 1));
                P.SpriteEffect = SpriteEffects.FlipHorizontally;
                Game.Components.Add(P);
            }
            else
            {
                this.SpriteEffect = SpriteEffects.None;
                P = new Tongue(Game, "tongue", "tongue", this.Position - this.SizeAsVector2, new Point(2, 1));
                Game.Components.Add(P);
            }
        }


    }
}