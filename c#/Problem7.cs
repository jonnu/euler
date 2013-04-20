using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem7 : Problem
    {
        public override void process()
        {
            Int64 prime = getNthPrime(10001);

            Console.WriteLine(prime);
            Console.ReadKey();
        }

        private Int64 getNthPrime(Int32 nthPrime)
        {
            IList<Int64> primes = new List<Int64>(2);
            bool isComposite = false;

            for (Int64 n = 2; primes.Count() < nthPrime; ++n)
            {
                isComposite = false;
                Double rootOfN = Math.Sqrt(n);

                foreach (Int64 prime in primes)
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
