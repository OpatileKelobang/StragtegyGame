using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All

namespace StragtegyGame
{
    class ResourceBuilding : Building
    {

        private string resourceType;
        private int resourcesPerGameTick;
        private int resourcesRemaining;

        public ResourceBuilding(int x, int y, int health, string faction, string symbol) 
            : base(x, y, health, faction, symbol)
        {
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

        public void generateResources()
        {

        }
    }
}
