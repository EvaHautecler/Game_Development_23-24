using GameDevGame_Maze.Animaties;
using GameDevGame_Maze.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevGame_Maze
{
    public class Hero : IGameObject
    {
        private Texture2D textureHero;
        private Rectangle heroRectangle = new Rectangle();
        private Vector2 position = new Vector2(0, 0);
        private Vector2 speed = new Vector2(1, 1);
        private Vector2 accelaration = new Vector2(0.1f, 0.1f);
        private IInputReader inputReader;
        private Vector2 direction;
        
        
        
        Animation animation;

        SpriteEffects spriteEffects = SpriteEffects.None;

        //public Vector2 FuturePosition { get { return position + speed; } set { } }
        public Vector2 FuturePosition(Vector2 position)
        {
            direction *= speed;
            position += direction;
            return position;
        }

        public Rectangle HeroRectangle { get { return heroRectangle; } set { } }
        public Vector2 FuturePositionHero { get { return new Vector2(0, 0); } set { } }
        private void Move()
        {

            //position += speed;
            if (position.X > 3860 - 96)
            {
                position.X = 3860 - 96;
            }
            if (position.X < -15)
            {
                position.X = -15;
            }
            if (position.Y > 2160 - 96)
            {
                position.Y = 2160 - 96;
            }
            if (position.Y < -10)
            {
                position.Y = -10;
            }


            direction = inputReader.ReadInput();
            FuturePosition(position);
            //direction *= speed;
            //position += direction;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 1;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 1;
                spriteEffects = SpriteEffects.None;
            }

        }

        


        public Hero(Texture2D texture, IInputReader inputReader)
        {
            textureHero = texture;
            this.inputReader = inputReader;
            animation = new Animation();

            position = new Vector2(1, 1800);
            speed = new Vector2(2, 2);
            accelaration = new Vector2(0.1f, 0.1f);
            heroRectangle = new Rectangle((int)position.X, (int)position.Y, 140, 140);
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 1);
        }


        public void Update(GameTime gameTime)
        {

            Move();
            animation.Update(gameTime);

        }
        private int rotation = 0;
        public void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(textureHero, position, animation.CurrentFrame.SourceRectangle, Color.White);
            //spriteBatch.Draw(textureHero, new Rectangle((int)position.X, (int)position.Y, 140, 140), animation.CurrentFrame.SourceRectangle, Color.White, rotation, new Vector2(1, 1), spriteEffects, 0f);
            spriteBatch.Draw(textureHero, heroRectangle, animation.CurrentFrame.SourceRectangle, Color.White, rotation, new Vector2(1, 1), spriteEffects, 0f);
        }

    }
}
