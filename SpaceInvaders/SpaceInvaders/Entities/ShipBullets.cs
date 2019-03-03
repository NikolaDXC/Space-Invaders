using System;
using System.Collections.Generic;

namespace SpaceInvaders.Entities
{
    public class ShipBullets : ConsoleConfiguration
    {
        public const int SPEED = 2;
        public const int UPPER_BOUNDARY = 0;
        private List<ShipBullet> _bullets;
        private int _counter;

        public ShipBullets()
        {
            _bullets = new List<ShipBullet>();
        }
        public void Add(int x) => _bullets.Add(new ShipBullet(x));
        public void Plot()
        {
            SetColor(ConsoleColor.Yellow);
            foreach(var bullet in _bullets)
            {
                bullet.Plot();
            }
        }
        public void Move()
        {
            _counter++;
            if(_counter < SPEED)
            {
                return;
            }
            _counter = 0;
            var bulletsToDelete = new List<ShipBullet>();
            foreach(var bullet in _bullets)
            {
                bullet.Move();
                if(bullet.GetY() == UPPER_BOUNDARY)
                {
                    bulletsToDelete.Add(bullet);
                }
            }
            foreach(var bullet in bulletsToDelete)
            {
                _bullets.Remove(bullet);
            }
        }

    }
}
