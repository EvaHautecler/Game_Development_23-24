//using GameDevGame_Maze.Collisions;
using GameDevGame_Maze.Characters;
using GameDevGame_Maze.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using System.Collections.Generic;

namespace GameDevGame_Maze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D backgroundTexture;
        private Texture2D textureHero;

        private Texture2D blokTexture;
        //private bool heroRectangleMovesLeft;
        
        Hero hero;
        Maze maze;
        

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 3840;
            _graphics.PreferredBackBufferHeight = 2160;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            hero = new Hero(textureHero, new keyboardReader());
            maze = new Maze(blokTexture, new List<Texture2D>());
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            backgroundTexture = Content.Load<Texture2D>("BrickGround");
            textureHero = Content.Load<Texture2D>("HeroWalk");
            blokTexture = Content.Load<Texture2D>("TopDownGroundStoneTilesTileset");
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            /*if (Contains(hero.FuturePosition, maze.PositionMazeBlock))
            {
                hero.FuturePosition = new Vector2(0, 0);
            }*/

            /*if (Contains(hero.FuturePositionHero, maze.PositionMazeBlock))
            {
                hero.FuturePositionHero = new Vector2(0, 0);
            }*/
            //maze.Update(gameTime);

            hero.Update(gameTime);
            base.Update(gameTime);
        }
        
        /*public bool Contains(Vector2 positionHero, Vector2 positionMaze)
        {
            if (positionHero.X < positionMaze.X) return false;
            if (positionHero.X > (positionMaze.X + blokTexture.Width)) return false;
            if (positionHero.Y < positionMaze.Y) return false;
            if (positionHero.Y > (positionMaze.X + blokTexture.Height)) return false;
            return true;
        }*/

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 3840, 2160), Color.White);
            hero.Draw(_spriteBatch);
            maze.Draw(_spriteBatch);
            
            _spriteBatch.End();

            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}