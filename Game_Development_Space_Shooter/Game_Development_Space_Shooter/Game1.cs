using Game_Development_Space_Shooter.Characters;
using Game_Development_Space_Shooter.Input;
using Game_Development_Space_Shooter.Managers;
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
        private Texture2D enemySpaceshipTexture;
        private Texture2D astroidTexture;
        private SpaceshipHero spaceshipHero;
        private KeyboardReader keyboardReader;

        private Manager enemySpaceship;
        private Manager asteroid;

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
            enemySpaceship = new Manager();
            enemySpaceship.AddRandomEnemy(enemySpaceshipTexture, 1500, 70);
            enemySpaceship.AddRandomEnemy(enemySpaceshipTexture, 1500, 256);
            enemySpaceship.AddRandomEnemy(enemySpaceshipTexture, 1500, 442);
            enemySpaceship.AddRandomEnemy(enemySpaceshipTexture, 1500, 628);
            enemySpaceship.AddRandomEnemy(enemySpaceshipTexture, 1500, 814);
            asteroid = new Manager();
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 0);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 0);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 178);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 178);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 364);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 364);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 550);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 550);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 736);
            asteroid.AddRandomAsteroids(astroidTexture, 1500, 736);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("space");
            spaceshipTexture = Content.Load<Texture2D>("Move1");
            laserTexture = Content.Load<Texture2D>("Charge");
            enemySpaceshipTexture = Content.Load<Texture2D>("enemySpaceship");
            astroidTexture = Content.Load<Texture2D>("asteroid");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            spaceshipHero.Update(gameTime);
            enemySpaceship.UpdateAll(gameTime);
            asteroid.UpdateAll(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1500, 950), Color.White);
            spaceshipHero.Draw(_spriteBatch);
            enemySpaceship.DrawAll(_spriteBatch);
            asteroid.DrawAll(_spriteBatch);
            //_spriteBatch.Draw(enemySpaceship, new Rectangle(700, 800, 128, 128), Color.White);
            //_spriteBatch.Draw(spaceshipTexture, new Rectangle(500, 270, 76, 48), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}