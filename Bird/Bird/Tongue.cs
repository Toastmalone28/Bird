using System.ComponentModel.Design.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace Bird
{
    public class Tongue : Player
    {
        public int TongueLength { get; set; }

        public Tongue P { get; set; }
        public Tongue(Game game, string name, string imageName, Vector2 startPosition, Point numberOfImages)
            : base(game, name, imageName, startPosition, numberOfImages)
        {

        }

        public void Extend(GameTime gameTime, Player player, int tongueLength)
        {

            if (player.SpriteEffect == SpriteEffects.FlipHorizontally)
            {
                SpriteEffect = SpriteEffects.FlipHorizontally;
                Position = new Vector2(player.Position.X + player.Clipping.Width / 2 * (tongueLength + 1), player.Position.Y - (this.Bounds.Height * tongueLength));
                P = new Tongue(Game, "tongue", "tongue", Position, new Point(2, 1));
                P.SpriteEffect = SpriteEffects.FlipHorizontally;
                Game.Components.Add(P);
            }
            else
            {
                SpriteEffect = SpriteEffects.None;
                Position = new Vector2(player.Position.X - Clipping.Width / 2 * (tongueLength + 1), player.Position.Y - (this.Bounds.Height * tongueLength));
                P = new Tongue(Game, "tongue", "tongue", Position, new Point(2, 1));
                Game.Components.Add(P);
            }
        }


    }
}