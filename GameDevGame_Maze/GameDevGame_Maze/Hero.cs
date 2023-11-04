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

        Animation animation;

        public Hero(Texture2D texture)
        {
            textureHero = texture;
            //heroRectangle = new Rectangle(schuifOp_X, 0, 96, 96);
            animation = new Animation();
            animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 96, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(96, 0, 96, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(192, 0, 96, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(288, 0, 96, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(384, 0, 96, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(480, 0, 96, 96)));
            animation.AddFrame(new AnimationFrame(new Rectangle(576, 0, 96, 96)));
        }


        public void Update()
        {
            /*schuifOp_X += 96;
            if (schuifOp_X > 576)
            {
                schuifOp_X = 0;
            }
            heroRectangle.X = schuifOp_X;*/
            animation.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureHero, new Vector2(0, 0), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
    
}
