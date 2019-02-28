namespace SpaceInvaders.Entities
{
    public class GameObject
    {
        protected Position _position;
        protected int _counter;

        public GameObject(Position position)
        {
            _position = position;
            _counter = 0;
        }
        public bool IsDead { get; set; }

        public int SpriteHeight { get; set; }

        public int SpriteWidth { get; set; }

        public string[] Sprite { get; set; }
    }
}
