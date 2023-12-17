using Game_Development_Space_Shooter.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Development_Space_Shooter.Managers
{
    public class EnemySpaceshipManager
    {
        private List<EnemySpaceship> allEnemies = new List<EnemySpaceship>();
        private Random random = new Random();

        //Adding enemies to the allEnemies list
        public void AddEnemies(Texture2D enemyTexture, Rectangle enemyRectangle, float enemySpeed, Vector2 enemyPosition)
        {
            EnemySpaceship newEnemy = new EnemySpaceship(enemyTexture, enemyRectangle, enemySpeed, enemyPosition);
            allEnemies.Add(newEnemy);
        }

        public void AddRandomEnemy(Texture2D enemyTexture, int screenWidth, int y)
        {
            int width = 128; //Width of the enemySpaceship
            int height = 128; // height of the enemySpaceship
            float enemySpeed = random.Next(3, 5);
            Rectangle randomEnemyRectangle;
            int x = random.Next(0, screenWidth - width);
            randomEnemyRectangle = new Rectangle(x, y, width, height);
            Vector2 position = new Vector2(-1, 0); //so the spaceship is always going to the left
            AddEnemies(enemyTexture,randomEnemyRectangle , enemySpeed, position);
        }

        //Updating all the enemies that are in the allEnemies list
        public void UpdateAllEnemies()
        {
            foreach (EnemySpaceship enemy in allEnemies)
            {
                enemy.Update();
            }
        }

        //Drawing all the enemies in the allEnemies list
        public void DrawAllEnemies(SpriteBatch spriteBatch)
        {
            foreach (EnemySpaceship enemy in allEnemies)
            {
                enemy.Draw(spriteBatch);
            }
        }

        //If you want to get all the enemies in the allEnemies list
        public List<EnemySpaceship> GetAllEnemies()
        {
            return allEnemies;
        }
    }
}
