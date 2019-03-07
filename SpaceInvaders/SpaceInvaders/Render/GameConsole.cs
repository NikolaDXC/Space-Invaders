namespace SpaceInvaders.Render
{
    using SpaceInvaders.BaseEntity;
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Entities;
    using SpaceInvaders.Enviroment;
    using SpaceInvaders.GameObjects;
    using SpaceInvaders.GameObjects.Bullet.Enemy;
    using SpaceInvaders.GameObjects.Enemy;
    using System.Collections.Generic;

    public class GameConsole : ConsoleRender
    {
        private WindowConfiguration _configuration = new WindowConfiguration();
        private bool _gameover;
        private Ship _ship;
        private Enemies _enemies;
        private int _score;
        private int _lives;
        private EnemyBullets _enemyBullets;

        public GameConsole()
        {
            _configuration.Setup();
            _gameover = false;
            _score = 0;
            _lives = 3;
            AddHeader(_score, _lives);
            _ship = new Ship();
            _enemies = new Enemies();
            _enemyBullets = new EnemyBullets();
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
                EnemiesLeftCheck();
                ShipDestroyedCheck();
                Digit.PlotScore(_score);
            }
            GameOver();
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
            //_enemies.Move();
            _ship.BulletsMove();
            _ship.Move();
            _enemyBullets.Move();
        }

        private void EnemiesLeftCheck()
        {
            if(_enemies.EnemiesLeft())
            {
                _enemyBullets.GenerateBullets(_enemies.GetPositions());
            }
            else
            {
                Complete();
            }
        }

        private void ShipDestroyedCheck()
        {
            if(EnemyDestroyShipCheck())
            {
                ShipDestroyed();
                _gameover = _lives == 0;
            }
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

        private void ShipDestroyed()
        {
            _ship.Unplot();
            _lives--;

            if(_lives > 0)
            {
                LifeLost();
            }
            Digit.PlotLives(_lives);
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

        private void LifeLost()
        {
            var delay = new Delay(50);
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
    }
}
