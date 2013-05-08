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
        private int Multiplicand;
        private int Multiplier;

        public int Length { private set; get; }
        public long Product { private set; get; }        

        public PandigitalCheck(int multiplicand, int multiplier)
        {
            Multiplicand = multiplicand;
            Multiplier = multiplier;
            Product = Multiplicand * Multiplier;
        }

        public bool Pandigital()
        {
            Char[] chars = (Product.ToString() + Multiplicand.ToString() + Multiplier.ToString()).ToCharArray();
            Length = chars.Count();

            if (Length != 9)
                return false;

            Array.Sort(chars);
            return new String(chars) == "123456789";
        }
    }
}
