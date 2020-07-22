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
            throw new NotImplementedException();
        }
    }
}
