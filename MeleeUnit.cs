using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All

namespace StragtegyGame
{
    class MeleeUnit : Unit
    {
        public const int DAMAGE = 2;

        public MeleeUnit()
        {

        }

        public MeleeUnit(int x, int y, int health, int speed, bool attack, int attackRange, string faction, string symbol, string unitName)
            : base(x, y, health, speed, attack, attackRange, faction, symbol, unitName)
        {

        }

        public override void combat(Unit enemy)
        {
            // If Enemy is within AttackRange decrease Health by Damage (2)
            if (this.isWithingAttackRange(enemy))
            {
                enemy.Health -= DAMAGE;
            }
        }

        public override bool isAlive()
        {
            // If Health is greater than zero, then true, else false (equal to result)
            bool result = (this.Health > 0)? true : false;
            return result;
        }

        public override bool isWithingAttackRange(Unit enemy)
        {
            // Check if enemy X and Y position is within attach range (return true or false)
            if (((this.X - enemy.X) <= this.AttackRange) || (Math.Abs(this.Y - enemy.Y) <= this.AttackRange))
                return true;
            else
                return false;
        }

        public override void move(int x, int y)
        {

            if (x >= 0 && x < 20)
                X = x;
            if (y >= 0 && y < 20)
                Y = y;
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
                    shortestRange = attackRangeY;
                    closest = u;
                }
            }

            return closest;
        }

        public override string toString()
        {
            string output = "X : " + x + Environment.NewLine
                + "Y : " + Y + Environment.NewLine
                + "Health : " + health + Environment.NewLine
                + "Speed : " + speed + Environment.NewLine
                + "Attack : " + (attack ? "Yes" : "No") + Environment.NewLine
                + "Attack Range : " + attackRange + Environment.NewLine
                + "Faction : " + faction + Environment.NewLine
                + "Symbol : " + symbol + Environment.NewLine;
            return output;
        }
    }
}
