using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StragtegyGame
{
    class FactoryBuilding : Building
    {

        public int DAMAGE = 1;

        private int unitsToProduce;
        private int gameTicksPerProduction;
        private int spawnPoint;

        public FactoryBuilding(int x, int y, int health, string faction, string symbol) 
            : base(x, y, health, faction, symbol)
        {
        }

        public bool isAlive()
        {
            bool result = (this.Health > 0) ? true : false;
            return result;
        }

        public Unit nearestUnit(List<Unit> list)
        {
            Unit closest = null;
            int attackRangeX, attackRangeY;
            int shortestRange = 1000;

            foreach (Unit u in list)
            {
                attackRangeX = this.X - u.X;
                attackRangeY = this.Y - u.Y;

                if (attackRangeX < shortestRange)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }

                if (attackRangeY < shortestRange)
                {
                    shortestRange = attackRangeX;
                    closest = u;
                }
            }

            return closest;
        }

        public override string toString()
        {
            string output = "X : " + X + Environment.NewLine
                            + "Y : " + Y + Environment.NewLine
                            + "Health : " + Health + Environment.NewLine
                            + "Faction : " + Faction + Environment.NewLine
                            + "Symbol : " + Symbol + Environment.NewLine;
            return output;
        }

        public override void unitDestruction()
        {
            throw new NotImplementedException();
        }

        public void spawnNewUnits()
        {

        }

    }
}
