using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StragtegyGame
{
    class RangedUnit : Unit
    {
        public int DAMAGE = 2;
        public RangedUnit()
        {

        }

        public RangedUnit(int x, int y, int health, int speed, bool attack, int attackRange, String faction, String symbol)
        {

        }

        public override void combat(Unit enemy)
        {
            throw new NotImplementedException();
        }

        public override bool isAlive()
        {
            throw new NotImplementedException();
        }

        public override bool isWithingAttackRange(Unit enemy)
        {
            throw new NotImplementedException();
        }

        public override void move(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Unit nearestUnit(List<Unit> u)
        {
            throw new NotImplementedException();
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
                + "Symbol : " + Symbol + Environment.NewLine;
            return output;
        }
    }
}
