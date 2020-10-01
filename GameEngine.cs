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

                    if (map.UnitsOnMap[j].Y < closest.Y)
                        newY = map.UnitsOnMap[j].Y + 1;
                    else if (map.UnitsOnMap[j].Y > closest.Y)
                        newY = map.UnitsOnMap[j].Y - 1;
                    else
                        newY = map.UnitsOnMap[j].Y;
                    map.update(map.UnitsOnMap[j], newX, newY);
                }

                if (map.UnitsOnMap[j].Attack)
                {
                    for (int i = 0; i < map.UnitsOnMap.Count; i++)
                    {
                        if (map.UnitsOnMap[j].Faction != map.UnitsOnMap[1].Faction)
                            map.UnitsOnMap[j].combat(map.UnitsOnMap[i]);

                    }
                }

                if (!map.UnitsOnMap[j].Attack)
                {
                    for (int i = 0; i < map.UnitsOnMap.Count; i++)
                    {
                        if ((map.UnitsOnMap[j].Faction != map.UnitsOnMap[i].Faction) &&
                            map.UnitsOnMap[j].isWithingAttackRange(map.UnitsOnMap[i]))
                            map.UnitsOnMap[j].Attack = true;
                    }
                }

                if (map.UnitsOnMap[j].Health < 25)
                {
                    newX = map.UnitsOnMap[j].X + 1;
                    newY = map.UnitsOnMap[j].Y - 1;
                    map.update(map.UnitsOnMap[j], newX, newY);
                }
            }
        }

        public void pause()
        {

        }
    }
}
