using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem1 : Problem
    {
        public override void process()
        {
            Int32 sumOfMultiples = Enumerable.Range(0, 1000)
                .Where(i => i % 3 == 0 || i % 5 == 0)
                .Sum();

            Console.WriteLine(sumOfMultiples);
            Console.ReadKey();
        }
    }
}
