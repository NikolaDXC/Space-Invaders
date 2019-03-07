namespace SpaceInvaders.GameObjects.Bullet.Enemy
{
    using SpaceInvaders.BaseGameEntity;
    public class EnemyBullet : Bullet
    {
        public EnemyBullet(int x, int y) : base(x, y)
        {
            _bullet = '@';
            _increment = 1;
        }
    }
}
