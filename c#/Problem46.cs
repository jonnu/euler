using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem46 : Problem
    {
        private BitArray isPrime;
        private List<int> primes;
        private int[] doubleSquares = new int[100];

        public override void Process()
        {
            WarmCaches();

            int composite = 33;
            while (!SatisfiesGoldbachsConjecture(composite) || isPrime[composite])
            {
                composite += 2;
            }

            Console.WriteLine("Smallest composite that does not satisfy Goldback's other conjecture:\n{0}", composite);
        }

        private bool SatisfiesGoldbachsConjecture(int n)
        {
            for (int i = primes.Count() - 1; i >= 0; i--)
            {
                int prime = primes[i];
                if (prime >= n)
                    continue;

                for (int s = 0; s < doubleSquares.Count(); s++)
                {
                    int compare = prime + doubleSquares[s];
                    if (compare == n) {
                        return false;
                    }

                    if (compare > n) {
                        break;
                    }
                }
            }

            return true;
        }

        private List<int> SieveOfEratosthenes(int limit)
        {
            isPrime = new BitArray(limit, true);
            for (int i = 2; i < Math.Sqrt(limit); i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < limit; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            primes = new List<int>();
            for (int a = 2; a < isPrime.Length; a++)
            {
                if (isPrime[a])
                {
                    primes.Add(a);
                }
            }

            return primes;
        }

        private void WarmCaches()
        {
            // Generate some primes
            SieveOfEratosthenes(100000);

            // Generate some doubled squares
            for (int s = 0; s < doubleSquares.Count(); s++)
            {
                doubleSquares[s] = 2 * (s * s);
            }
        }
    }
}
