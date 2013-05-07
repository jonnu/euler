using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem1 : Problem
    {
        public override void Process()
        {
            Int32 sumOfMultiples = Enumerable.Range(0, 1000)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum();

            Console.WriteLine(sumOfMultiples);
        }
    }
}
