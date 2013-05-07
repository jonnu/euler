using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem2 : Problem
    {
        public override void Process()
        {
            Int32 evenFibonaccis = Fibonacci(4000000)
                .ToList()
                .Where(i => i % 2 == 0)
                .Sum();

            Console.WriteLine(evenFibonaccis);
        }

        private IEnumerable<Int32> Fibonacci(int upperLimit)
        {
            int current = 1, previous = 1;
            while (current < upperLimit)
            {
                yield return current;
                int temporary = current;
                current += previous;
                previous = temporary;
            }
        }
    }
}
