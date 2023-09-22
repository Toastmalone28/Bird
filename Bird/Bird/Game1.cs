using System.Windows.Forms.VisualStyles;
using Bib.Bg.Xna2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Bird
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Background _screen;
        private BasicSpriteComponent stage;
        private BasicSpriteComponent block;
        private Player _player;
        private int _playerSpeed = 10;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _screen = new Background(this, "screen", "screen");
            Components.Add(_screen);

            Texture2D _stage = Content.Load<Texture2D>("stage");
            stage = new BasicSpriteComponent(this, "stage", _stage);
            stage.CenterImage();
            Components.Add(stage);
            
            Texture2D _block = Content.Load<Texture2D>("block");
            
            for (int i = 0; i < _stage.Width / _block.Width; i++)
            {
                block = new BasicSpriteComponent(this, "block", _block);
                block.Position = new Vector2(stage.Position.X + (_block.Width * i), _stage.Height);
                Components.Add(block);
            }

            _player = new Player(this, "player", "bird",
                new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 165), new Point(6, 6));
            Components.Add(_player);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Movement(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}