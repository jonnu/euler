using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem36 : Problem
    {
        public override void Process()
        {
            long sum = 0, limit = 1000000;

            sum = GetDoubleBasePalindromicNumbers(limit).Sum();
            Console.WriteLine("Sum of double-base palindromes below {0} = {1}", limit, sum);
        }

        private IEnumerable<long> GetDoubleBasePalindromicNumbers(long limit)
        {
            long n = 1;
            while (n < limit)
            {
                if (PalindromicInBothBases(n))
                    yield return n;

                n++;
            }
        }

        private bool PalindromicInBothBases(long number)
        {
            // Only binary ending in 1 can be a palindrome (no leading 0's stipulation)
            string asBinary = Convert.ToString(number, 2);
            if ((int)asBinary[asBinary.Length - 1] % 2 != 1)
                return false;

            return Palindromic(number.ToString()) && Palindromic(asBinary);
        }

        private bool Palindromic(string number)
        {
            char[] reversed = String.Copy(number).Reverse().ToArray();
            return number.Equals(new String(reversed));
        }

    }
}
