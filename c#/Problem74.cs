using System;
using System.Linq;
using System.Collections.Generic;

namespace Euler
{
    class Problem74 : Problem
    {
        private int[] factorals = new int[10] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
        private int[] chainMemo = new int[2500000];

        public override void Process()
        {
            int maxLength = 60;
            int maxLimit = 1000000;

            int chainCount = Enumerable.Range(1, maxLimit)
                .Where(x => FactoralChainLength(x) == maxLength)
                .Count();

            Console.WriteLine("{0} chains below {1} with {2} non-repeating terms", chainCount, maxLimit, maxLength);
        }

        private int FactoralChainLength(long value)
        {
            List<long> chain = new List<long>();
            while (!chain.Contains(value) && chainMemo[value] == 0)
            {
                chain.Add(value);
                value = DigitSumFactoral(value);
            }

            for (int i = 0; i < chain.Count(); i++)
            {
                chainMemo[chain[i]] = chain.Count() - i + chainMemo[value];
            }

            return chain.Count() + chainMemo[value];
        }            

        private long DigitSumFactoral(long digits)
        {
            long sum = 0;
            for (int i = (int)Math.Log10(digits); i >= 0; i--)
            {
                sum += factorals[(int)(digits % 10)];
                digits /= 10;
            }

            return sum;
        }
    }
}
