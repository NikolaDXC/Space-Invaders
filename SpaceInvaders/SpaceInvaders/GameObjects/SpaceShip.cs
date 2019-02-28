namespace SpaceInvaders.GameObjects
{
    using SpaceInvaders.Entities;
    using System;

    public class SpaceShip : GameObject
    {
        private const int X = 105;
        private const int Y = 45;
        private MoveType _currentMove;
        private const int LEFTBOUNDARY = 0;
        private const int RIGHTBOUNDARY = 204;

        public SpaceShip() : base(new Position(X, Y))
        {
            SpriteHeight = 5;
            SpriteWidth = 8;

            Sprite = new string[5]{
               @"   /\   ",
                "   ||   ",
               @"  /||\  ",
                " |:||:| ",
               @" |/||\| "
            };
        }

        public void GameObject()
        {
            for(int i = 0; i < SpriteHeight; i++)
            {
                for(int j = 0; j < SpriteWidth; j++)
                {
                    Console.SetCursorPosition(_position.PositionX + j, _position.PositionY + i);
                    Console.Write(Sprite[i][j].ToString());
                }
            }
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
            }
        }
        public void Move()
        {
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
