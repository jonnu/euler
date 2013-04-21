using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem12 : Problem
    {
        public override void process()
        {
            Int32 divisors = 0, i = 1, triangle = 0;
            while (divisors < 500)
            {
                triangle = Enumerable.Range(1, i).Sum();
                divisors = findDivisors(triangle).Count();
                i++;
            }

            Console.WriteLine(triangle);
            Console.ReadKey();
        }

        private IEnumerable<Int32> findDivisors(Int32 value)
        {
            Int32 i = 1;
            while (i <= Math.Sqrt(value))
            {
                if (value % i == 0)
                {
                    yield return i;

                    if (value == 1)
                        yield break;

                    yield return value / i;
                }

                i++;
            }
        }
    }
}
