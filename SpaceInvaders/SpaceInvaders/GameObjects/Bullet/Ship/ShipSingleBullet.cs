namespace SpaceInvaders.GameObjects.Bullet.Ship
{
    using SpaceInvaders.BaseGameEntity;
    public class ShipSingleBullet : Bullet
    {
        public ShipSingleBullet(int x, int y) : base(x + 4, y)
        {
            _bullet = '|';
            _increment = -1;
        }
    }
}
