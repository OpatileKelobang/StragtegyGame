using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StragtegyGame
{
    class Unit
    {
        protected int attackRange;
        protected String symbol;
        protected bool attack;
        protected int x;
        protected int y;
        protected int health;
        protected int speed;
        protected String faction;

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

        ~Unit()
        {

        }

        public int getX(int x)
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public int getHealth()
        {
            return this.health;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public bool getAttack()
        {
            return this.attack;
        }

        public int getAttackRange()
        {
            return this.attackRange;
        }

        public string getFaction()
        {
            return this.faction;
        }

        public string getSymbol()
        {
            return this.symbol;
        }

        private void setX(int x)
        {

        }

        private void setY(int y)
        {

        }
    }
}
