using GameDevGame_Maze.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevGame_Maze.Input
{
    public class keyboardReader : IInputReader
    {
        public SpriteEffects spriteEffects()
        {
            SpriteEffects effect = SpriteEffects.None;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            return effect;
        }
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
            }
            return direction;
        }
    }
}
