using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Characters
{
    public class Star
    {
        private Texture2D starTexture;
        private Rectangle starRectangle;
        private float starSpeed;
        private Vector2 position;
        private float elapsedTime = 0.0f;
        private float interval = 20.0f;
        private bool isStarOnScreen = false;

        public Star(Texture2D starTexture)
        {
            this.starTexture = starTexture;
        }

        public void Update()
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (isStarOnScreen && elapsedTime >= interval)
            {
                ResetStarPosition();
                isStarOnScreen = false;
                elapsedTime = 0.0f;
            }
            else if (!isStarOnScreen)
            {
                Move();
                if (starRectangle.Y > 1210)
                {
                    isStarOnScreen = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(starTexture, starRectangle, Color.White);
        }

        private void Move()
        {
            starRectangle.X -= (int)(position.X * starSpeed);
            starRectangle.Y += (int)(position.Y * starSpeed);

        }
        private void ResetStarPosition()
        {
            starRectangle.Y = -290;
            starRectangle.X = 1210;
        }
    }
}
