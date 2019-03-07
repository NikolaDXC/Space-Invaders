namespace SpaceInvaders.GameObjects.Bullet
{
    using SpaceInvaders.BaseGameEntity;
    using SpaceInvaders.Render;
    using System;
    using System.Collections.Generic;

    public class Bullets : ConsoleRender
    {
        protected List<Bullet> _bullets;
        protected int _boundary;
        protected int _numberOfBullets;
        protected int _maxBullets;
        protected Delay _delay;

        public Bullets()
        {
            _bullets = new List<Bullet>();
            _numberOfBullets = 0;
        }
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
            if(_delay.IsCounting())
            {
                return;
            }
            var bulletsToDelete = new List<Bullet>();
            foreach(var bullet in _bullets)
            {
                bullet.Move();
                if(bullet.GetPosition().Y == _boundary)
                {
                    bulletsToDelete.Add(bullet);
                }
            }
            foreach(var bullet in bulletsToDelete)
            {
                _numberOfBullets--;
                _bullets.Remove(bullet);
            }
        }
        public List<Bullet> GetBullets() => _bullets;
    }
}
