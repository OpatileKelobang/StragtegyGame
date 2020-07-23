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

            /*if (x >= 0 && x < 20)
                X = x;
            if (y >= 0 && y < 20)
                Y = y;*/
            X = x;
            Y = y;
            Console.WriteLine("x is " + x);
            Console.WriteLine("y is " + y);
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
                + "Attack : " + Attack + Environment.NewLine
                + "Attack Range : " + AttackRange + Environment.NewLine
                + "Faction : " + Faction + Environment.NewLine
                + "Symbol : " + Symbol + Environment.NewLine;
            return output;
        }
    }
}
