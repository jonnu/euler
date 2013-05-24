using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem49 : Problem
    {
        public override void Process()
        {
            int upperLimit = 10000;

            PrimeGenerator generator = new PrimeGenerator();
            List<int> primes = generator.Between(1000, upperLimit);

            for (int i = 0; i < primes.Count(); i++)
            {
                int a = primes[i];
                for (int j = i + 1; j < primes.Count(); j++)
                {
                    int b = primes[j];
                    int c = b + (b - a);
                    if (c > upperLimit)
                        break;

                    if (generator.IsPrime(c) && ArePermutable(a, b, c))
                    {
                        Console.WriteLine("{0}{1}{2} (Step: {3})", a, b, c, c - b);
                    }
                }
            }
        }

        private bool ArePermutable(params int[] values)
        {
            int[] digits = new int[10];

            for (int i = 0; i < values.Count(); i++)
            {
                int[] check = new int[10];
                for (int j = (int)Math.Log10(values[i]) + 1; j > 0; j--)
                {
                    int digit = values[i] % 10;
                    values[i] /= 10;

                    if (i == 0)
                    {
                        digits[digit]++;  
                    }
                    else
                    {
                        check[digit]++;
                    }
                }

                if (i == 0)
                    continue;

                for (int d = 0; d < 10; d++)
                {
                    if (digits[d] - check[d] != 0)
                        return false;
                }
            }

            return true;
        }
    }
}
