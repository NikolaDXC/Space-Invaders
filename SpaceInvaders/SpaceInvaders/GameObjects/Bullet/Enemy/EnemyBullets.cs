namespace SpaceInvaders.GameObjects.Bullet.Enemy
{
    using SpaceInvaders.BaseEntity;
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Render;
    using System;
    using System.Collections.Generic;

    public class EnemyBullets : Bullets
    {
        private const int LOWER_BOUNDARY = 45;
        private const int SPEED = 3;

        public EnemyBullets()
        {
            _delay = new Delay(SPEED);
            _maxBullets = 5;
            _boundary = LOWER_BOUNDARY;
        }

        public void GenerateBullets(List<Position> position)
        {
            if(_bullets.Count >= _maxBullets)
            {
                return;
            }
            var random = new Random();
            int index = random.Next(0, position.Count);
            int x = position[index].X + 5;
            int y = position[index].Y + 3;

            _bullets.Add(new EnemySingleBullet(x, y));
        }
        public bool HasDestroyedShip(Position shipPosition)
        {
            bool result = false;
            Position position;
            var bulletsToDelete = new List<Bullet>();

            foreach(var bullet in _bullets)
            {
                position = bullet.GetPosition();

                if((position.X > shipPosition.X + 3
                && position.X < shipPosition.X + 6
                && position.Y == shipPosition.Y)
                ||
                  (position.X > shipPosition.X + 2
                && position.X < shipPosition.X + 7
                && position.Y == shipPosition.Y + 1)
                ||
                  (position.X > shipPosition.X
                && position.X < shipPosition.X + 8
                && position.Y == shipPosition.Y + 2))
                {
                    bulletsToDelete.Add(bullet);
                    bullet.Unplot();
                    result = true;
                }
            }
            return result;
        }

        public void DeleteBullets(List<Bullet> bullets)
        {
            foreach(var bullet in bullets)
            {
                _bullets.Remove(bullet);
            }
        }
    }
}
