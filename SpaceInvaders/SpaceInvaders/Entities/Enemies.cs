using SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Entities
{
    public class Enemies
    {
        private readonly List<Enemy> _enemies;

        public Enemies()
        {
            _enemies = new List<Enemy>();
            AddEnemies();
        }
        public void Plot()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Plot();
            }
        }
        private void AddEnemies()
        {
            int x;

            for(int i = 0; i < 3; i++)
            {
                x = i * 5;
                _enemies.Add(new Enemy1(x, 1, ConsoleColor.Green));
                _enemies.Add(new Enemy1(x, 5, ConsoleColor.Red));
                _enemies.Add(new Enemy1(x, 10, ConsoleColor.Magenta));
            }

        }
    }
}
