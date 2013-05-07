using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem4 : Problem
    {
        public override void Process()
        {
            long palindrome = FindLargestPalindrome();

            Console.WriteLine("Largest Palindrome: {0}", palindrome);
        }

        private long FindLargestPalindrome()
        {
            long largestPalindrome = 0;
            IEnumerable<int> threeDigitInts = Enumerable.Range(100, 900).Reverse();

            foreach (int i in threeDigitInts)
            {
                foreach (int j in threeDigitInts)
                {
                    long possiblePalindrome = i * j;
                    if (IsPalindromic(possiblePalindrome) && possiblePalindrome > largestPalindrome)
                    {
                        largestPalindrome = possiblePalindrome;
                    }
                }
            }

            return largestPalindrome;
        }

        private bool IsPalindromic(long value)
        {
            string inputStr = value.ToString();
            Char[] reversed = String.Copy(inputStr).ToCharArray();
            Array.Reverse(reversed);

            return String.Equals(new String(reversed), inputStr);
        }
    }
}
