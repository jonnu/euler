using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem37 : Problem
    {
        private List<int> primes;

        public override void Process()
        {
            // Generate primes.
            SieveOfEratosthenes(1000000);

            int found = 0, sum = 0;
            for (int i = 0; i < primes.Count() && found < 11; i++)
            {
                // Ignore single-digit primes.
                if (primes[i] <= 7)
                    continue;

                if (IsTruncatablePrime(primes[i])) {
                    sum += primes[i];
                    found++;
                }
            }

            Console.WriteLine("Sum of truncatable primes: {0}", sum);
        }

        private bool IsTruncatablePrime(int value)
        {
            int power = 1;
            for (int i = (int)Math.Log10(value); i > 0; i--)
            {
                power *= 10;

                if (!primes.Contains(value % power) || !primes.Contains(value / power))
                    return false;
            }

            return true;
        }

        private void SieveOfEratosthenes(int limit)
        {
            BitArray bits = new BitArray(limit, true);
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

            primes = new List<int>();
            for (int a = 2; a < bits.Length; a++)
            {
                if (bits[a])
                {
                    primes.Add(a);
                }
            }
        }
    }
}
