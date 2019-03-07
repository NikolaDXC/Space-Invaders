namespace SpaceInvaders.GameObjects.Bullet.Enemy
{
    using SpaceInvaders.BaseEntity;
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Enviroment;
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
            int x = position[index].PositionX + 5;
            int y = position[index].PositionY + 3;

            _bullets.Add(new EnemyBullet(x, y));
        }
        public bool HasDestroyedShip(Position shipPosition)
        {
            bool result = false;
            Position position;
            var bulletsToDelete = new List<Bullet>();

            foreach(var bullet in _bullets)
            {
                position = bullet.GetPosition();

                if((position.PositionX > shipPosition.PositionX + 3
                && position.PositionX < shipPosition.PositionX + 6
                && position.PositionY == shipPosition.PositionY)
                ||
                  (position.PositionX > shipPosition.PositionX + 2
                && position.PositionX < shipPosition.PositionX + 7
                && position.PositionY == shipPosition.PositionY + 1)
                ||
                  (position.PositionX > shipPosition.PositionX + 1
                && position.PositionX < shipPosition.PositionX + 8
                && position.PositionY == shipPosition.PositionY + 2))
                {
                    bulletsToDelete.Add(bullet);
                    bullet.Unplot();
                    result = true;
                }
            }

            foreach(var bullet in bulletsToDelete)
            {
                _bullets.Remove(bullet);
            }
            return result;
        }
    }
}
