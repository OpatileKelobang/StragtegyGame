using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
