using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevGame_Maze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backgroundTexture;
        private Texture2D texture;
        private Rectangle heroRectangle;
        private int schuifOp_X = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            heroRectangle = new Rectangle(schuifOp_X, 0, 96, 96);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            backgroundTexture = Content.Load<Texture2D>("floor");
            texture = Content.Load<Texture2D>("HeroWalk");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 800, 480), Color.White);
            _spriteBatch.Draw(texture, new Vector2(0, 0),heroRectangle, Color.White);
            _spriteBatch.End();

            schuifOp_X += 96;
            if (schuifOp_X > 576)
            {
                schuifOp_X = 0;
            }
            heroRectangle.X = schuifOp_X;


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}