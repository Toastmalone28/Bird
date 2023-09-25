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
        private Player _player;
        protected BasicSpriteComponent[] Floor { get; set; }
        protected bool isFloor;

        protected BasicSpriteComponent Stage { get; set; }

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
            Stage = new BasicSpriteComponent(this, "stage", _stage);
            Stage.CenterImage();
            Components.Add(Stage);
            
            Texture2D _block = Content.Load<Texture2D>("block");
            Floor = new Block[_stage.Width / _block.Width];

            for (int i = 0; i < Floor.Length; i++)
            {
                Floor[i] = new Block(this, "block", "block", new Vector2 (Stage.Position.X + (_block.Width * i), _stage.Height));
                Components.Add(Floor[i]);
            }

            _player = new Player(this, "player", "bird",
                new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 165), new Point(6, 2));
            Components.Add(_player);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.IsFloor(Floor);
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