using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem6 : Problem
    {
        public override void process()
        {
            IEnumerable<Int32> numbers = Enumerable.Range(1, 100);
            Double sumSquareDifference = Math.Pow(numbers.Sum(), 2) - numbers.Select(i => Math.Pow(i, 2)).Sum();

            Console.WriteLine(sumSquareDifference);
            Console.ReadKey();
        }

    }
}
