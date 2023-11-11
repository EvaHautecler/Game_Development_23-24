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
        private Rectangle heroRectangle;
        private int schuifOp_X = 0;
        private Vector2 position = new Vector2(0, 0);
        private Vector2 speed = new Vector2(1, 1);
        private Vector2 accelaration = new Vector2(0.1f, 0.1f);
        private IInputReader inputReader;

        Animation animation;

        SpriteEffects spriteEffects = SpriteEffects.FlipHorizontally;


        private void Move()
        {

            //position += speed;
            if (position.X > 1280 - 96)
            {
                position.X = 1280 - 96;
            }
            if (position.X < -15)
            {
                position.X = -15;
            }
            if (position.Y > 720 - 96)
            {
                position.Y = 720 - 96;
            }
            if (position.Y < -10)
            {
                position.Y = -10;
            }

            var direction = inputReader.ReadInput();
            direction *= speed;
            position += direction;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 2;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 2;
                spriteEffects = SpriteEffects.None;
            }

        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }


        public Hero(Texture2D texture, IInputReader inputReader)
        {
            textureHero = texture;
            this.inputReader = inputReader;
            animation = new Animation();

            position = new Vector2(1, 1);
            speed = new Vector2(2, 2);
            accelaration = new Vector2(0.1f, 0.1f);
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
            spriteBatch.Draw(textureHero, new Rectangle((int)position.X, (int) position.Y, 96,96), animation.CurrentFrame.SourceRectangle, Color.White, rotation, new Vector2(1, 1), spriteEffects, 0f);

        }

    }
}
