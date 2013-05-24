using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem50 : Problem
    {
        public override void Process()
        {
            PrimeGenerator primeGenerator = new PrimeGenerator();
            int upperLimit = 1000000, chainLength = 0, maxPrime = 0;

            List<int> primes = primeGenerator.Below(upperLimit);
            long[] consecutiveSum = GenerateConsecutiveSum(primes);

            for (int j = chainLength; j < consecutiveSum.Count(); j++)
            {
                for (int k = j - (chainLength + 1); k >= 0; k--)
                {
                    int checkPrime = (int)(consecutiveSum[j] - consecutiveSum[k]);
                    if (checkPrime > upperLimit)
                        break;

                    if (!primeGenerator.IsPrime(checkPrime))
                        continue;

                    chainLength = j - k;
                    maxPrime = checkPrime;
                }
            }

            Console.WriteLine("Prime: {0} made from a chain of {1} consecutive primes", maxPrime, chainLength);
        }

        private long[] GenerateConsecutiveSum(List<int> values)
        {
            long[] sum = new long[values.Count() + 1];
            for (int i = 0, j = 1; i < values.Count(); i++, j++)
            {
                sum[j] = values[i] + sum[i];
            }

            return sum;
        }
    }
}
