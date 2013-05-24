using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class PrimeGenerator
    {
        private BitArray primeCache;
        private List<int> primes;

        public PrimeGenerator() { }

        public bool IsPrime(int value)
        {
            return primeCache[value];
        }

        public List<int> Below(int limit)
        {
            return SieveOfEratosthenes(limit);
        }

        public List<int> Between(int lower, int upper)
        {
            return SieveOfEratosthenes(upper, x => lower <= x);
        }

        private List<int> SieveOfEratosthenes(int limit, Func<int, bool> filterFunction = null)
        {
            primeCache = new BitArray(limit + 1, true);
            for (int i = 2; i < Math.Sqrt(limit); i++)
            {
                if (primeCache[i])
                {
                    for (int j = i * 2; j < limit; j += i)
                    {
                        primeCache[j] = false;
                    }
                }
            }

            primes = new List<int>();
            for (int a = 2; a < limit; a++)
            {
                if (primeCache[a] && (filterFunction == null || filterFunction(a)))
                {
                    primes.Add(a);
                }
            }

            return primes;
        }
    }
}
