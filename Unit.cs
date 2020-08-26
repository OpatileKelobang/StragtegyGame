using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable All

namespace StragtegyGame
{
    abstract class Unit
    {
        protected int x;
        protected int y;
        protected int health;
        protected int speed;
        protected bool attack;
        protected int attackRange;
        protected string faction;
        protected string symbol;

        #region Constroctor and Deconstructor
        public Unit()
        {

        }

        public Unit(int x, int y, int health, int speed, bool attack, int attackRange, string faction, string symbol)
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

        #endregion Constroctor and Deconstructor

        #region Accessors
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public bool Attack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
            }
        }

        public int AttackRange
        {
            get
            {
                return attackRange;
            }
            set
            {
                attackRange = value;
            }
        }

        public string Faction
        {
            get
            {
                return faction;
            }
            set
            {
                faction = value;
            }
        }

        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }
        #endregion Accessors

        #region Methods
        public abstract void move(int x, int y);
        public abstract void combat(Unit enemy);
        public abstract bool isWithingAttackRange(Unit enemy);
        public abstract Unit nearestUnit(List<Unit> u);
        public abstract bool isAlive();
        public abstract string toString();
        #endregion Methods
    }
}
