namespace SpaceInvaders.GameObjects
{
    using SpaceInvaders.Entities;
    using System;

    public class SpaceShip : GameObject
    {
        private const int X = 60;
        private const int Y = 36;
        private MoveType _currentMove;
        private const int LEFTBOUNDARY = 0;
        private const int RIGHTBOUNDARY = 111;
        private ShipBullets _bullets;
        private readonly string[] _sprite;
        private const int SPRITE_HEIGHT = 3;
        private const int SPRITE_WIDTH = 9;

        public SpaceShip() : base(new Position(X, Y))
        {
            _sprite = new string[3] {
               @"   _|_   ",
               @"  /|_|\  ",
               @" |_/ \_| "
            };
            _bullets = new ShipBullets();
        }

        public void GameObject()
        {
            SetColor(ConsoleColor.White);
            for(int i = 0; i < SPRITE_HEIGHT; i++)
            {
                for(int j = 0; j < SPRITE_WIDTH; j++)
                {
                    At(_position.PositionX + j, _position.PositionY + i, _sprite[i][j].ToString());
                }
            }
            _bullets.Plot();
        }

        public void KeyPressed()
        {
            var info = new ConsoleKeyInfo();

            while(Console.KeyAvailable)
            {
                info = Console.ReadKey(true);
            }

            switch(info.Key)
            {
                case ConsoleKey.LeftArrow:
                    _currentMove = MoveType.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    _currentMove = MoveType.RIGHT;
                    break;
                case ConsoleKey.X:
                    _currentMove = MoveType.NOMOVE;
                    break;
                case ConsoleKey.Spacebar:
                    _bullets.Add(_position.PositionX);
                    break;
                default:
                    break;
            }
        }
        public void Move()
        {
            _bullets.Move();
            _counter++;
            if(_counter < 2)
            {
                return;
            }
            _counter = 0;
            if(_currentMove == MoveType.LEFT && _position.PositionX > LEFTBOUNDARY)
            {
                _position.PositionX--;
                _currentMove = MoveType.NOMOVE;
            }
            if(_currentMove == MoveType.RIGHT && _position.PositionX < RIGHTBOUNDARY)
            {
                _position.PositionX++;
                _currentMove = MoveType.NOMOVE;
            }
        }
    }
}
