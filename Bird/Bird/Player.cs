using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bib.Bg.Xna2D;
using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace Bird
{
    public class Player : Sprite
    {
        private bool isMoving = false;
        private Tongue tongue;
        private float speed = 0.3f;
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public Tongue _Tongue
        {
            get { return tongue; }
            set { tongue = value; }
        }


        public Player(Game game, String name, String imageName, Vector2 startPosition,
                                Point numberOfImages) : base(game, name, imageName, startPosition)
        {
            this.NumberOfImages = numberOfImages;
        }

        public void Movement(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            isMoving = false;
            if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                if (keyState.IsKeyUp(Keys.Space))
                {
                    isMoving = true;
                    this.Position += Left * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    this.SpriteEffect = SpriteEffects.None;
                    this.timeTillNextFrame = 50;
                }
            }
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                if(keyState.IsKeyUp(Keys.Space))
                {
                    isMoving = true;
                    this.Position += Right * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    this.SpriteEffect = SpriteEffects.FlipHorizontally;
                    this.timeTillNextFrame = 50;
                }
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                isMoving = false;
                this._Tongue.Extend(gameTime, this);
            }
            else
            {
                List<IGameComponent> toDestroy = new List<IGameComponent>();
                foreach (var P in Game.Components)
                {
                    if (P is Tongue t)
                    {
                        toDestroy.Add(t);
                    }
                }
                foreach (var P in toDestroy)
                {
                    Game.Components.Remove(P);
                }
            }
            if (!isMoving)
            {
                this.timeTillNextFrame = 1000000;
            }



        }

        public void IsFloor(BasicSpriteComponent[] floor)
        {
            float characterLeftX = this.Position.X;
            float characterRightX = this.Position.X + this.Bounds.Width;

            float floorLeftX = floor[0].Position.X;
            float floorRightX = floor[floor.Length - 1].Position.X + floor[floor.Length - 1].Bounds.Width;

            if (characterLeftX <= floorLeftX) 
            { 
                this.Position = new Vector2(floorLeftX, this.Position.Y);
            }
            if (characterRightX >= floorRightX)
            {
                this.Position = new Vector2(floorRightX - this.Bounds.Width, this.Position.Y);
            }



        }
    }
}
