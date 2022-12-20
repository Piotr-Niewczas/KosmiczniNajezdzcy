using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace KosmiczniNajeźdźcy
{
    public class GameController
    {

        private static System.Timers.Timer fireCooldown;

        public readonly static int PixelSize = 3;
        
        TestEntity player;
        List<TestEntity> enemies= new List<TestEntity>();
        List<Bullet> playerBullets = new List<Bullet>();
        public int[] vectToMoveBy = new int[] { 0, 0 };
        public bool isFiring = false;
        bool fireCooldownElapsed = true;
        public bool ogFireMode = true;
        public int player1Score = 0;

        int enemyGroupXRight = 60 * 10 + 10;
        int enemyGroupXLeft = 10;

        public void Start()
        {
            player = new TestEntity( new Point(330, 680), Color.LightGreen);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    enemies.Add(new TestEntity(new Point(60 * j + 10, 150+i*50 ), Color.Aqua));
                }
            }
            

            fireCooldown = new System.Timers.Timer(450);
            fireCooldown.Elapsed += OnCooldownElapsed;
            fireCooldown.AutoReset = false;
            fireCooldown.Enabled = false;
        }
        int tmpCounter = 0; // TODO:        DELETE
        public void Update(PaintEventArgs e)
        {
            int speed = 5;

            player.MoveBy(vectToMoveBy[0] * speed, vectToMoveBy[1] * speed,true);

            tmpCounter++;
            if (tmpCounter > 50)
            {
                tmpCounter = 0;
                MoveEnemies(e.Graphics);
            }

            
            for (int bullet = 0; bullet < playerBullets.Count(); bullet++)
            {
                int toDelete = -1;
                playerBullets[bullet].Refresh(e.Graphics);
                
                if (playerBullets[bullet].Pos.Y < 70) // check if bullet has left upper bounds
                {
                    toDelete = bullet;
                }
                for (int enemy = 0; enemy < enemies.Count(); enemy++) // chech if bullet is in one of the enemies
                {
                    
                    if (enemies[enemy].IsAt(playerBullets[bullet].Pos.X, playerBullets[bullet].Pos.Y))
                    {
                        player1Score += enemies[enemy].PointVal;
                        if (enemies[enemy].ReciveDamage() == 0)
                        {
                            enemies.RemoveAt(enemy);
                        }
                        
                        toDelete = bullet;
                    } 
                }
                if (toDelete != -1)
                {
                    playerBullets[toDelete] = null;
                    playerBullets.RemoveAt(toDelete);
                }

            }
            if (isFiring)
            {
                PlayerFire();
            }

            foreach (var enemy in enemies)
            {
                enemy.Refresh(e.Graphics);
            }
            player.Refresh(e.Graphics);
            
        }
        private void OnCooldownElapsed(Object? source, System.Timers.ElapsedEventArgs e)
        {
            fireCooldownElapsed = true;
        }
        private void PlayerFire()
        {
            if (ogFireMode)
            {
                if (playerBullets.Count() == 0)
                {
                    playerBullets.Add(player.Fire());
                }
            }
            else
            {
                if (fireCooldownElapsed)
                {
                    fireCooldownElapsed = false;
                    playerBullets.Add(player.Fire());
                    fireCooldown.Start();
                }
            } 
            
        }

        bool areEnemiesMovingRight = true;
        private void MoveEnemies(Graphics e)
        {
            int stepSize = 30;
            Entity rightmost = GetRightMostEnemy();
            Entity leftmost = GetLeftMostEnemy(); 
            int moveByX = 0, moveByY = 0;

            if ((rightmost.Pos.X >= 700-rightmost.SizeX - stepSize) && areEnemiesMovingRight ||
                (leftmost.Pos.X < 0+stepSize) && !areEnemiesMovingRight )
            {
                moveByY += stepSize;
                areEnemiesMovingRight = !areEnemiesMovingRight;
            }
            else
            {
                if (areEnemiesMovingRight)
                {
                    moveByX += stepSize;
                }
                else
                {
                    moveByX -= stepSize;
                }
            }
            foreach (var enemie in enemies)
            {
                enemie.MoveBy(moveByX, moveByY);
            }
        }
        private Entity GetRightMostEnemy()
        {
            int max = int.MinValue;
            Entity entity = enemies[0];
            foreach (var enemy in enemies)
            {
                if (enemy.Pos.X > max)
                {
                    max = enemy.Pos.X;
                    entity = enemy;
                }
            }
            return entity;
        }
        private Entity GetLeftMostEnemy()
        {
            int min = int.MaxValue;
            Entity entity = enemies[0];
            foreach (var enemy in enemies)
            {
                if (enemy.Pos.X > min)
                {
                    min = enemy.Pos.X;
                    entity = enemy;
                }
            }
            return entity;
        }
    }
}
