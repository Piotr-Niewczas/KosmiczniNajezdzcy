﻿using System;
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
        
        PlayerCannon player;
        List<AnimShEntity> enemies= new List<AnimShEntity>();
        bool areEnemiesMovingRight = true;

        List<Bullet> playerBullets = new List<Bullet>();
        public int[] vectToMovePlayerBy = new int[] { 0, 0 };
        public bool fireButtonHeld = false;
        bool playerFireCooldownElapsed = true;
        public bool ogFireMode = true;
        public int player1Score = 0;

        public void Start()
        {
        player = new PlayerCannon( new Point(330, 680));
        int i = 0;
        for (int j = 0; j < 10; j++)
        {
            enemies.Add(new EnemyCrab(new Point(60 * j + 10, 150+i*50 )));
            enemies.Add(new EnemySquid(new Point(60 * j + 10 + 8, 150 + (i+1) * 50)));
            enemies.Add(new EnemyEclipse(new Point(60 * j + 10, 150 + (i + 2) * 50)));
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

            player.MoveBy(vectToMovePlayerBy[0] * speed, vectToMovePlayerBy[1] * speed,true);

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
            if (fireButtonHeld)
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
            playerFireCooldownElapsed = true;
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
                if (playerFireCooldownElapsed)
                {
                    playerFireCooldownElapsed = false;
                    playerBullets.Add(player.Fire());
                    fireCooldown.Start();
                }
            } 
            
        }

        
        private void MoveEnemies(Graphics e)
        {
            int stepSizeX = 15;
            int stepSizeY = 30;
            Entity rightmost = GetRightMostEnemy();
            Entity leftmost = GetLeftMostEnemy(); 
            int moveByX = 0, moveByY = 0;

            if ((rightmost.Pos.X >= 700-rightmost.SizeX - stepSizeX) && areEnemiesMovingRight ||
                (leftmost.Pos.X < 0+stepSizeX) && !areEnemiesMovingRight )
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
