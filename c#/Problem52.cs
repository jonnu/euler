using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem52 : Problem
    {
        public override void Process()
        {
            int integer = 1;
            while (!ArePermutable(GetMultiples(integer, 6)))
            {
                integer++;
            }

            Console.WriteLine("First 1-6x permutable integer: {0}", integer);
        }

        private int[] GetMultiples(int value, int limit)
        {
            int[] multiples = new int[limit];
            for (int i = 1; i <= limit; i++)
            {
                multiples[i - 1] = value * i;
            }

            return multiples;
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
