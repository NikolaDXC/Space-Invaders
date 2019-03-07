namespace SpaceInvaders.BaseGameEntity
{
    using SpaceInvaders.BaseEntity;
    using SpaceInvaders.Enviroment;
    using SpaceInvaders.GameObjects.Bullet.Ship;
    using System;
    using System.Collections.Generic;

    public class Ship : GameObject
    {
        private const int X = 65;
        private const int Y = 41;
        private MoveType _currentMove;
        private const int LEFTBOUNDARY = 0;
        private const int RIGHTBOUNDARY = 110;
        private const int UPBOUNDARY = 3;
        private const int DOWNBOUNDARY = 40;
        private const int MOVE_SPEED = 2;
        private ShipBullets _bullets;
        private readonly string[] _sprite;
        private const int SPRITE_HEIGHT = 3;
        private const int SPRITE_WIDTH = 9;

        public Ship() : base(new Position(X, Y))
        {
            _sprite = new string[3] {
               @"   _|_   ",
               @"  /\_/\  ",
               @" |_/ \_| "
            };
            _bullets = new ShipBullets();
        }

        public void Plot()
        {
            SetColor(ConsoleColor.White);
            for(int i = 0; i < SPRITE_HEIGHT; i++)
            {
                for(int j = 0; j < SPRITE_WIDTH; j++)
                {
                    Draw(_position.PositionX + j, _position.PositionY + i, _sprite[i][j].ToString());
                }
            }

        }
        public void BulletsPlot() => _bullets.Plot();
        public void Init()
        {
            _position.PositionX = X;
            _position.PositionY = Y;
            _currentMove = MoveType.NOMOVE;
        }
        public void Unplot()
        {
            for(int i = 0; i < SPRITE_HEIGHT; i++)
            {
                Draw(_position.PositionX, _position.PositionY + i, "         ");
            }
        }
        public void KeyPressed()
        {
            var info = new ConsoleKeyInfo();
            while(Console.KeyAvailable)
            {
                info = Console.ReadKey();
            }

            switch(info.Key)
            {
                case ConsoleKey.LeftArrow:
                    _currentMove = MoveType.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    _currentMove = MoveType.RIGHT;
                    break;
                //case ConsoleKey.UpArrow:
                //    _currentMove = MoveType.UP;
                //    break;
                //case ConsoleKey.DownArrow:
                //    _currentMove = MoveType.DOWN;
                //    break;
                case ConsoleKey.Spacebar:
                    _bullets.Add(_position.PositionX, _position.PositionY);
                    break;
                default:
                    _currentMove = MoveType.NOMOVE;
                    break;
            }
        }
        public void Move()
        {
            if(_currentMove == MoveType.LEFT && _position.PositionX > LEFTBOUNDARY)
            {
                _position.PositionX--;
            }
            if(_currentMove == MoveType.RIGHT && _position.PositionX < RIGHTBOUNDARY)
            {
                _position.PositionX++;
            }
            //if(_currentMove == MoveType.UP && _position.PositionY > UPBOUNDARY)
            //{
            //    _position.PositionY--;
            //}
            //if(_currentMove == MoveType.DOWN && _position.PositionY < DOWNBOUNDARY)
            //{
            //    _position.PositionY++;
            //}
        }
        public void BulletsMove() => _bullets.Move();

        public Position GetShipCoordinate() => _position;

        public List<Bullet> GetBullets() => _bullets.GetBullets();

        public void DeleteBullets(List<Bullet> bullet) => _bullets.DeleteBullets(bullet);
    }
}
