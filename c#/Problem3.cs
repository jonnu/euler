using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem3 : Problem
    {
        public override void Process()
        {
            long limit = 600851475143;
            long largestPrimeFactor = GetPrimeFactors(limit).Last();

            Console.WriteLine("Largest factor of {0}: {1}", limit, largestPrimeFactor);
        }

        private IEnumerable<Int64> GetPrimeFactors(long upperLimit)
        {
            for (int div = 2; upperLimit > 1;)
            {
                while (upperLimit % div == 0)
                {
                    yield return div;
                    upperLimit /= div;
                }

                div++;
                if (Math.Pow(div, 2) > upperLimit && upperLimit > 1)
                {
                    yield return upperLimit;
                    break;
                }
            }
        }
    }
}
