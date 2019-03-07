namespace SpaceInvaders.GameObjects.Enemy
{
    using SpaceInvaders.BaseEntity;

    public class EnemyDestroyed
    {
        public EnemyDestroyed(Position position, bool isDestroyed)
        {
            _position = position;
            _isDestroyed = isDestroyed;
        }
        private Position _position { get; }

        public bool _isDestroyed { get; }
    }
}
