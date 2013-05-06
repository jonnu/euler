using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem16 : Problem
    {
        public override void process()
        {
            BigInteger largePower = BigInteger.Pow(2, 1000);
            Int64 sumAllTheDigits = largePower
                .ToString()
                .ToCharArray()
                .Select(n => Int32.Parse(n.ToString()))
                .Sum();

            Console.WriteLine(sumAllTheDigits);
        }
    }
}
