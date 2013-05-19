using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem41 : Problem
    {
        public override void Process()
        {
            int limit = 7654321;
            int maximum = FilterableSieveOfEratosthenes(limit, PandigitalNumber).Max();

            Console.WriteLine("Maximum pandigital prime: {0}", maximum);
        }

        private bool PandigitalNumber(int number)
        {
            int length = (int)Math.Log10(number) + 1;
            BitArray digits = new BitArray(length + 1, false);

            for (int i = 0; i < length; i++)
            {
                int n = number % 10;
                if (n == 0 || n > length)
                    return false;

                if (digits[n])
                    return false;

                digits[n] = true;
                number /= 10;
            }

            return true;
        }

        private IEnumerable<int> FilterableSieveOfEratosthenes(int limit, Func<int, bool> filterMethod)
        {
            BitArray bits = new BitArray(limit, true);
            for (int i = 2; i < Math.Sqrt(limit); i++)
            {
                if (bits[i])
                {
                    for (int j = i * 2; j < limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }

            for (int a = 2; a < bits.Length; a++)
            {
                if (bits[a] && filterMethod(a))
                {
                    yield return a;
                }
            }
        }
    }
}
