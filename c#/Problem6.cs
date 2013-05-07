using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem6 : Problem
    {
        public override void Process()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 100);
            Double sumSquareDifference = Math.Pow(numbers.Sum(), 2) - numbers.Select(i => Math.Pow(i, 2)).Sum();

            Console.WriteLine(sumSquareDifference);
        }
    }
}
