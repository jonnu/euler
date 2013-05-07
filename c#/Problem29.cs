using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem29 : Problem
    {
        public override void process()
        {
            int max = 100, count = 0;
            IEnumerable<int> terms = Enumerable.Range(2, max - 1);

            count = (from a in terms from b in terms select Math.Pow(a, b))
                .Distinct()
                .Count();

            Console.WriteLine("Number of distinct terms where n = {0}: {1}", max, count);
        }
    }
}
