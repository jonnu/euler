using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem7 : Problem
    {
        public override void Process()
        {
            int limit = 10001;
            long prime = GetNthPrime(limit);

            Console.WriteLine("Prime #{0} = {1}", limit, prime);
        }

        private long GetNthPrime(int nthPrime)
        {
            IList<long> primes = new List<long>(2);
            bool isComposite = false;

            for (long n = 2; primes.Count() < nthPrime; ++n)
            {
                isComposite = false;
                double rootOfN = Math.Sqrt(n);

                foreach (long prime in primes)
                {
                    if (prime > rootOfN)
                    {
                        break;
                    }

                    if (n % prime == 0)
                    {
                        isComposite = true;
                        break;
                    }
                }

                if (!isComposite)
                {
                    primes.Add(n);
                }
            }

            return primes.Last();
        }
    }
}
