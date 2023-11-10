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

        Animation animation;


        private void Move()
        {
            position += speed;
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
