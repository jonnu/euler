using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem15 : Problem
    {
        private Int32 gridSize;
        private Dictionary<String, Int64> cache;

        public override void process()
        {
            gridSize = 20;
            cache = new Dictionary<String, Int64>();

            Console.WriteLine("Number of paths in {0}x{0} grid: {1}", gridSize, getNumberOfPaths());
        }

        private Int32 getBlockSize(Int32 x, Int32 y)
        {
            return (gridSize - x) * (gridSize - y);
        }

        private String getBlockString(Int32 x, Int32 y)
        {
            return (gridSize - x) + "x" + (gridSize - y);
        }

        private Int64 getNumberOfPaths(Int32 x = 0, Int32 y = 0)
        {
            if (getBlockSize(x, y) == 0)
                return 1;
            
            Int64 p = 0;
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
