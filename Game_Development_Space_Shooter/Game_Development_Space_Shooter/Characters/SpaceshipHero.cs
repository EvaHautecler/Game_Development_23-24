using Game_Development_Space_Shooter.Animaties;
using Game_Development_Space_Shooter.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Characters
{
    public class SpaceshipHero
    {
        private Texture2D spaceshipTexture;
        private Texture2D laserTexture;
        private Rectangle spaceshipRectangle;
        private float airplaneSpeed = 2.0f;
        private KeyboardReader keyboardReader;
        private Animation animationSpaceship;
        private List<SpaceshipLaser> lasers;

        public SpaceshipHero(Texture2D spaceshipTexture, KeyboardReader keyboardReader, Texture2D laserTexture)
        {
            this.spaceshipTexture = spaceshipTexture;
            this.keyboardReader = keyboardReader;
            this.laserTexture = laserTexture;

            spaceshipRectangle = new Rectangle(500, 270, 76, 48);

            animationSpaceship = new Animation();
            animationSpaceship.GetFramesFromTextureProperties(spaceshipTexture.Width, spaceshipTexture.Height, 1, 1);
            keyboardReader = new KeyboardReader();
            lasers = new List<SpaceshipLaser>();
        }

        public void Update(GameTime gameTime)
        {
            spaceshipRectangle = keyboardReader.ReadInput(spaceshipRectangle, gameTime);
            animationSpaceship.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Shoot();
            }
            foreach (SpaceshipLaser laser in lasers)
            {
                laser.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spaceshipTexture, spaceshipRectangle,animationSpaceship.CurrentFrame.SourceRectangle, Color.White, keyboardReader.AngleTotation(), new Vector2(spaceshipTexture.Width/2, spaceshipTexture.Height/2), SpriteEffects.None, 0f);
            foreach (SpaceshipLaser laser in lasers)
            {
                laser.Draw(spriteBatch);
            }
        }

        public void Shoot()
        {
            float angle = keyboardReader.AngleTotation();
            Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            direction.Y = -direction.Y;
            Vector2 laserStartPosition = new Vector2(spaceshipRectangle.Center.X, spaceshipRectangle.Center.Y);
            laserStartPosition -= new Vector2(spaceshipRectangle.Width / 2, spaceshipRectangle.Height / 2);

            Rectangle laserPosition = new Rectangle((int)laserStartPosition.X, (int)laserStartPosition.Y, 28, 3);

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                laserPosition = new Rectangle((int)laserStartPosition.X - 2, (int)laserStartPosition.Y, 3, 28);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                laserPosition = new Rectangle((int)laserStartPosition.X - 2, (int)laserStartPosition.Y-29, 3, 28);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                laserPosition = new Rectangle((int)laserStartPosition.X - 29, (int)laserStartPosition.Y-2, 28, 3);
            }
            if ((Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Right)) || (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Right)) || (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Left)) || (Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Left)))
            {
                laserPosition = new Rectangle((int)laserStartPosition.X, (int)laserStartPosition.Y - 1, 3, 3);
            }

            SpaceshipLaser laser = new SpaceshipLaser(laserTexture, laserPosition, direction);
            lasers.Add(laser);
        }
    }
}
