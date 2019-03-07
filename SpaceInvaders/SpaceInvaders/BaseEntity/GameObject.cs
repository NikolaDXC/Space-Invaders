namespace SpaceInvaders.BaseEntity
{
    using SpaceInvaders.Enviroment;

    public class GameObject : ConsoleConfiguration
    {
        protected Position _position;

        public GameObject(Position position)
        {
            _position = position;
        }
    }
}
