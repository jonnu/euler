using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem14 : Problem
    {
        public override void process()
        {
            Int32 largestChainProducer = 0, collatzLength = 0, collatzMaximum = 0;
            List<Int32> numbers = Enumerable.Range(1, 1000000).ToList();
            foreach (Int32 number in numbers)
            {
                collatzLength = getCollatzChainLength(number);
                if (collatzLength > collatzMaximum)
                {
                    largestChainProducer = number;
                    collatzMaximum = collatzLength;
                }
            }

            Console.WriteLine("{0} (produced chain with {1} terms)", largestChainProducer, collatzMaximum);
        }

        private Int32 getCollatzChainLength(Int64 n)
        {
            Int32 length = 1;
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
