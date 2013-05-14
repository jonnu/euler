using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem33 : Problem
    {
        private List<Fraction> fractions = new List<Fraction>();

        public override void Process()
        {
            for (int i = 12; i < 100; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    // Ignore trivial combinations
                    if (IsTrivialCombination(i, j))
                        continue;

                    int x = RemoveCommonNumber(i, j);
                    int y = RemoveCommonNumber(j, i);

                    // lets not divide by zero...
                    if (x <= 0 || y <= 0)
                        continue;
                    
                    // Compare original fraction with 'simplified' fraction
                    Fraction original = new Fraction(i, j);
                    Fraction cancelled = new Fraction(x, y);

                    if (original == cancelled)
                    {
                        fractions.Add(original);
                    }
                }
            }

            // Multiply the fractions together
            long numerator = fractions.Select(x => (long)x.Numerator).Aggregate((x, y) => x * y);
            long denominator = fractions.Select(x => (long)x.Denominator).Aggregate((x, y) => x * y);
            long commonDivisor = FindGreatestCommonDivisor(numerator, denominator);

            // Output findings
            Console.WriteLine("Found {0} fractions:\n", fractions.Count());
            foreach (Fraction fraction in fractions)
            {
                Console.Write(fraction.ToString());
                if (fraction != fractions.Last())
                    Console.Write(", ");
            }

            Console.WriteLine("\nLowest common denominator: {0}", denominator / commonDivisor);
        }

        private int RemoveCommonNumber(int number, int compare)
        {
            char[] unique = number.ToString().Except(compare.ToString()).ToArray();
            if (unique.Count() == 0)
                return -1;

            return Int32.Parse(new String(unique));
        }

        private bool IsTrivialCombination(int i, int j)
        {
            if (i % 10 == 0 && j % 10 == 0)
                return true;

            string concat = i.ToString() + j.ToString();
            if (concat.Distinct().Count() == concat.Length || concat.Distinct().Count() == 2)
                return true;

            return false;
        }

        private long FindGreatestCommonDivisor(params long[] values)
        {
            long gcd = 0, modulo = 0;
            long[] remainders = new long[values.Length];

            while (gcd == 0)
            {
                Array.Sort(values);
                modulo = values[0];

                for (int i = 1; i < values.Length; i++)
                {
                    remainders[i] = values[i] % modulo;
                }

                if (remainders.Sum() == 0)
                {
                    gcd = modulo;
                }
                else
                {
                    List<long> temp = remainders.Where(x => x > 0).ToList();
                    temp.Add(modulo);
                    values = temp.ToArray();
                }
            }

            return gcd;
        }
    }

    class Fraction
    {
        private long denominator;

        public double Value { get; private set; }
        public long Numerator { get; private set; }
        public long Denominator
        {
            get
            {
                return denominator;
            }
            private set
            {
                if (value == 0)
                    throw new ArgumentException("Denominator must be non-zero.");

                denominator = value;
            }
        }

        public Fraction(long numer, long denom)
        {
            Numerator = numer;
            Denominator = denom;

            Value = (double)Numerator / Denominator;
        }

        public static bool operator ==(Fraction x, Fraction y)
        {
            return x.Value == y.Value;
        }

        public static bool operator !=(Fraction x, Fraction y)
        {
            return x.Value != y.Value;
        }

        public override bool Equals(object o)
        {
            return (bool)(this == (Fraction)o);
        }

        public override int GetHashCode()
        {
            return (int)Numerator ^ (int)Denominator;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", Numerator, Denominator);
        }
    }
}
