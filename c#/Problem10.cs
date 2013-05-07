using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Euler
{
    class Problem10 : Problem
    {
        public override void Process()
        {
            int limit = 2000000;
            List<long> allPrimes = SieveOfEratosthenes(limit);

            Console.WriteLine("Sum of primes below {0}: {1}", limit, allPrimes.Sum());
        }

        private List<long> SieveOfEratosthenes(int limit)
        {
            BitArray bits = new BitArray(limit, true);

            // Standard 'Sieve of Erathosthenes' implementation
            for (int i = 2; i < Math.Sqrt(limit); i++)
            {
                if (bits[i])
                {
                    for (int j = i * 2; j < limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }

            // Convert BitArray to list of Int64s
            List<long> primes = new List<long>();
            for (int a = 2; a < bits.Length; a++)
            {
                if (bits[a])
                {
                    primes.Add(a);
                }
            }

            return primes;
        }
    }
}
