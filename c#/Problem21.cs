using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    class Problem21 : Problem
    {
        public override void process()
        {
            Int32 limit = 10000;

            // Create a dictionary mapping Int32s to the sum of their divisors
            Dictionary<Int32, Int32> divisorDictionary = Enumerable.Range(1, limit - 1)
                .ToDictionary(x => x, x => findDivisors(x).Sum());

            Int32 amicableSum = divisorDictionary
                .Where(pair =>
                    divisorDictionary.ContainsKey(pair.Value) &&                    // d[a] exists, d[a] = b
                    divisorDictionary[pair.Value] == pair.Key &&                    // d[b] = a
                    divisorDictionary[pair.Value] != divisorDictionary[pair.Key]    // a != b
                )
                .Select(x => x.Key)
                .Sum();

            Console.WriteLine("Sum of all amicable numbers below {0} = {1}", limit, amicableSum);
        }

        private IEnumerable<Int32> findDivisors(Int32 value)
        {
            Int32 i = 1;
            Double sqrt = Math.Sqrt(value);
            while (i <= sqrt)
            {
                if (value % i == 0 && i < value)
                {
                    yield return i;

                    if (value == 1)
                        yield break;

                    if (i > 1)
                    {
                        yield return value / i;
                    }
                }

                i++;
            }
        }
    }
}
