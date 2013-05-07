using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem5 : Problem
    {
        public override void Process()
        {
            long smallestValue = 0;
            bool perfectlyDivisible = false;

            IEnumerable<int> integerRange = Enumerable.Range(11, 10);
            int integerStep = integerRange.Max();

            while (!perfectlyDivisible)
            {
                smallestValue += integerStep;
                perfectlyDivisible = integerRange
                    .Where(i => smallestValue % i != 0)
                    .Count() == 0;
            }

            Console.WriteLine(smallestValue);
        }

    }
}
