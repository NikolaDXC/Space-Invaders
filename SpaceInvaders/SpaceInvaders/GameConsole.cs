namespace SpaceInvaders
{
    using SpaceInvaders.Entities;
    using SpaceInvaders.GameObjects;

    public class GameConsole : ConsoleConfiguration
    {
        private SpaceShip _ship;
        private Enemies _enemies;
        private readonly bool _gameover;

        public GameConsole()
        {
            _gameover = false;
            _ship = new SpaceShip();
            _enemies = new Enemies();
            Setup();
        }

        public void Run()
        {
            while(!_gameover)
            {
                Plot();

                _ship.KeyPressed();
                Move();
            }

        }
        private void Plot()
        {
            _ship.GameObject();
            _enemies.Plot();
        }
        private void Move() => _ship.Move();
    }
}
