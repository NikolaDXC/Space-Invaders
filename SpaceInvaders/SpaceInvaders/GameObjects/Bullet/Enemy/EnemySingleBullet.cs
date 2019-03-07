namespace SpaceInvaders.GameObjects.Bullet.Enemy
{
    using SpaceInvaders.BaseGameEntity;
    public class EnemySingleBullet : Bullet
    {
        public EnemySingleBullet(int x, int y) : base(x, y)
        {
            _bullet = '@';
            _increment = 1;
        }
    }
}
