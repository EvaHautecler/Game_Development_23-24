using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Input
{
    public class KeyboardReader
    {
        private Rectangle spaceshipRectangle;
        private float spaceshipSpeed = 2.0f;

        public Rectangle ReadInput(Rectangle spaceshipRectangle, GameTime gameTime)
        {
            this.spaceshipRectangle = spaceshipRectangle;
            Rectangle newSpaceship = new Rectangle(spaceshipRectangle.X, spaceshipRectangle.Y, spaceshipRectangle.Width, spaceshipRectangle.Height);

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                newSpaceship.X -= (int)(spaceshipSpeed * gameTime.ElapsedGameTime.TotalSeconds * 60);
                spaceshipRectangle.X = newSpaceship.X;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                newSpaceship.X += (int)(spaceshipSpeed * gameTime.ElapsedGameTime.TotalSeconds * 60);
                spaceshipRectangle.X = newSpaceship.X;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                newSpaceship.Y -= (int)(spaceshipSpeed * gameTime.ElapsedGameTime.TotalSeconds * 60);
                spaceshipRectangle.Y = newSpaceship.Y;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                newSpaceship.Y += (int)(spaceshipSpeed * gameTime.ElapsedGameTime.TotalSeconds * 60);
                spaceshipRectangle.Y = newSpaceship.Y;
            }

            if (spaceshipRectangle.X > 1500 - 48)
            {
                spaceshipRectangle.X = 1500 - 48;
            }
            if (spaceshipRectangle.X < 0)
            {
                spaceshipRectangle.X = 0;
            }
            if (spaceshipRectangle.Y > 950 - 76)
            {
                spaceshipRectangle.Y = 950 - 76;
            }
            if (spaceshipRectangle.Y <0)
            {
                spaceshipRectangle.Y = 0;
            }

            return spaceshipRectangle;
        }

    }
}
