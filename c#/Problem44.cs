using System;
using System.Collections;
using System.Linq;

namespace Euler
{
    class Problem44 : Problem
    {
        private BitArray pentagonals;

        public override void Process()
        {
            int limit = 2500;
            int[] pentagons = GeneratePentagonalNumbers(limit);

            int smallestPentagon = (
                from x in pentagons
                from y in pentagons
                where y > x && pentagonals[y + x] && pentagonals[y - x]
                select y - x
            ).Min();

            Console.WriteLine("Smallest difference between two Pentagon numbers: {0}", smallestPentagon);
        }

        private int[] GeneratePentagonalNumbers(int limit)
        {
            int pent = 1, step = 4, n = 0;
            int[] pentagons = new int[limit];

            while (n < limit)
            {
                pentagons[n] = pent;
                pent += step;
                step += 3;
                n++;
            }

            // Cache pentagonals in a BitArray
            pentagonals = new BitArray(2 * pent, false);
            foreach (int p in pentagons)
            {
                pentagonals[p] = true;
            }
            
            return pentagons;
        }
    }
}