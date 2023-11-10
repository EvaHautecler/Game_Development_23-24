using GameDevGame_Maze.Animaties;
using GameDevGame_Maze.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Vector2 speed = new Vector2(1,1);
        private Vector2 accelaration = new Vector2(0.1f, 0.1f);

        Animation animation;


        private void Move()
        {
            position += speed;
            speed += accelaration;
            float maxSpeed = 10;
            speed = Limit(speed, maxSpeed);
            if (position.X > 1280 - 96 || position.X < 0)
            {
                speed.X *= -1;
                accelaration.X *= -1;
            }
            if (position.Y > 720 - 96 || position.Y < 0)
            {
                speed.Y *= -1;
                accelaration.Y *= -1;
            }
            if (position.X + speed.X > 1280 - 96 || position.X + speed.X < 0)
            {
                speed = new Vector2(speed.X < 0 ? 1 : -1, speed.Y);
                accelaration.X *= -1;
            }
            if (position.Y + speed.Y > 720 - 96 || position.Y + speed.Y < 0)
            {
                speed = new Vector2(speed.X, speed.Y < 0 ? 1 : -1);
                speed.Y *= -1;
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

        public Hero(Texture2D texture)
        {
            textureHero = texture;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 7, 1);
            
        }


        public void Update(GameTime gameTime)
        {
            
            animation.Update(gameTime);
            Move();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureHero, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
    
}
