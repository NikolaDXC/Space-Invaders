namespace SpaceInvaders.GameObjects.Bullet.Ship
{
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Render;
    using System.Collections.Generic;

    public class ShipBullets : Bullets
    {
        private const int UPPER_BOUNDARY = 2;
        private const int SPEED = 2;

        public ShipBullets()
        {
            _boundary = UPPER_BOUNDARY;
            _maxBullets = 5;
            _delay = new Delay(SPEED);
        }
        public void Add(int x, int y)
        {
            if(_bullets.Count >= _maxBullets)
            {
                return;
            }
            _bullets.Add(new ShipSingleBullet(x, y));
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
