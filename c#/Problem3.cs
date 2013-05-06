using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem3 : Problem
    {
        public override void process()
        {
            Int64 upperLimit = 600851475143;
            List<Int64> factors = primeFactors(upperLimit).ToList();

            Console.WriteLine(factors.Last());
        }

        public static IEnumerable<Int64> primeFactors(Int64 upperLimit)
        {
            for (Int32 div = 2; upperLimit > 1;)
            {
                while (upperLimit % div == 0)
                {
                    yield return div;
                    upperLimit /= div;
                }

                div++;
                if (Math.Pow(div, 2) > upperLimit && upperLimit > 1)
                {
                    yield return upperLimit;
                    break;
                }
            }
        }
    }
}
