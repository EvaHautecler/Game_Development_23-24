using Game_Development_Space_Shooter.Animaties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Characters
{
    public class Asteroid
    {
        private Texture2D asteroidTexture;
        private Rectangle asteroidRectangle;
        private Animation animation;

        public Asteroid(Texture2D asteroidTexture, Rectangle asteroidRectangle)
        {
            this.asteroidTexture = asteroidTexture;
            this.asteroidRectangle = asteroidRectangle;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(asteroidTexture.Width, asteroidTexture.Height, 5, 1);
        }

        //updating astroid
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        //drawing astroid
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(asteroidTexture, asteroidRectangle, animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
