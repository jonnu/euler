using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem32 : Problem
    {
        public override void Process()
        {
            long pandigitalSum = FindPandigitalProducts()
                .ToList()
                .Distinct()
                .Sum();

            Console.WriteLine("Sum of all Pandigital products: {0}", pandigitalSum);
        }

        private IEnumerable<long> FindPandigitalProducts()
        {
            for (int i = 2; i < 98; i++)
            {
                for (int j = 2; j < 1987; j++)
                {
                    PandigitalCheck p = new PandigitalCheck(i, j);
                    if (p.Pandigital())
                        yield return p.Product;

                    if (p.Length > 9)
                        break;
                }
            }
        }
    }

    class PandigitalCheck
    {
        private int multiplicand;
        private int multiplier;

        public int Length { get; private set; }
        public long Product { get; private set; }

        public PandigitalCheck(int multiplicand, int multiplier)
        {
            this.multiplicand = multiplicand;
            this.multiplier = multiplier;

            Product = multiplicand * multiplier;
        }

        public bool Pandigital()
        {
            string joined = Product.ToString() + multiplicand.ToString() + multiplier.ToString();
            Length = joined.Length;

            if (Length != 9)
                return false;

            char[] sorted = joined.ToCharArray().OrderBy(x => x).ToArray();
            return new String(sorted) == "123456789";
        }
    }
}
