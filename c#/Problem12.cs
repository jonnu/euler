using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem12 : Problem
    {
        public override void Process()
        {
            int divisors = 0, i = 1, triangle = 0, limit = 500;
            while (divisors < limit)
            {
                triangle = Enumerable.Range(1, i).Sum();
                divisors = FindDivisors(triangle).Count();
                i++;
            }

            Console.WriteLine("First triangle number with more than {0} divisors: {1}", limit, triangle);
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
