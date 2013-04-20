using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem2 : Problem
    {
        public override void process()
        {
            Int32 evenFibonaccis = Fibonacci(4000000)
                .ToList()
                .Where(i => i % 2 == 0)
                .Sum();

            Console.WriteLine(evenFibonaccis);
            Console.ReadLine();
        }

        private IEnumerable<Int32> Fibonacci(Int32 upperLimit)
        {
            Int32 current = 1, previous = 1;
            while (current < upperLimit)
            {
                yield return current;
                Int32 temporary = current;
                current += previous;
                previous = temporary;
            }
        }
    }
}
