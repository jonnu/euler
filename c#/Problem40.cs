using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem40 : Problem
    {
        private int[] powersOfTen = new int[7] { 1, 10, 100, 1000, 10000, 100000, 1000000 };
        private List<int> product = new List<int>();

        public override void Process()
        {
            for (int i = 1, c = 1, d = 0; i <= 1000000; i++)
            {
                int length = (int)Math.Log10(i) + 1;
                d += length;

                if (d >= c)
                {
                    int p = length - (d - c) - 1;
                    Console.WriteLine("{2,8} | {0,6} (digit {1} is a '{3}')", i, p + 1, c, GetNthDigit(i, p));
                    product.Add(GetNthDigit(i, p));
                    c *= 10;
                }
            }

            Console.WriteLine("{1}Champernowne's constant: {0}", product.Aggregate((x, y) => x * y), Environment.NewLine);
        }

        private int GetNthDigit(int number, int n)
        {
            n = (int)Math.Log10(number) - n;
            return ((number / powersOfTen[n]) % 10);
        }
    }
}
