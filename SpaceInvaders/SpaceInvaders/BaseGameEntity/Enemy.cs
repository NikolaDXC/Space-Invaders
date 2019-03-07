using SpaceInvaders.BaseEntity;
using SpaceInvaders.Enviroment;
using System;

namespace SpaceInvaders.BaseGameEntity
{
    public class Enemy : GameObject
    {
        private readonly ConsoleColor _color;
        protected string[] _sprite;
        private const int SPRITE_HEIGHT = 3;
        private const int SPRITE_WIDTH = 10;

        public Enemy(int x, int y, ConsoleColor color) : base(new Position(x, y))
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
                    Draw(_position.PositionX + j, _position.PositionY + i, _sprite[i][j].ToString());
                }
            }
        }
        public void Unplot()
        {
            for(int i = 0; i < SPRITE_HEIGHT; i++)
            {
                Draw(_position.PositionX, _position.PositionY + i, "         ");
            }
        }
        public void Move(MoveType move, bool increaseY)
        {
            if(increaseY)
            {
                Draw(_position.PositionX, _position.PositionY, "        ");
                _position.PositionY++;
                return;
            }
            if(move == MoveType.LEFT)
            {
                _position.PositionX--;
            }
            if(move == MoveType.RIGHT)
            {
                _position.PositionX++;
            }
        }
        public int GetX() => _position.PositionX;

        public Position GetPosition() => _position;
    }
}
