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
using Microsoft.Xna.Framework.Media;
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
            NumberOfImages = numberOfImages;
        }

        public void Movement(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            isMoving = false;
            if (GameManager.instance.GameState == GameStates.Running)
            {
                if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
                {
                    if (keyState.IsKeyUp(Keys.Space))
                    {
                        isMoving = true;
                        Position += Left * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        SpriteEffect = SpriteEffects.None;
                        timeTillNextFrame = 50;
                        ((Game1)Game).Walk1.Play();
                        ((Game1)Game).Walk2.Play();

                    }
                }
                if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
                {
                    if (keyState.IsKeyUp(Keys.Space))
                    {
                        isMoving = true;
                        Position += Right * Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        SpriteEffect = SpriteEffects.FlipHorizontally;
                        timeTillNextFrame = 50;
                        ((Game1)Game).Walk1.Play();
                        ((Game1)Game).Walk2.Play();

                    }
                }
                if (keyState.IsKeyDown(Keys.Space))
                {
                    MinFrame = 2;
                    isMoving = false;
                    _Tongue.Extend(gameTime, this, _Tongue.TongueLength);
                    _Tongue.TongueLength++;
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
                if (keyState.IsKeyUp(Keys.Space))
                {
                    MinFrame = 0;
                    _Tongue.TongueLength = 0;
                }
                if (!isMoving)
                    timeTillNextFrame = 250;
            }
        }
        public void IsFloor(BasicSpriteComponent[] floor)
        {
            float characterLeftX = Position.X;
            float characterRightX = Position.X + Bounds.Width;

            float floorLeftX = floor[0].Position.X;
            float floorRightX = floor[floor.Length - 1].Position.X + floor[floor.Length - 1].Bounds.Width;

            if (characterLeftX <= floorLeftX)
            {
                Position = new Vector2(floorLeftX, Position.Y);
            }
            if (characterRightX >= floorRightX)
            {
                Position = new Vector2(floorRightX - Bounds.Width, Position.Y);
            }
        }




    }
}
