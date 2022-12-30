namespace KosmiczniNajeźdźcy
{
    public class GameController
    {
        private Bitmap playArea = new Bitmap(700, 800);

        private static System.Timers.Timer playerFireCooldown;
        private static System.Timers.Timer enemyTick;

        public readonly static int PixelSize = 2;

        List<AnimShEntity> enemies = new();
        bool areEnemiesMovingRight = true;
        List<Bullet> enemyBullets = new();
        bool enemiesTickHappened = false;

        PlayerCannon player;
        List<Bullet> playerBullets = new();
        public int[] vectToMovePlayerBy = new int[] { 0, 0 };
        public bool fireButtonHeld = false;
        bool playerFireCooldownElapsed = true;
        public bool ogFireMode = true;
        public int player1Score = 0;
        bool bulletHasCollided = true; // since last partial redraw

        List<Barrier> barriers = new();

        public void Start()
        {
            player = new PlayerCannon(new Point(330, 680));

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
                barriers.Add(new Barrier(new Point(90 + 150 * b, 590), 2));
            }

            playerFireCooldown = new System.Timers.Timer(450);
            playerFireCooldown.Elapsed += OnPlayerFireCooldownElapsed;
            playerFireCooldown.AutoReset = false;
            playerFireCooldown.Enabled = false;

            enemyTick = new System.Timers.Timer(1000);
            enemyTick.Interval = 1000 - ((55 - enemies.Count) * 18); // 55 is starting enemy count
            enemyTick.Elapsed += OnEnemyTick;
            enemyTick.AutoReset = true;
            enemyTick.Enabled = true;
        }
        public void Update(PaintEventArgs e) // runs every draw event
        {
            int speed = 5;
            Graphics g = Graphics.FromImage(playArea);
            player.MoveBy(vectToMovePlayerBy[0] * speed, vectToMovePlayerBy[1] * speed, true);
            if (fireButtonHeld)
            {
                PlayerFire();
            }
            player.Refresh(g);


            //Random r = new Random();
            //foreach (var enemy in enemies)
            //{
            //    int rand = r.Next(0, 10000); //TODO redo this abomination
            //    if (rand > 9990)
            //    {
            //        enemyBullets.Add(enemy.Fire(Color.White));
            //    }
            //}

            for (int bullet = 0; bullet < playerBullets.Count(); bullet++) // Update player bullets
            {
                playerBullets[bullet].Refresh(g);
                if (playerBullets[bullet].IsDead) //if it is dead, remove from list
                {
                    playerBullets.RemoveAt(bullet);
                }
                else
                {
                    int collidedBulletIndex = CheckPlayerBullets(bullet, g);
                    if (collidedBulletIndex != -1) // -1 means it didnt collide
                    {
                        bulletHasCollided = true;
                        playerBullets[collidedBulletIndex].ReciveDamage();// damage collided bullet
                    }
                }
            }
            for (int bullet = 0; bullet < enemyBullets.Count(); bullet++) // Update enemy bullets
            {
                enemyBullets[bullet].Refresh(g);
                if (enemyBullets[bullet].IsDead)
                {
                    enemyBullets.RemoveAt(bullet); //if it is dead, remove from list
                }
                else
                {
                    int collidedBulletIndex = CheckEnemyBullets(bullet, g);
                    if (collidedBulletIndex != -1) // -1 means it didnt collide
                    {
                        bulletHasCollided = true;
                        enemyBullets[collidedBulletIndex].ReciveDamage();// damage collided bullet
                    }
                }
            }
            if (bulletHasCollided)
            {
                foreach (var barrier in barriers)
                {
                    barrier.Refresh(g);
                }
                foreach (var enemy in enemies)
                {
                    enemy.Refresh(g);
                }
                bulletHasCollided = false;
            }

            if (enemiesTickHappened)
            {
                {
                    int enemyNrToDelete = -1;
                    do
                    {
                        enemyNrToDelete = -1;
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            if (enemies[i].IsDead)
                            {
                                enemyNrToDelete = i;
                            }
                        }
                        if (enemyNrToDelete != -1)
                        {
                            enemies.RemoveAt(enemyNrToDelete);
                        }
                    } while (enemyNrToDelete != -1);
                }

                enemiesTickHappened = false;
                MoveEnemies(g);
                Random r = new Random();
                int howManyShots = r.Next(-5, enemies.Count / 10 + 1);
                if (howManyShots > 0)
                {
                    for (int i = 0; i < howManyShots; i++)
                    {
                        enemyBullets.Add(enemies[r.Next(0, enemies.Count())].Fire(Color.White));
                    }
                }
            }

            e.Graphics.DrawImage(playArea, 0, 0);

        }
        private int CheckPlayerBullets(int bullet, Graphics g)
        {
            int ifNotHitValue = -1;
            if (playerBullets[bullet].Pos.Y < 70) // check if bullet has left upper bounds
            {
                return bullet;
            }
            for (int enemy = 0; enemy < enemies.Count(); enemy++) // chech if bullet is in one of the enemies
            {
                if (enemies[enemy].IsAt(playerBullets[bullet].Pos.X, playerBullets[bullet].Pos.Y))
                {
                    player1Score += enemies[enemy].PointVal;
                    enemies[enemy].ReciveDamage();
                    enemies[enemy].Refresh(g);
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

        private int CheckEnemyBullets(int bullet, Graphics g)
        {
            int ifNotHitValue = -1;
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
            enemyTick.Interval = 1000 - ((55 - enemies.Count) * 18);
            enemiesTickHappened = true;
        }

        private void MoveEnemies(Graphics g)
        {
            if (enemies.Count != 0)
            {
                int stepSizeX = 10;
                int stepSizeY = 30;
                Entity rightmost = GetRightMostEnemy();
                Entity leftmost = GetLeftMostEnemy();
                int moveByX = 0, moveByY = 0;

                if ((rightmost.Pos.X + rightmost.Graphic.Size.Width > 700 - stepSizeX) && areEnemiesMovingRight ||
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
                    enemie.Refresh(g);
                }
            }
        }
        private Entity GetRightMostEnemy()
        {
            int max = int.MinValue;
            Entity entity = enemies[0];
            foreach (var enemy in enemies)
            {
                if (enemy.Pos.X + enemy.Graphic.Size.Width > max)
                {
                    max = enemy.Pos.X + enemy.Graphic.Size.Width;
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
