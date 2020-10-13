using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All

namespace StragtegyGame
{
    class RangedUnit : Unit
    {
        public int DAMAGE = 1;
        public RangedUnit()
        {

        }

        public RangedUnit(int x, int y, int health, int speed, bool attack, int attackRange, String faction, String symbol, string unitName)
            :base(x, y, health, speed, attack, attackRange, faction, symbol, unitName)
        {

        }

        public override void combat(Unit enemy)
        {
            if (this.isWithingAttackRange(enemy))
            {
                enemy.Health -= DAMAGE;
            }
        }

        public override bool isAlive()
        {
            bool result = (this.Health > 0) ? true : false;
            return result;
        }

        public override bool isWithingAttackRange(Unit enemy)
        {
            if (((this.X - enemy.X) <= this.AttackRange) || (Math.Abs(this.X - enemy.X) <= this.AttackRange))
                return true;
            else
                return false;
        }

        public override void move(int x, int y)
        {
            if (x >= 0 && x < 20)
                this.x = x;
            if (y >= 0 && y < 20)
                this.y = y;
        }

        public override Unit nearestUnit(List<Unit> list)
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
                + "Speed : " + Speed + Environment.NewLine
                + "Attack : " + (Attack ? "Yes" : "No") + Environment.NewLine
                + "Attack Range : " + AttackRange + Environment.NewLine
                + "Faction : " + Faction + Environment.NewLine
                + "Symbol : " + Symbol + Environment.NewLine
                + "Unit Name : " + UnitName + Environment.NewLine;
            return output;
        }
    }
}
