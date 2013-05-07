using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem21 : Problem
    {
        public override void Process()
        {
            int limit = 10000;

            // Create a dictionary mapping Int32s to the sum of their divisors
            Dictionary<int, int> divisorDictionary = Enumerable.Range(1, limit - 1)
                .ToDictionary(x => x, x => FindDivisors(x).Sum());

            int amicableSum = divisorDictionary
                .Where(pair =>
                    divisorDictionary.ContainsKey(pair.Value) &&                    // d[a] exists, d[a] = b
                    divisorDictionary[pair.Value] == pair.Key &&                    // d[b] = a
                    divisorDictionary[pair.Value] != divisorDictionary[pair.Key]    // a != b
                )
                .Select(x => x.Key)
                .Sum();

            Console.WriteLine("Sum of all amicable numbers below {0} = {1}", limit, amicableSum);
        }

        private IEnumerable<int> FindDivisors(int value)
        {
            int maximum = (int)Math.Sqrt(value);

            for (int factor = 1; factor <= maximum; factor++)
            {
                if (value % factor != 0)
                    continue;

                yield return factor;

                if (factor == 1)
                    continue;

                if (factor != value / factor)
                    yield return value / factor;
            }
        }
    }
}
