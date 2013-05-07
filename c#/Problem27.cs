using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem27 : Problem
    {
        private int coefficient_a = 0;
        private int coefficient_b = 0;
        private int maximumPrimes = 0;

        public override void Process()
        {
            for (int b = -999; Math.Abs(b) < 1000; b++)
            {
                // b *must* be prime if n = 0
                if (!IsPrime(b))
                    continue;

                for (int a = -999; Math.Abs(a) < 1000; a++)
                {
                    int primes = GetConsecutivePrimes(a, b);
                    if (primes > maximumPrimes)
                    {
                        maximumPrimes = primes;
                        coefficient_a = a;
                        coefficient_b = b;
                    }
                }
            }

            Console.WriteLine("a = {0}, b = {1}, Product: {2}", coefficient_a, coefficient_b, coefficient_a * coefficient_b);
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

            for (int i = 2; Math.Pow(i, 2) <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }
}
