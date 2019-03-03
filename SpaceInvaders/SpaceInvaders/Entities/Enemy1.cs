using SpaceInvaders.GameObjects;
using System;

namespace SpaceInvaders.Entities
{
    public class Enemy1 : Enemy
    {
        public Enemy1(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            _sprite = new string[3]
            {
                " ---- ",
                " ____ ",
                " ---- "
            };
        }
    }
}
