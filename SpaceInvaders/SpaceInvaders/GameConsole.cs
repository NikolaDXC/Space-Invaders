namespace SpaceInvaders
{
    using SpaceInvaders.Entities;
    using SpaceInvaders.GameObjects;

    public class GameConsole : ConsoleConfiguration
    {
        private SpaceShip _ship;
        public GameConsole()
        {
            _ship = new SpaceShip();
            Setup();
        }
        public void Run()
        {
            while(true)
            {
                _ship.GameObject();
                _ship.KeyPressed();
                _ship.Move();

            }
        }
    }
}
