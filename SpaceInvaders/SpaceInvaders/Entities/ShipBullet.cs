namespace SpaceInvaders.Entities
{
    public class ShipBullet : GameObject
    {
        private const int INIT_Y = 36;

        public ShipBullet(int x) : base(new Position(x + 4, INIT_Y))
        {

        }
        public void Plot() => At(_position.PositionX, _position.PositionY, "|");

        public void Unplot() => At(_position.PositionX, _position.PositionY, " ");

        public void Move()
        {
            Unplot();
            _position.PositionY--;
        }
        public int GetY() => _position.PositionY;

    }
}
