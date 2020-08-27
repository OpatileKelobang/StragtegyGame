using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable All

namespace StragtegyGame
{
    class Map
    {
        private const int MAX_RANDOM_UNITS = 50;
        public const string FIELD_SYMBOL = ".";
        private string[,] grid = new string[20,20];
        private List<Unit> unitsOnMap = new List<Unit>();
        private int numberOfUitsOnMap = 0;

        public string[,] Grid
        {
            get
            {
                return grid;
            }
        }

        public List<Unit> UnitsOnMap
        {
            get
            {
                return unitsOnMap;
            }
        }

        public void populate()
        {
            Random rnd = new Random();
            int numberRandomUnits = rnd.Next(0, MAX_RANDOM_UNITS) + 1;
            int x, y, randomAttackRange;
            bool attackOption;
            string team;

            // Clear Field
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    grid[i, j] = FIELD_SYMBOL;
                }
            }

            for (int k = 0; k < numberRandomUnits; k++)
            {
                // Check x, y not occupied by another unit
                do
                {
                    x = rnd.Next(0, 20);
                    y = rnd.Next(0, 20);
                } while (grid[x, y] != FIELD_SYMBOL);
                // Generate randomly either a meleeUnit or rangedUnit and place on map
                if (rnd.Next(1, 3) == 1)
                {
                    attackOption = rnd.Next(0, 2) == 1 ? true : false;
                    team = rnd.Next(0, 2) == 1 ? "Red" : "Green";
                    Unit tmp = new MeleeUnit(x, y, 100, -1, attackOption, 1, team, "M");
                    unitsOnMap.Add(tmp);

                    grid[x, y] = tmp.Symbol;

                    // update arraySize
                    numberOfUitsOnMap++;
                }
                else
                {
                    attackOption = rnd.Next(0, 2) == 1 ? true : false;
                    randomAttackRange = rnd.Next(1, 20);
                    team = rnd.Next(0, 2) == 1 ? "Red" : "Green";
                    Unit tmp = new RangedUnit(x, y, 100, -1, attackOption, randomAttackRange, team, "R");
                    unitsOnMap.Add(tmp);

                    grid[x, y] = unitsOnMap[numberOfUitsOnMap].Symbol;

                    numberOfUitsOnMap++;
                }
            }

        }

        private void moveOnMap(Unit u, int newX, int newY)
        {
            grid[u.X, u.Y] = FIELD_SYMBOL;
            grid[newX, newY] = u.Symbol;
        }

        public void update(Unit u, int newX, int newY)
        {
            if ((newX >= 0 && newY < 20) && (newY >= 0 && newY < 20))
            {
                moveOnMap(u, newX, newY);
                u.move(newX, newY);
            }
        }

        private void checkHealt()
        {
            for (int i = 0; i < numberOfUitsOnMap; i++)
            {
                if (!unitsOnMap[i].isAlive())
                {
                    grid[unitsOnMap[i].X, unitsOnMap[i].Y] = FIELD_SYMBOL;
                    unitsOnMap.RemoveAt(i);
                    numberOfUitsOnMap--;
                }
            }
        }
    }
}
