using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameDevGame_Maze
{
    public class Maze
    {

        private Texture2D blokTexture;
        private List<Texture2D> blocks;
        private Rectangle mazeRectangle = new Rectangle();
        private Vector2 position;

        int[,] gameboard = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1 },
            {1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1 },
            {1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1 },
            {1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1 },
            {1,0,1,0,1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,1 },
            {1,0,1,1,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1 },
            {1,0,0,0,0,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,1 },
            {1,0,1,1,1,1,1,0,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1 },
            {1,0,1,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1 },
            {1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1 },
            {1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0,1 },
            {1,0,1,0,1,0,0,1,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1 },
            {1,0,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,1 },
            {1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1 },
            {1,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,1 },
            {0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,1,1,1,0,1,0,1,0,1,0,0,0,0,0,0 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
        };

        public Vector2 PositionMazeBlock { get { return position; } }
        
        
        public Maze(Texture2D texture, List<Texture2D> blocks)
        {
            blokTexture = texture;
            this.blocks = blocks;
        }
        Hero hero;
        public void checkCollision(List<Texture2D> blocks)
        {
            foreach (Texture2D texture in blocks)
            {
                if (mazeRectangle.Intersects(hero.HeroRectangle))
                {
                    hero.FuturePosition(hero.FuturePositionHero);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            checkCollision(blocks);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < gameboard.GetLength(1); i++)
            {
                for (int j = 0; j < gameboard.GetLength(0); j++)
                {
                    if (gameboard[j, i] == 1)
                    {
                        //position = new Vector2(0, 0);
                        blocks.Add(blokTexture);
                        mazeRectangle = new Rectangle(i * 110, j * 115, 95, 105);
                        spriteBatch.Draw(blokTexture, mazeRectangle, Color.White);
                    }
                }
            }
        }
        
        
        
    }
}
