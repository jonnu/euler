using System;
using System.Collections.Generic;

namespace Euler
{
    class Problem15 : Problem
    {
        private int gridSize;
        private Dictionary<string, long> cache;

        public override void Process()
        {
            gridSize = 20;
            cache = new Dictionary<string, long>();

            Console.WriteLine("Number of paths in {0}x{0} grid: {1}", gridSize, getNumberOfPaths());
        }

        private int getBlockSize(int x, int y)
        {
            return (gridSize - x) * (gridSize - y);
        }

        private string getBlockString(int x, int y)
        {
            return (gridSize - x) + "x" + (gridSize - y);
        }

        private long getNumberOfPaths(int x = 0, int y = 0)
        {
            if (getBlockSize(x, y) == 0)
                return 1;
            
            long p = 0;
            string block = getBlockString(x, y);

            if (!cache.ContainsKey(block))
            {
                if (x < gridSize) {
                    p += getNumberOfPaths(x + 1, y);
                }

                if (y < gridSize) {
                    p += getNumberOfPaths(x, y + 1);
                }

                // Cache result
                cache[block] = p;
            }

            return cache[block];
        }
    }
}
