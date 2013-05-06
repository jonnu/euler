using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem5 : Problem
    {
        public override void process()
        {
            Int64 smallestValue = 0;
            bool perfectlyDivisible = false;

            IEnumerable<Int32> integerRange = Enumerable.Range(11, 10);
            Int32 integerStep = integerRange.Max();

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
