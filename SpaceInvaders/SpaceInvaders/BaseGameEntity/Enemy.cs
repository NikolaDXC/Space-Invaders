namespace SpaceInvaders.BaseGameEntity
{
    using SpaceInvaders.BaseEntity;
    using SpaceInvaders.GameObjects;
    using System;

    public class Enemy : GameObject
    {
        private readonly ConsoleColor _color;
        protected string[] _sprite;
        private const int SPRITE_HEIGHT = 3;
        private const int SPRITE_WIDTH = 10;

        public Enemy(int x, int y, ConsoleColor color) : base(new Position(x + 30, y))
        {
            _color = color;
        }

        public void Plot()
        {
            SetColor(_color);
            for(int i = 0; i < SPRITE_HEIGHT; i++)
            {
                for(int j = 0; j < SPRITE_WIDTH; j++)
                {
                    Draw(_position.X + j, _position.Y + i, _sprite[i][j].ToString());
                }
            }
        }

        public void Unplot()
        {
            for(int i = 0; i < SPRITE_HEIGHT; i++)
            {
                Draw(_position.X, _position.Y + i, "          ");
            }
        }

        public void Move(MoveType move, bool increaseY)
        {
            if(increaseY)
            {
                Draw(_position.X, _position.Y, "        ");
                _position.Y++;
                return;
            }
            if(move == MoveType.LEFT)
            {
                _position.X--;
            }
            if(move == MoveType.RIGHT)
            {
                _position.X++;
            }
        }

        public Position GetPosition() => _position;
    }
}
