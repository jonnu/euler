using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem4 : Problem
    {
        public override void process()
        {
            Int64 palindrome = findLargestPalindrome();
            System.Console.WriteLine(palindrome);
            System.Console.ReadKey();
        }

        private Int64 findLargestPalindrome()
        {
            IEnumerable<Int32> threeDigitInts = Enumerable.Range(100, 900).Reverse();
            System.Console.WriteLine(threeDigitInts.Last());
            Int64 largestPalindrome = 0;

            foreach (Int32 i in threeDigitInts)
            {
                foreach (Int32 j in threeDigitInts)
                {
                    Int64 possiblePalindrome = i * j;
                    if (isPalindromic(possiblePalindrome) && possiblePalindrome > largestPalindrome)
                    {
                        largestPalindrome = possiblePalindrome;
                    }
                }
            }

            return largestPalindrome;
        }

        private bool isPalindromic(Int64 value)
        {
            String inputStr = value.ToString();
            Char[] reversed = String.Copy(inputStr).ToCharArray();
            Array.Reverse(reversed);

            return String.Equals(new String(reversed), inputStr);
        }
    }
}
