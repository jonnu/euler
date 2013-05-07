using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem14 : Problem
    {
        public override void Process()
        {
            int largestChainProducer = 0, collatzLength = 0, collatzMaximum = 0;
            List<int> numbers = Enumerable.Range(1, 1000000).ToList();
            foreach (int number in numbers)
            {
                collatzLength = CollatzChainLength(number);
                if (collatzLength > collatzMaximum)
                {
                    largestChainProducer = number;
                    collatzMaximum = collatzLength;
                }
            }

            Console.WriteLine("{0} (produced chain with {1} terms)", largestChainProducer, collatzMaximum);
        }

        private int CollatzChainLength(long n)
        {
            int length = 1;
            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    n = n / 2;
                }
                else
                {
                    n = (3 * n) + 1; 
                }

                length++;
            }

            return length;
        }
    }
}
