using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem31 : Problem
    {
        private int[] coinValues = { 1, 2, 5, 10, 20, 50, 100, 200 };
        
        public override void Process()
        {
            Console.WriteLine("Possible ways to make 2 GBP: {0}", GetCoinPossibilities(200));
        }

        private long GetCoinPossibilities(int limit)
        {
            int[] possibilities = new int[limit + 1];
            possibilities[0] = 1;

            for (int c = 0; c < coinValues.Length; c++)
            {
                for (int d = coinValues[c]; d <= limit; d++)
                {
                    possibilities[d] += possibilities[d - coinValues[c]];
                }
            }

            return possibilities.Last();
        }
    }
}
