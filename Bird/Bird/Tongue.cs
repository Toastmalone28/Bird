using System.ComponentModel.Design.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace Bird
{
    public class Tongue : Player
    {
        public int TongueLength { get; set; }
        private double timeTillNextTongue = 100;
        private double currentTimer = 0;

        public Tongue P { get; set; }
        public Tongue(Game game, string name, string imageName, Vector2 startPosition, Point numberOfImages)
            : base(game, name, imageName, startPosition, numberOfImages)
        {

        }

        public void Extend(GameTime gameTime, Player player)
        {
            currentTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (player.SpriteEffect == SpriteEffects.FlipHorizontally && currentTimer >= timeTillNextTongue)
            {
                SpriteEffect = SpriteEffects.FlipHorizontally;
                Position = new Vector2(player.Position.X + player.Clipping.Width / 2 * (TongueLength + 1), player.Position.Y - (this.Bounds.Height * TongueLength));
                P = new Tongue(Game, "tongue", "tongue", Position, new Point(2, 1));
                P.SpriteEffect = SpriteEffects.FlipHorizontally;
                Game.Components.Add(P);
                TongueLength++;
                currentTimer = 0;
            }
            else if (currentTimer >= timeTillNextTongue)
            {
                SpriteEffect = SpriteEffects.None;
                Position = new Vector2(player.Position.X - Clipping.Width / 2 * (TongueLength + 1), player.Position.Y - (this.Bounds.Height * TongueLength));
                P = new Tongue(Game, "tongue", "tongue", Position, new Point(2, 1));
                Game.Components.Add(P);
                TongueLength++;
                currentTimer = 0;
            }
        }


    }
}