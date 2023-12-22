using Game_Development_Space_Shooter.Animaties;
using Game_Development_Space_Shooter.Input;
using Game_Development_Space_Shooter.Managers;
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
        private Manager laserManager;

        public SpaceshipHero(Texture2D spaceshipTexture, KeyboardReader keyboardReader, Texture2D laserTexture)
        {
            this.spaceshipTexture = spaceshipTexture;
            this.keyboardReader = keyboardReader;
            this.laserTexture = laserTexture;

            spaceshipRectangle = new Rectangle(500, 270, 76, 48);

            animationSpaceship = new Animation();
            animationSpaceship.GetFramesFromTextureProperties(spaceshipTexture.Width, spaceshipTexture.Height, 1, 1);
            keyboardReader = new KeyboardReader();
            laserManager = new Manager();
        }

        public void Update(GameTime gameTime)
        {
            spaceshipRectangle = keyboardReader.ReadInput(spaceshipRectangle, gameTime);
            animationSpaceship.Update(gameTime);
            Shoot();
            laserManager.UpdateAll(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spaceshipTexture, spaceshipRectangle,animationSpaceship.CurrentFrame.SourceRectangle, Color.White, keyboardReader.AngleTotation(), new Vector2(spaceshipTexture.Width/2, spaceshipTexture.Height/2), SpriteEffects.None, 0f);
            laserManager.DrawAll(spriteBatch);
        }

        private void Shoot()
        {
            float angle = keyboardReader.AngleTotation();
            Vector2 direction = new Vector2((float)Math.Cos(angle), -(float)Math.Sin(angle));
            Vector2 startPosition = new Vector2(spaceshipRectangle.Center.X, spaceshipRectangle.Center.Y);
            startPosition -= new Vector2(spaceshipRectangle.Width / 2, spaceshipRectangle.Height / 2);
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Up) && Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                laserManager.AddLasers(laserTexture, new Rectangle((int)startPosition.X, (int)startPosition.Y, 3, 3), direction);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space)) 
            {
                laserManager.AddLasers(laserTexture, new Rectangle((int)startPosition.X, (int)startPosition.Y, 10, 3), direction);
            }
            

        }
    }
}
