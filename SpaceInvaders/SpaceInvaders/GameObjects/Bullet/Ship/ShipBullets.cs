namespace SpaceInvaders.GameObjects.Bullet.Ship
{
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Enviroment;
    using System.Collections.Generic;

    public class ShipBullets : Bullets
    {
        private const int UPPER_BOUNDARY = 2;
        private const int SPEED = 1;
        public ShipBullets()
        {
            _boundary = UPPER_BOUNDARY;
            _delay = new Delay(SPEED);
        }
        public void Add(int x, int y) => _bullets.Add(new ShipBullet(x, y));

        public void DeleteBullets(List<Bullet> bullets)
        {
            foreach(var bullet in bullets)
            {
                _bullets.Remove(bullet);
            }
        }

    }
}
