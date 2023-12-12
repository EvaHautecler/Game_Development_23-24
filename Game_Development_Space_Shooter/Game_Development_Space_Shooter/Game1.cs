using Game_Development_Space_Shooter.Characters;
using Game_Development_Space_Shooter.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Development_Space_Shooter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D backgroundTexture;
        private Texture2D spaceshipTexture;
        private Texture2D laserTexture;
        private Texture2D enemySpaceship;
        private SpaceshipHero spaceshipHero;
        private KeyboardReader keyboardReader;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 950;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            keyboardReader = new KeyboardReader();
            spaceshipHero = new SpaceshipHero(spaceshipTexture, keyboardReader, laserTexture);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("Background");
            spaceshipTexture = Content.Load<Texture2D>("Move1");
            laserTexture = Content.Load<Texture2D>("Charge");
            enemySpaceship = Content.Load<Texture2D>("enemySpaceship");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            spaceshipHero.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1500, 950), Color.White);
            spaceshipHero.Draw(_spriteBatch);
            _spriteBatch.Draw(enemySpaceship, new Rectangle(700, 800, 128, 128), Color.White);
            //_spriteBatch.Draw(spaceshipTexture, new Rectangle(500, 270, 76, 48), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}