using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StragtegyGame
{
    class Unit
    {
        protected int x, y, health, speed, attackRange;
        protected String faction, symbol;
        protected bool attack;

        public Unit()
        {

        }

        public Unit(int x, int y, int health, int speed, bool attack, int attackRange, String faction, String symbol)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = faction;
            this.symbol = symbol;
        }
    }
}
