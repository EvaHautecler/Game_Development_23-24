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

        public Hero(Texture2D texture)
        {
            textureHero = texture;
            heroRectangle = new Rectangle(schuifOp_X, 0, 96, 96);
        }


        public void Update()
        {
            schuifOp_X += 96;
            if (schuifOp_X > 576)
            {
                schuifOp_X = 0;
            }
            heroRectangle.X = schuifOp_X;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureHero, new Vector2(0, 0), heroRectangle, Color.White);
        }
    }
    
}
