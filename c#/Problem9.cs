using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem9 : Problem
    {
        public override void process()
        {
            Int64 product = findProductOfPythagoreanTriplet(1000);

            Console.WriteLine(product);
        }

        private Int64 findProductOfPythagoreanTriplet(Int32 limit)
        {
            Int32 a, b, c;

            for (a = 1; a < 500; a++)
            {
                for (b = a + 1; b < 500; b++)
                {
                    if (a >= b)
                        continue;

                    c = limit - b - a;
                    if (b >= c)
                        continue;

                    if (a + b + c != limit)
                        continue;

                    if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                        return a * b * c;
                }
            }

            return 0;
        }
    }
}
