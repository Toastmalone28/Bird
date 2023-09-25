using Bib.Bg.Xna2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Bird
{
    public class Sprite : BasicSpriteComponent
    {
        private Point numberOfImages;
        private Point currentFrame = new Point (0,0);
        private Rectangle frame;
        protected float timeTillNextFrame = 250;
        private float timeSinceLastFrame = 0;
        private Vector2 speed = new Vector2(40, 0);
        public int MinFrame { get; set; }

        public Point NumberOfImages
        {
            get { return numberOfImages; }
            set
            {
                numberOfImages = value;
                frame.Width = this.TextureSize.X / numberOfImages.X;
                frame.Height = this.TextureSize.Y;
                Clipping = frame;
            }
        }
        public Point CurrentFrame { get;set; }


        public Sprite(Game game, String name, String imageName) :
                                this(game, name, imageName, Vector2.Zero)
        { }

        public Sprite(Game game, String name, String imageName, Vector2 startPosition) :
                                    base(game, name, imageName)
        {
            this.Position = startPosition;
        }

        public Sprite(Game game, String name, String imageName, Vector2 startPosition,
                                Point numberOfImages) : this(game, name, imageName, startPosition)
        {

            this.NumberOfImages = numberOfImages;
        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            base.Update(gameTime);
        }

        private void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastFrame >= timeTillNextFrame)
            {
                currentFrame.X++;
                if (currentFrame.X >= numberOfImages.Y)
                {
                    currentFrame.X = 0;
                }
                if (MinFrame > currentFrame.X)
                {
                    currentFrame.X = MinFrame;
                }

                frame.X = currentFrame.X * frame.Width;
                frame.Y = currentFrame.Y * frame.Height;

                Clipping = frame;
                timeSinceLastFrame = 0;
            }
        }

    }
}
