using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem34 : Problem
    {
        private int current = 10;
        private int[] factorals = new int[10];

        public override void Process()
        {
            CacheSingleDigitFactorials();

            int upperBound = factorals[9] * 7; // i.e. 9,999,999
            Console.WriteLine("Sum of digit factorals < {0} = {1}", upperBound, GetFactoralSumMatch(upperBound).Sum());
        }

        private void CacheSingleDigitFactorials()
        {
            factorals[0] = 1; // 0! = 1
            for (int i = 1; i < 10; i++)
            {
                factorals[i] = Enumerable.Range(1, i).Aggregate(1, (x, y) => x * y);
            }
        }

        private IEnumerable<int> GetFactoralSumMatch(long limit)
        {
            while (current <= limit)
            {
                int check = current, sum = 0;
                while (check > 0)
                {
                    int num = check % 10;
                    check /= 10;
                    sum += factorals[num];
                }

                if (sum == current)
                    yield return current;

                current++;
            }
        }
    }
}
