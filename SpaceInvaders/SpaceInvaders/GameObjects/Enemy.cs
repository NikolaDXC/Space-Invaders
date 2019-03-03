using SpaceInvaders.Entities;
using System;

namespace SpaceInvaders.GameObjects
{
    public class Enemy : GameObject
    {
        private readonly ConsoleColor _color;
        protected string[] _sprite;
        private const int SPRITE_HEIGHT = 3;
        private const int SPRITE_WIDTH = 5;
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
                    Console.SetCursorPosition(_position.PositionX + j, _position.PositionY + i);
                    Console.Write(_sprite[i][j].ToString());
                }
            }
        }
    }
}
