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
        
        TestEntity player;
        List<TestEntity> enemies= new List<TestEntity>();
        List<Bullet> playerBullets = new List<Bullet>();
        public int[] vectToMoveBy = new int[] { 0, 0 };
        public bool isFiring = false;
        bool canFire = true;
        public int player1Score = 0;

        public void Start()
        {
            player = new TestEntity(10, 80, Color.LightGreen);

            for (int i = 1; i < 6; i++)
            {
                enemies.Add(new TestEntity(100*i, 200, Color.Red));
            }

            fireCooldown = new System.Timers.Timer(450);
            fireCooldown.Elapsed += OnCooldownElapsed;
            fireCooldown.AutoReset = false;
            fireCooldown.Enabled = false;

            enemies[0].GraduallyMoveTo(500, 500, 500);
        }

        public void Update(PaintEventArgs e)
        {
            int speed = 5;

            player.MoveBy(vectToMoveBy[0] * speed, vectToMoveBy[1] * speed,true);

            Random rand = new Random();

            //if (rand.Next(0, 100) > 90)
            //{
            //    enemy.MoveBy(rand.Next(-5, 5), rand.Next(-5, 5));
            //}
            for (int bullet = 0; bullet < playerBullets.Count(); bullet++)
            {
                int toDelete = -1;
                playerBullets[bullet].Refresh(e.Graphics);
                for (int enemy = 0; enemy < enemies.Count(); enemy++)
                {
                    
                    if (enemies[enemy].isAt(playerBullets[bullet].Pos.X, playerBullets[bullet].Pos.Y))
                    {
                        player1Score += enemies[enemy].PointVal;
                        enemies[enemy].Die();
                        enemies.RemoveAt(enemy);
                        toDelete = bullet;
                    } 
                }
                if (toDelete != -1)
                {
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
            canFire = true;
        }
        private void PlayerFire()
        {
            if (canFire)
            {
                canFire = false;
                playerBullets.Add(player.Fire());
                fireCooldown.Start();
            }
            
        }

        
        
    }
}
