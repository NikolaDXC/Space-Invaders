namespace SpaceInvaders.BaseEntity
{
    using SpaceInvaders.Render;

    public class GameObject : ConsoleRender
    {
        protected Position _position;

        public GameObject(Position position)
        {
            _position = position;
        }
    }
}
