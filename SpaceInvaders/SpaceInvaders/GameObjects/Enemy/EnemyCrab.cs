namespace SpaceInvaders.EntityObjects
{
    using SpaceInvaders.BaseGameEntity;
    using System;

    public class EnemyCrab : Enemy
    {
        public EnemyCrab(int x, int y, ConsoleColor color) : base(x, y, color)
        {
            _sprite = new string[3]
            {
                "   ▄█▄█▄  ",
                "  ██▄█▄██ ",
                "   █▄ ▄█  "
            };
        }
    }
}
