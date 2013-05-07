using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem16 : Problem
    {
        public override void Process()
        {
            int limit = 1000;
            long sumOfAllDigits = BigInteger.Pow(2, limit)
                .ToString()
                .ToCharArray()
                .Select(n => Int32.Parse(n.ToString()))
                .Sum();

            Console.WriteLine("Sum of all digits in 2^{1}: {0}", sumOfAllDigits, limit);
        }
    }
}
