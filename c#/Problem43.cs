using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem43 : Problem
    {
        public override void Process()
        {
            PandigitalPermutations permutations = new PandigitalPermutations();

            long sumOfDivisiblePandigitals = 0;
            while (permutations.NextPermutation())
            {
                if (permutations.IsSubstringPrimeDivisible())
                    sumOfDivisiblePandigitals += permutations.Value;
            }

            Console.WriteLine("Sum of all 10-digit prime-divisible pandigitals: {0}", sumOfDivisiblePandigitals);
        }
    }

    class PandigitalPermutations
    {
        private long perm;
        private int[] sub;

        public long Value
        {
            get
            {
                return perm;
            }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine(perm);
                    Console.WriteLine(value);
                }

                perm = value;
                sub = new int[7];
                long temp = value;

                for (int n = 6; n >= 0; n--)
                {
                    sub[n] = (int)(temp % 1000);
                    temp /= 10;
                }
            }
        }

        public PandigitalPermutations(long starting = 1234567890)
        {
            Value = starting;
        }

        public bool IsSubstringPrimeDivisible()
        {
            int[] primes = new int[7] { 2, 3, 5, 7, 11, 13, 17 };
            for (int s = 0; s < 7; s++)
            {
                if (sub[s] % primes[s] != 0)
                    return false;
            }

            return true;
        }

        public bool NextPermutation()
        {
            int[] permutation = ConvertToIntArray(perm);

            // 1. Find the largest index k such that permutation[k] < permutation[k + 1].
            // If no such index exists, the permutation is the last permutation (return null).
            int k;
            for (k = permutation.Length - 2; k >= 0; k--)
            {
                if (permutation[k] >= permutation[k + 1])
                {

                    if (k > 0)
                        continue;

                    return false;
                }

                break;
            }

            // 2. Find the largest index l such that permutation[k] < permutation[l].
            // Since k + 1 is such an index, l is well defined and satisfies k < l.
            int l;
            for (l = permutation.Length - 1; l >= 0; l--)
            {
                if (permutation[k] >= permutation[l])
                    continue;

                break;
            }

            // 3. Swap permutation[k] with permutation[l].
            permutation.Swap(k, l);

            // 4. Reverse the sequence from permutation[k + 1] up to and including the final element.
            permutation.ReversePartial(k + 1, permutation.Length - 1);

            // 5, Convert int[] to long
            Value = ConvertToLong(permutation);

            return true;
        }

        private long ConvertToLong(int[] intArray)
        {
            long temp = 0;
            for (int i = intArray.Length - 1, multiplier = 1; i >= 0; i--, multiplier *= 10)
            {
                if (intArray[i] == 0)
                    continue;

                long product = (long)intArray[i] * multiplier;
                temp += product;
            }

            return temp;
        }

        private int[] ConvertToIntArray(long integer)
        {
            int length = (int)Math.Log10(integer) + 1;
            int[] temp = new int[length];
            for (int i = length - 1; i >= 0; i--)
            {
                int digit = (int)(integer % 10);
                temp[i] = digit;
                integer /= 10;
            }

            return temp;
        }
    }
}
