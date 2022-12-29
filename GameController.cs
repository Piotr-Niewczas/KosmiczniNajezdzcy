using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace KosmiczniNajeźdźcy
{
    public class GameController
    {

        private static System.Timers.Timer playerFireCooldown;
        private static System.Timers.Timer enemyTick;

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
        
            for (int j = 0; j < 11; j++) // spawn enemies
            {
                enemies.Add(new EnemySquid((PixelSize * 25) * j + 70 + 2 * PixelSize, 175));
                enemies.Add(new EnemyCrab((PixelSize * 25) * j + 70, 175 + 50 * 1));
                enemies.Add(new EnemyCrab((PixelSize * 25) * j + 70, 175 + 50 * 2));
                enemies.Add(new EnemyEclipse((PixelSize * 25) * j + 70, 175 + 50 * 3));
                enemies.Add(new EnemyEclipse((PixelSize * 25) * j + 70, 175 + 50 * 4));
            }

            for (int b = 0; b < 4; b++) // spawn barriers
            {
                barriers.Add(new Barrier(new Point(90+150*b, 590), 2));
            }

            playerFireCooldown = new System.Timers.Timer(450);
            playerFireCooldown.Elapsed += OnPlayerFireCooldownElapsed;
            playerFireCooldown.AutoReset = false;
            playerFireCooldown.Enabled = false;

            enemyTick = new System.Timers.Timer(125);
            enemyTick.Elapsed += OnEnemyTick;
            enemyTick.AutoReset = true;
            enemyTick.Enabled = false;
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

            tmpCounter++; // TODO   NO
            if (tmpCounter > 50)
            {
                tmpCounter = 0;
                MoveEnemies(e.Graphics);
            }

            bool bulletHasCollided = false;
            for (int bullet = 0; bullet < playerBullets.Count(); bullet++) // Update player bullets
            {

                int toDelete = CheckPlayerBullets(bullet, e);
                if (toDelete != -1) // remove collided bullet
                {
                    bulletHasCollided = true;
                    playerBullets.RemoveAt(toDelete);
                }

            }
            for (int bullet = 0; bullet < enemyBullets.Count(); bullet++) // Update enemy bullets
            {

                int toDelete = CheckEnemyBullets(bullet, e);
                if (toDelete != -1) // remove collided bullet
                {
                    bulletHasCollided = true;
                    enemyBullets.RemoveAt(toDelete);
                }

            }
            if (bulletHasCollided)
            {
                foreach (var enemy in enemies)
                {
                    enemy.Refresh(e.Graphics);
                }
                foreach (var barrier in barriers)
                {
                    barrier.Refresh(e.Graphics);
                }
            }
            

            Random r = new Random();
            foreach (var enemy in enemies)
            {
                //enemy.Refresh(e.Graphics); 

                int rand = r.Next(0,10000); //TODO redo this abomination
                if (rand > 9990)
                {
                    enemyBullets.Add( enemy.Fire(Color.White));
                }
            }

            

        }
        private void RefreshAll(List<Entity> list)
        {

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

        private int CheckEnemyBullets(int bullet, PaintEventArgs e)
        {
            int ifNotHitValue = -1;

            enemyBullets[bullet].Refresh(e.Graphics);

            if (enemyBullets[bullet].Pos.Y >= 750) // check if bullet has left lower bounds
            {
                return bullet;
            }

            foreach (var barrier in barriers) // check for collisions with barriers
            {
                if (barrier.IsAt(enemyBullets[bullet].Pos.X, enemyBullets[bullet].Pos.Y))
                {
                    barrier.ReciveDamage(enemyBullets[bullet].Pos.X, enemyBullets[bullet].Pos.Y);
                    return bullet;
                }
            }

            if (player.IsAt(enemyBullets[bullet].Pos.X, enemyBullets[bullet].Pos.Y))
            {
                PlayerShot();
                return bullet;
            }

            return ifNotHitValue;
        }

        private void PlayerShot()
        {

        }

        private void OnPlayerFireCooldownElapsed(Object? source, System.Timers.ElapsedEventArgs e)
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
                    playerFireCooldown.Start();
                }
            } 
            
        }

        private void OnEnemyTick(Object? source, System.Timers.ElapsedEventArgs e)
        {

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

                if ((rightmost.Pos.X + rightmost.SizeX > 700 - stepSizeX) && areEnemiesMovingRight ||
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
                if (enemy.Pos.X + enemy.SizeX > max)
                {
                    max = enemy.Pos.X + enemy.SizeX;
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
