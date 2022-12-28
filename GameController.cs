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

        public readonly static int PixelSize = 2;
        
        List<AnimShEntity> enemies= new List<AnimShEntity>();
        bool areEnemiesMovingRight = true;
        List<Bullet> enemyBullets = new List<Bullet>();
        
        PlayerCannon player;
        List<Bullet> playerBullets = new List<Bullet>();
        public int[] vectToMovePlayerBy = new int[] { 0, 0 };
        public bool fireButtonHeld = false;
        bool playerFireCooldownElapsed = true;
        public bool ogFireMode = true;
        public int player1Score = 0;

        List<Barrier> barriers = new List<Barrier>();

        public void Start()
        {
        player = new PlayerCannon( new Point(330, 680));
        int i = 0;
            //for (int j = 0; j < 11; j++)
            //{
            //    enemies.Add(new EnemyCrab(new Point((PixelSize*25) * j + 10, 150+i*50 )));
            //    enemies.Add(new EnemySquid(new Point((PixelSize * 25) * j + 10+2*PixelSize, 150 + (i+1) * 50)));
            //    enemies.Add(new EnemyEclipse(new Point((PixelSize * 25) * j + 10, 150 + (i + 2) * 50)));
            //}

            barriers.Add(new Barrier(new Point(200, 600), 2));
            
        fireCooldown = new System.Timers.Timer(450);
        fireCooldown.Elapsed += OnCooldownElapsed;
        fireCooldown.AutoReset = false;
        fireCooldown.Enabled = false;
        }
        int tmpCounter = 0; // TODO:        DELETE
        public void Update(PaintEventArgs e)
        {
            int speed = 5;

            player.MoveBy(vectToMovePlayerBy[0] * speed, vectToMovePlayerBy[1] * speed,true);
            if (fireButtonHeld)
            {
                PlayerFire();
            }
            player.Refresh(e.Graphics);

            tmpCounter++;
            if (tmpCounter > 50)
            {
                tmpCounter = 0;
                MoveEnemies(e.Graphics);
            }
           
            for (int bullet = 0; bullet < playerBullets.Count(); bullet++) // Update player bullets
            {

                int toDelete = CheckPlayerBullets(bullet, e);
                if (toDelete != -1) // remove collided bullet
                {
                    playerBullets.RemoveAt(toDelete);
                }

            }
            Random r = new Random();
            foreach (var enemy in enemies)
            {
                enemy.Refresh(e.Graphics); 

                int rand = r.Next(0,1000); //TODO redo this abomination
                if (rand > 998)
                {
                    enemyBullets.Add( enemy.Fire(Color.White));
                }
            }

            foreach (var bullet in enemyBullets)
            {
                bullet.Refresh(e.Graphics);
            }

            foreach (var barrier in barriers)
            {
                barrier.Refresh(e.Graphics);
            }

        }

        private int CheckPlayerBullets(int bullet, PaintEventArgs e)
        {
            int ifNotHitValue = -1;
            playerBullets[bullet].Refresh(e.Graphics);


            if (playerBullets[bullet].Pos.Y < 70) // check if bullet has left upper bounds
            {
                return bullet;
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

                    return bullet;
                }
            }

            foreach (var barrier in barriers) // check for collisions with barriers
            {
                if (barrier.IsAt(playerBullets[bullet].Pos.X, playerBullets[bullet].Pos.Y))
                {         
                    barrier.ReciveDamage(playerBullets[bullet].Pos.X, playerBullets[bullet].Pos.Y);
                    return bullet;
                }
            }

            return ifNotHitValue;
        }
        private void OnCooldownElapsed(Object? source, System.Timers.ElapsedEventArgs e)
        {
            playerFireCooldownElapsed = true;
        }
        private void PlayerFire()
        {
            if (ogFireMode)
            {
                if (playerBullets.Count() == 0)
                {
                    playerBullets.Add(player.Fire(PlayerCannon.color));
                }
            }
            else
            {
                if (playerFireCooldownElapsed)
                {
                    playerFireCooldownElapsed = false;
                    playerBullets.Add(player.Fire(PlayerCannon.color));
                    fireCooldown.Start();
                }
            } 
            
        }

        
        private void MoveEnemies(Graphics e)
        {
            if (enemies.Count != 0)
            {
                int stepSizeX = 10;
                int stepSizeY = 30;
                Entity rightmost = GetRightMostEnemy();
                Entity leftmost = GetLeftMostEnemy();
                int moveByX = 0, moveByY = 0;

                if ((rightmost.Pos.X > 700 - (13 * PixelSize) - stepSizeX) && areEnemiesMovingRight ||
                    (leftmost.Pos.X < 0 + stepSizeX) && !areEnemiesMovingRight)
                {
                    moveByY += stepSizeY;
                    areEnemiesMovingRight = !areEnemiesMovingRight;
                }
                else
                {
                    if (areEnemiesMovingRight)
                    {
                        moveByX += stepSizeX;
                    }
                    else
                    {
                        moveByX -= stepSizeX;
                    }
                }
                foreach (var enemie in enemies)
                {
                    enemie.MoveBy(moveByX, moveByY);
                }
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
