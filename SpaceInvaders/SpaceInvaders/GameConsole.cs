namespace SpaceInvaders
{
    using SpaceInvaders.BaseEntity;
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Entities;
    using SpaceInvaders.Enviroment;
    using SpaceInvaders.GameObjects.Bullet.Enemy;
    using SpaceInvaders.GameObjects.Enemy;
    using System;
    using System.Collections.Generic;

    public class GameConsole : ConsoleConfiguration
    {
        private Ship _ship;
        private Enemies _enemies;
        private bool _gameover;
        private int _score;
        private int _lives;
        private EnemyBullets _enemyBullets;
        public GameConsole()
        {
            _gameover = false;
            Setup();
            _score = 0;
            _lives = 3;
            _ship = new Ship();
            _enemies = new Enemies();
            _enemyBullets = new EnemyBullets();
            AddHeader();
        }

        public void Run()
        {
            GetReady();
            while(!_gameover)
            {
                Plot();
                _ship.KeyPressed();
                Move();
                EnemyDestroyedCheck();
                if(_enemies.NoEnemies())
                {
                    _enemyBullets.GenerateBullets(_enemies.GetPositions());
                }
                else
                {
                    Complete();
                }
                if(EnemyDestroyShipCheck())
                {
                    ShipDestroyed();
                    _gameover = _lives == 0;
                }
                Digit.PlotScore(_score);
            }
            GameOver();
        }
        private bool EnemyDestroyShipCheck()
        {
            Position position = _ship.GetShipCoordinate();
            bool result = false;
            if(_enemyBullets.HasDestroyedShip(position))
            {
                result = true;
            }
            return result;
        }
        private void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(55, 22);
            Console.WriteLine("G A M E O V E R!");
            Console.SetCursorPosition(0, 44);
        }
        private void Complete()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(55, 22);
            Console.WriteLine("C O M P L E T E");
            Console.SetCursorPosition(0, 44);
        }
        private void ShipDestroyed()
        {
            _ship.Unplot();
            _lives--;

            if(_lives > 0)
            {
                LifeLost();
            }
            else
            {

            }
            Digit.PlotLives(_lives);
        }

        private void Plot()
        {
            _ship.Plot();
            _ship.BulletsPlot();
            _enemies.Plot();
            _enemyBullets.Plot();
        }
        private void Move()
        {
            _enemies.Move();
            _ship.BulletsMove();
            _ship.Move();
            _enemyBullets.Move();
        }

        private void EnemyDestroyedCheck()
        {
            EnemyDestroyed enemyEntity;
            List<Bullet> bullets;
            var bulletsToDelete = new List<Bullet>();

            bullets = _ship.GetBullets();

            if(bullets.Count > 0)
            {
                foreach(var bullet in bullets)
                {
                    enemyEntity = _enemies.IsDestroyed(bullet.GetPosition());

                    if(enemyEntity._isDestroyed)
                    {
                        bulletsToDelete.Add(bullet);
                        _score += 100;
                    }
                }
                _ship.DeleteBullets(bulletsToDelete);
            }
        }
        private void AddHeader()
        {
            SetColor(ConsoleColor.Gray);
            Draw(0, 1, "LIVES: ");
            Draw(50, 1, "SCORE: ");
            //At(105, 1, "LEVEL: ");

            Digit.PlotScore(_score);

            Digit.PlotLives(_lives);

            Console.SetCursorPosition(0, 0);
            SetColor(ConsoleColor.Red);
            for(int i = 0; i < 120; i++)
            {
                Console.Write("*");
            }

            Console.SetCursorPosition(0, 2);

            for(int i = 0; i < 120; i++)
            {
                Console.Write("*");
            }
        }
        private void LifeLost()
        {
            var delay = new Delay(100);
            bool displayLives = true;

            while(delay.IsCounting())
            {
                _enemies.Plot();
                _enemyBullets.Plot();
                _enemyBullets.Move();
                _ship.Init();

                if(displayLives)
                {
                    displayLives = false;
                    Digit.PlotLives(_lives + 1);
                }
                else
                {
                    displayLives = true;
                    Digit.UnplotLives();
                }
            }
            Digit.PlotLives(_lives);
        }
        private void GetReady()
        {
            var delay = new Delay(100);

            while(delay.IsCounting())
            {
                Draw(55, 22, "GET READY");
                System.Threading.Thread.Sleep(15);
            }
            Draw(55, 22, "          ");
        }
    }
}
