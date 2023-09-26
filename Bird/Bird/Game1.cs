using System;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms.VisualStyles;
using Bib.Bg.Xna2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct3D9;

namespace Bird
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Background _screen;
        private Player _player;
        private GameManager _gameManager;
        private DisplayPoints _displayPoints;
        public BasicSpriteComponent[] Floor { get; set; }
        public BasicSpriteComponent Stage { get; set; }
        public Veggie V { get; private set; }
        private float spawnRate = 900;
        private float timeSinceSpawn = 0;

        public SoundEffect Walk1;
        public SoundEffect Walk2;
        private SoundEffect die;

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
            _gameManager = new GameManager(this);

            Song backgroundMusic = Content.Load<Song>("theme");
            Walk1 = Content.Load<SoundEffect>("walk");
            Walk2 = Content.Load<SoundEffect>("walk2");
            die = Content.Load<SoundEffect>("die");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(backgroundMusic);

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
                Floor[i] = new Block(this, "block", "block", new Vector2(Stage.Position.X + (_block.Width * i), _stage.Height));
                Components.Add(Floor[i]);
            }

            _player = new Player(this, "player", "bird",
                new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 165), new Point(6, 2));
            Components.Add(_player);

            _player._Tongue = new Tongue(this, "tongue", "tongue", _player.Position, new Point(2, 1));
            Components.Add(_player._Tongue);
            _player._Tongue.Visible = false;

            _displayPoints = new DisplayPoints(this);
            Components.Add(_displayPoints);

            _gameManager.GameState = GameStates.Running;

            base.LoadContent();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.IsFloor(Floor);
            _player.Movement(gameTime);
            Veggie.Spawn(this, gameTime, ref spawnRate, ref timeSinceSpawn);
            if (_gameManager.CollidesWithPlayer(_player))
                _gameManager.GameState = GameStates.Over;
            if (_gameManager.CollidesWithTongue(this, _player))            
                _gameManager.Score(100);
            if (_gameManager.CollidesWithBlock(this, Floor))
                _gameManager.GameState = GameStates.Over;
            if (_gameManager.GameState == GameStates.Over)
            {
                if (!_gameManager.Dead)
                {
                    _gameManager.Dead = true;
                    MediaPlayer.Pause();
                    die.Play();
                }
                _player.MinFrame = 4;
                _player.Position = new(_player.Position.X, _player.Position.Y + 2);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}