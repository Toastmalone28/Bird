using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bird
{
    public class Veggie : Sprite
    {
        private float speed = 0.15f;
        public float SpawnRate { get; set; }

        public Veggie V { get; set; }
        public Veggie(Game game, string name, string imageName, Vector2 startPosition, Point numberOfImages)
            : base(game, name, imageName, startPosition, numberOfImages)
        {
            NumberOfImages = numberOfImages;
        }

        public void Move(GameTime gameTime)
        {
            Position += Down * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public static void Spawn(Game game, GameTime gameTime, ref float spawnRate, ref float timeSinceSpawn)
        {
            timeSinceSpawn += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeSinceSpawn >= spawnRate) {
                Random rnd = new();
                game.Components.Add(new Veggie(game, "bean", "greenbean", new Vector2(rnd.Next(200, 900), -100), new Point(3, 3)));
                timeSinceSpawn = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if(GameManager.instance.GameState == GameStates.Running)
            Move(gameTime);

            base.Update(gameTime);
        }


    }
}
