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
    public class Manager
    {
        private List<EnemySpaceship> allEnemies = new List<EnemySpaceship>();
        private List<Asteroid> allAsteroids = new List<Asteroid>();
        private Random random = new Random();

        //Adding enemies to the allEnemies list
        public void AddEnemies(Texture2D enemyTexture, Rectangle enemyRectangle, float enemySpeed, Vector2 enemyPosition)
        {
            EnemySpaceship newEnemy = new EnemySpaceship(enemyTexture, enemyRectangle, enemySpeed, enemyPosition);
            allEnemies.Add(newEnemy);
        }

        //Adding astroids to the allAstroid list
        public void AddAstroids(Texture2D asteroidTexture, Rectangle asteroidRectangle)
        {
            Asteroid newAsteroid = new Asteroid(asteroidTexture, asteroidRectangle);
            allAsteroids.Add(newAsteroid);
        }

        public void AddRandomEnemy(Texture2D enemyTexture, int screenWidth, int y)
        {
            int width = 96; //Width of the enemySpaceship
            int height = 46; // height of the enemySpaceship
            float enemySpeed = random.Next(3, 5);
            int x = random.Next(0, screenWidth - width);
            Rectangle randomEnemyRectangle = new Rectangle(x, y, width, height);
            Vector2 position = new Vector2(-1, 0); //so the spaceship is always going to the left
            AddEnemies(enemyTexture,randomEnemyRectangle , enemySpeed, position);
        }

        public void AddRandomAsteroids(Texture2D asteroidTexture, int screenWidth, int y)
        {
            int width = 102; //width of the asteroid
            int height = 54; //height of the asteroid
            int x = random.Next(0, screenWidth - width);
            Rectangle asteroidRectangle = new Rectangle(x, y, width, height);
            AddAstroids(asteroidTexture, asteroidRectangle);
        }

        //Updating all what is in both of the lists
        public void UpdateAll(GameTime gameTime)
        {
            foreach (EnemySpaceship enemy in allEnemies)
            {
                enemy.Update();
            }
            foreach (Asteroid asteroid in allAsteroids)
            {
                asteroid.Update(gameTime);
            }
        }

        
        //Drawing all what is in both of the lists
        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (EnemySpaceship enemy in allEnemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (Asteroid asteroid in allAsteroids)
            {
                asteroid.Draw(spriteBatch);
            }
        }


        //If you want to get all the enemies in the allEnemies list
        /*public List<EnemySpaceship> GetAllEnemies()
        {
            return allEnemies;
        }*/

        //If you want to get all the asteroids in the allAstroids list
        /*public List<Asteroid> GetAllAsteroids()
        {
            return allAsteroids;
        }*/
    }
}
