using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem47 : Problem
    {
        private List<int> primes;
        private BitArray isPrime;

        public override void Process()
        {
            int n = 0;
            SieveOfEratosthenes(150000);

            int combo = 0;
            int[] chain = new int[4];

            while (combo < 4)
            {
                n++;

                if (DistinctPrimeFactors(n) != 4)
                {
                    combo = 0;
                    chain = new int[4];
                    continue;
                }

                chain[combo] = n;
                combo++;
            }

            Console.WriteLine("Consecutive integers with 4 distinct prime factors:");
            for (int c = 0; c < 4; c++)
            {
                Console.ForegroundColor = c == 0 ? ConsoleColor.White : ConsoleColor.Gray;
                Console.Write("{0}{1}", chain[c], c == 3 ? Environment.NewLine : ", ");
            }

        }

        private int DistinctPrimeFactors(int integer)
        {
            int[] distinct = new int[4];
            int factors = 0, value = integer;

            while (factors < 4)
            {
                int factor = GetLowestPrimeFactor(value);
                if (factor == 0)
                    break;

                if (!distinct.Contains(factor))
                {
                    distinct[factors] = factor;
                    factors++;
                }

                value /= factor;
            }

            return factors;
        }

        private int GetLowestPrimeFactor(int integer)
        {
            for (int i = 0; i < primes.Count() && primes[i] <= integer; i++)
            {
                if (integer % primes[i] == 0)
                {
                    return primes[i];
                }
            }

            return 0;
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
    }
}
