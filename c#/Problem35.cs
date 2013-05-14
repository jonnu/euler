using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem35 : Problem
    {
        private List<long> primes = new List<long>();
        private char[] nonPrimers = new char[] { '2', '4', '5', '6', '8' };

        public override void Process()
        {
            int limit = 1000000;
            Console.WriteLine("Number of Circular Primes below {0} = {1}", limit, SieveOfEratosthenes(limit).Where(prime => IsCircular(prime)).Count());
        }

        private bool IsCircular(long prime)
        {
            // Single digits cannot be rotated
            if (prime > 0 && prime < 10)
                return true;

            // Primes must contain only digits 1, 3, 7, 9
            if (nonPrimers.Any(prime.ToString().Contains))
                return false;

            // Rotate all digits, hunting for non-primes
            foreach (long primeToCheck in RotateDigits(prime))
            {
                if (!primes.Contains(primeToCheck))
                    return false;
            }

            return true;
        }

        private IEnumerable<long> RotateDigits(long number)
        {
            string numeric = number.ToString();
            for (int i = 1; i < numeric.Length; i++)
            {
                yield return Int64.Parse(numeric.Substring(i, numeric.Length - i) + numeric.Substring(0, i));
            }
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
