using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StragtegyGame
{
    abstract class Building
    {
        private int x;
        private int y;
        private int health;
        private string faction;
        private string symbol;

        public Building(int x, int y, int health, string faction, string symbol)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.faction = faction;
            this.symbol = symbol;
        }

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

        public abstract string toString();

        public abstract void unitDestruction();

    }
}
