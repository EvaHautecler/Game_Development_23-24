using Game_Development_Space_Shooter.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Rectangle spaceshipRectangle;
        private float airplaneSpeed = 2.0f;
        private KeyboardReader keyboardReader;

        public SpaceshipHero(Texture2D spaceshipTexture, KeyboardReader keyboardReader)
        {
            this.spaceshipTexture = spaceshipTexture;
            this.keyboardReader = keyboardReader;

            spaceshipRectangle = new Rectangle(500, 270, 76, 48);
            keyboardReader = new KeyboardReader();
        }

        public void Update(GameTime gameTime)
        {
            spaceshipRectangle = keyboardReader.ReadInput(spaceshipRectangle, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spaceshipTexture, spaceshipRectangle, Color.White);
        }
    }
}
