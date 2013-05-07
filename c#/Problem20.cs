using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem20 : Problem
    {
        public override void Process()
        {
            int factor = 100;
            int sumOfFactoral = Enumerable.Range(1, factor)
                .Select(i => (BigInteger)i)
                .Aggregate(BigInteger.Multiply)
                .ToString()
                .ToCharArray()
                .Select(j => Int32.Parse(j.ToString()))
                .Sum();

            Console.WriteLine("Sum of digits in {0}! = {1}", factor, sumOfFactoral);
        }
    }
}
