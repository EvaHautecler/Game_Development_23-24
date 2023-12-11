using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Characters
{
    public class SpaceshipLaser
    {
        private Texture2D laserTexture;
        private Rectangle laserRectangle;
        private float laserSpeed = 5.0f;
        private Vector2 direction;

        public SpaceshipLaser(Texture2D laserTexture, Rectangle laserRectangle, Vector2 direction)
        {
            this.laserTexture = laserTexture;
            this.laserRectangle = laserRectangle;
            this.direction = direction;
        }

        public void Update()
        {
            laserRectangle.X += (int)(laserSpeed * direction.X);
            laserRectangle.Y -= (int)(laserSpeed * direction.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(laserTexture, laserRectangle, Color.White);
        }

    }
}
