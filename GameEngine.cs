using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All


namespace StragtegyGame
{
    class GameEngine
    {
        public Map map = new Map();

        public GameEngine()
        {
            map.populate();
        }

        public void start()
        {
            int newX, newY;
            Unit closest;

            // update units on map
            map.checkHealth();

            // Combat
            for (int j = 0; j < map.UnitsOnMap.Count; j++)
            {
                // Rules
                if (!map.UnitsOnMap[j].Attack)
                {
                    closest = map.UnitsOnMap[j].nearestUnit(map.UnitsOnMap);
                    if (map.UnitsOnMap[j].X < closest.X)
                        newX = map.UnitsOnMap[j].X + 1;
                    else if (map.UnitsOnMap[j].X > closest.X)
                        newX = map.UnitsOnMap[j].X - 1;
                    else
                        newX = map.UnitsOnMap[j].X;
                }
            }
        }
    }
}
