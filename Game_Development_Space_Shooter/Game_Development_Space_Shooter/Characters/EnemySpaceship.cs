using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Characters
{
    public class EnemySpaceship
    {
        private Texture2D enemyTexture;
        private Rectangle enemyRectangle;
        private float enemySpeed;
        private Vector2 position;

        public EnemySpaceship(Texture2D enemyTexture, Rectangle enemyRectangle, float enemySpeed, Vector2 position)
        {
            this.enemyTexture = enemyTexture;
            this.enemyRectangle = enemyRectangle;
            this.enemySpeed = enemySpeed;
            this.position = position;
        }

        //Updating enemy spaceship
        public void Update()
        {
            Move();
        }

        //Drawing enemy spaceship
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, enemyRectangle, Color.White);
        }

        //Movements for the enemy Spaceship
        public Rectangle Move()
        {
            enemyRectangle.X += (int)(position.X * enemySpeed);
            enemyRectangle.Y += (int)(position.Y * enemySpeed);

            if (enemyRectangle.X < -96)
            {
                enemyRectangle.X = 1596;
            }
            if (enemyRectangle.X > 1596)
            {
                enemyRectangle.X = -96;
            }
            if (enemyRectangle.Y < -46)
            {
                enemyRectangle.Y = 996;
            }
            if (enemyRectangle.Y > 996)
            {
                enemyRectangle.Y = -46;
            }
            return enemyRectangle;
        }
    }
}
