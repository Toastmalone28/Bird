using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace Bird
{
    internal class Player : Sprite
    {
        private float speed = 0.3f;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Player(Game game, string name, string imageName) : base(game, name, imageName)
        {
        }
        public Player(Game game, String name, String imageName, Vector2 startPosition) :
                            base(game, name, imageName)
        {
            this.Position = startPosition;
        }

        public Player(Game game, String name, String imageName, Vector2 startPosition,
                                Point numberOfImages) : this(game, name, imageName, startPosition)
        {
            this.NumberOfImages = numberOfImages;
        }

        public void Movement(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            bool isMoving = false;

            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                isMoving = true;
                this.Position += Left * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                this.SpriteEffect = SpriteEffects.None;
                this.timeTillNextFrame = 50;
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                isMoving = true;
                this.Position += Right * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                this.SpriteEffect = SpriteEffects.FlipHorizontally;
                this.timeTillNextFrame = 50;
            }
            if(!isMoving)
            {
                this.timeTillNextFrame = 250;

            }

        }
    }
}
