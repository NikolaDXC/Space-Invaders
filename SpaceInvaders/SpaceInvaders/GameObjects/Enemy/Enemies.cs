using SpaceInvaders.BaseEntity;
using SpaceInvaders.BaseGameEntity;
using SpaceInvaders.EntityObjects;
using SpaceInvaders.Enviroment;
using SpaceInvaders.GameObjects.Enemy;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Entities
{
    public class Enemies
    {
        private readonly List<Enemy> _enemies;
        private const int LEFT_BOUNDARY = 0;
        private const int RIGHT_BOUNDARY = 110;
        private Delay _moveTimer;
        private MoveType _move;
        private const int SPEED = 3;

        public Enemies()
        {
            _enemies = new List<Enemy>();
            _moveTimer = new Delay(SPEED);
            _move = MoveType.RIGHT;
            AddEnemies();
        }
        public void Plot()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Plot();
            }
        }
        public bool NoEnemies()
        {
            bool result = false;
            while(_enemies.Count != 0)
            {
                return true;
            }
            return result;
        }

        public EnemyDestroyed IsDestroyed(Position position)
        {
            Position pos = null;
            Enemy tmp = null;
            bool isDestroyed = false;

            foreach(var enemy in _enemies)
            {
                pos = enemy.GetPosition();

                if(position.PositionX >= pos.PositionX + 2
                    && position.PositionX < pos.PositionX + 8
                    && position.PositionY >= pos.PositionY
                    && position.PositionY < pos.PositionY + 2)
                {
                    enemy.Unplot();
                    tmp = enemy;
                    isDestroyed = true;
                    break;
                }
            }
            if(tmp != null)
            {
                _enemies.Remove(tmp);
            }
            return new EnemyDestroyed(pos, isDestroyed);
        }

        private void AddEnemies()
        {
            int x;

            for(int i = 0; i < 8; i++)
            {
                x = i * 10;
                _enemies.Add(new EnemyCrab(x, 3, ConsoleColor.Green));
                _enemies.Add(new EnemyCrab(x, 7, ConsoleColor.Yellow));
                _enemies.Add(new EnemyCrab(x, 11, ConsoleColor.Red));
                _enemies.Add(new EnemyCrab(x, 15, ConsoleColor.Blue));
                _enemies.Add(new EnemyCrab(x, 19, ConsoleColor.White));
                _enemies.Add(new EnemyCrab(x, 19, ConsoleColor.Cyan));
            }
        }
        public List<Position> GetPositions()
        {
            var result = new List<Position>();
            foreach(var enemy in _enemies)
            {
                result.Add(enemy.GetPosition());
            }
            return result;
        }
        public void Move()
        {
            int minX = 1;
            int maxX = 0;
            int x;
            bool increaseY = false;

            if(_moveTimer.IsCounting())
            {
                return;
            }

            foreach(var enemy in _enemies)
            {
                x = enemy.GetX();

                if(_move == MoveType.LEFT && x < minX)
                {
                    minX = x;
                }
                if(_move == MoveType.RIGHT && x > maxX)
                {
                    maxX = x;
                }
            }
            if(_move == MoveType.LEFT && minX == LEFT_BOUNDARY)
            {
                _move = MoveType.RIGHT;
                increaseY = true;
            }
            if(_move == MoveType.RIGHT && maxX == RIGHT_BOUNDARY)
            {
                _move = MoveType.LEFT;
                increaseY = true;
            }
            foreach(var enemy in _enemies)
            {
                enemy.Move(_move, increaseY);
            }
        }
    }
}
