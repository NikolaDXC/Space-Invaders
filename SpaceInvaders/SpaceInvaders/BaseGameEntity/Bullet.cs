using SpaceInvaders.BaseEntity;

namespace SpaceInvaders.BaseGameEntity
{
    public class Bullet : GameObject
    {
        protected char _bullet;
        protected int _increment;

        public Bullet(int x, int y) : base(new Position(x, y))
        {

        }

        public void Plot() => Draw(_position.X, _position.Y, _bullet.ToString());

        public void Unplot() => Draw(_position.X, _position.Y, " ");

        public void Move()
        {
            Unplot();
            _position.Y += _increment;
        }

        public Position GetPosition() => _position;
    }
}
