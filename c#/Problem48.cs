using System;
using System.Numerics;
using System.Linq;

namespace Euler
{
    class Problem48 : Problem
    {
        public override void Process()
        {
            string disgustinglyLargeNumber = Enumerable.Range(1, 1000)
                .Select(x => BigInteger.Pow((BigInteger)x, x))
                .Aggregate((x, y) => BigInteger.Add(x, y))
                .ToString();

            Console.WriteLine(disgustinglyLargeNumber.Substring(disgustinglyLargeNumber.Length - 10));
        }
    }
}
