using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    class Problem20 : Problem
    {
        public override void process()
        {
            Int32 factor = 100;
            Int32 sumOfFactoral = Enumerable.Range(1, factor)
                .Select(i => (BigInteger)i)
                .Aggregate(BigInteger.Multiply)
                .ToString()
                .ToCharArray()
                .Select(j => Int32.Parse(j.ToString()))
                .Sum();

            Console.WriteLine("Sum of digits in {0}! = {1}", factor, sumOfFactoral);
            Console.ReadKey();
        }
    }
}