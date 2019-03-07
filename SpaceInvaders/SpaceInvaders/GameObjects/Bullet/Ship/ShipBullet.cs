namespace SpaceInvaders.GameObjects.Bullet.Ship
{
    using SpaceInvaders.BaseGameEntity;
    public class ShipBullet : Bullet
    {
        public ShipBullet(int x, int y) : base(x + 4, y + 2)
        {
            _bullet = '|';
            _increment = -1;
        }

    }
}
