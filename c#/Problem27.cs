using System;
using System.Collections.Generic;
using System.Linq;


namespace Euler
{
    class Problem27 : Problem
    {
        private Dictionary<string, int> coefficients = new Dictionary<string, int>() { { "a", 0 }, { "b", 0 } };
        private List<long> primeCache = new List<long>();

        public override void process()
        {
            int maxPrimes = 0;
            for (int a = -999; Math.Abs(a) < 1000; a++)
            {
                for (int b = -999; Math.Abs(b) < 1000; b++)
                {
                    int primes = GetConsecutivePrimes(a, b);
                    if (primes > maxPrimes)
                    {
                        maxPrimes = primes;
                        coefficients["a"] = a;
                        coefficients["b"] = b;
                    }
                    
                }
            }
            Console.WriteLine("a = {0}, b = {1}, Product: {2}", coefficients["a"], coefficients["b"], coefficients["a"] * coefficients["b"]);
        }

        private int GetConsecutivePrimes(int a, int b)
        {
            int n = 0;
            while (IsPrime(SolveQuadratic(a, b, n)))
            {
                n++;
            }

            return n;
        }

        private long SolveQuadratic(int a, int b, int n)
        {
            return (long)Math.Pow(n, 2) + (a * n) + b;
        }

        private bool IsPrime(long n)
        {
            if (n <= 1)
                return false;

            if (primeCache.Contains(n))
                return true;

            for (int i = 2; Math.Pow(i, 2) <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            primeCache.Add(n);
            return true;
        }
    }
}
