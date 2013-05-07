using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem23 : Problem
    {
        private List<int> abundantNumbers;
        private bool[] isSumOfTwoAbundants;

        public override void Process()
        {
            int limit = 28123;
            
            // Create a list of 'abundant' numbers
            abundantNumbers = Enumerable.Range(1, limit)
                .Where(x => x < FindDivisors(x).Sum())
                .ToList();

            // Flag all sums of two numbers less than the limit
            isSumOfTwoAbundants = new bool[limit + 1];
            for (int i = 0; i < abundantNumbers.Count; i++)
            {
                for (int j = 0; j < abundantNumbers.Count; j++)
                {
                    int abundantSum = abundantNumbers[i] + abundantNumbers[j];

                    if (abundantSum > limit)
                        break;

                    isSumOfTwoAbundants[abundantSum] = true;
                }
            }

            // Sum all integers that cannot be written as a sum of two abundants
            int nonAbundantSum = Enumerable.Range(1, limit)
                .Where(x => !isSumOfTwoAbundants[x]).Sum();

            Console.WriteLine("Sum of integers that are not a sum of abundants: {0}", nonAbundantSum);
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
