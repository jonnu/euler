using System;
using System.Collections.Generic;

namespace Euler
{
    class Problem24 : Problem
    {
        public override void Process()
        {
            string setOfCharacters = "0123456789";
            char[] thisPermutation = setOfCharacters.ToCharArray();
            char[] nextPermutation;

            int limit = 1000000, permutation;

            for (permutation = 1; permutation < limit; permutation++)
            {
                nextPermutation = GetNextPermutation(thisPermutation);
                if (null == nextPermutation)
                    break;

                thisPermutation = nextPermutation;
            }

            Console.WriteLine("Permutation #{0} for '{1}' is {2}", permutation, setOfCharacters, new String(thisPermutation));
        }

        private char[] GetNextPermutation(char[] permutation)
        {
            // 1. Find the largest index k such that permutation[k] < permutation[k + 1].
            // If no such index exists, the permutation is the last permutation (return null).
            int k;
            for (k = permutation.Length - 2; k >= 0; k--)
            {
                if (permutation[k] >= permutation[k + 1]) {

                    if (k > 0)
                        continue;

                    return null;
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

            return permutation;
        }
    }

    public static class IListExtensions
    {
        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }

        public static void ReversePartial<T>(this IList<T> list, int a, int b)
        {
            while (a < b)
            {
                list.Swap(a, b);
                a++;
                b--;
            }
        }
    }
}

