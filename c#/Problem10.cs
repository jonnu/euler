using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem10 : Problem
    {
        public override void process()
        {
            IEnumerable<Int64> allPrimes = sieveOfEratosthenes(2000000);
            Console.WriteLine(allPrimes.Sum());

            Console.ReadKey();
        }

        private List<Int64> sieveOfEratosthenes(Int32 limit)
        {
            BitArray bits = new BitArray(limit, true);

            // Standard 'Sieve of Erathosthenes' implementation
            for (Int32 i = 2; i < Math.Sqrt(limit); i++)
            {
                if (bits[i])
                {
                    for (Int32 j = i * 2; j < limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }

            // Convert BitArray to list of Int64s
            List<Int64> primes = new List<Int64>();
            for (Int32 a = 2; a < bits.Length; a++)
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
