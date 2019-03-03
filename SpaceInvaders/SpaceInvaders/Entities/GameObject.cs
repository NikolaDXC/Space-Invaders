namespace SpaceInvaders.Entities
{
    public class GameObject : ConsoleConfiguration
    {
        protected Position _position;
        protected int _counter;

        public GameObject(Position position)
        {
            _position = position;
            _counter = 0;
        }
    }
}
