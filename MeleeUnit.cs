using System;
using System.Collections.Generic;
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

        public MeleeUnit(int x, int y, int health, int speed, bool attack, int attackRange, string faction, string symbol)
            : base(x, y, health, speed, attack, attackRange, faction, symbol)
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
            throw new NotImplementedException();
        }

        public override void move(int x, int y)
        {

            if (x >= 0 && x < 20)
                X = x;
            if (y >= 0 && y < 20)
                Y = y;
        }

        public override Unit nearestUnit(List<Unit> u)
        {
            throw new NotImplementedException();
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
