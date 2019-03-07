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
        public void Plot() => Draw(_position.PositionX, _position.PositionY, _bullet.ToString());
        public void Unplot() => Draw(_position.PositionX, _position.PositionY, " ");
        public void Move()
        {
            Unplot();
            _position.PositionY += _increment;
        }
        public int GetY() => _position.PositionY;

        public Position GetPosition() => _position;
    }
}
