using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem92 : Problem
    {
        const int maximumSquare = 568; // (9^2)x7 + 1

        private int[] squares = new int[10] { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81 };
        private int[] enddata = new int[maximumSquare];

        public override void Process()
        {
            int limit = 10000000;
            int found = 0;

            enddata[1] = 1;
            enddata[89] = 89;

            for (int i = 1; i < limit; i++)
            {
                if (89 == GetFirstRepeatedIntegerInChain(i))
                {
                    found++;
                }
            }

            Console.WriteLine(found);
        }

        private int SumOfDigitsSquared(int value)
        {
            int sum = 0;
            while (value > 0)
            {
                sum += squares[value % 10];
                value /= 10;
            }

            return sum;
        }

        private int GetFirstRepeatedIntegerInChain(int start)
        {
            int integer = start;
            if (integer >= maximumSquare)
                integer = SumOfDigitsSquared(integer);

            if (enddata[integer] != 0)
                return enddata[integer];

            List<int> seen = new List<int>();
            while (enddata[integer] != 89 && enddata[integer] != 1)
            {
                seen.Add(integer);
                integer = SumOfDigitsSquared(integer);
            }

            // Memoise all seen integers
            foreach (int s in seen)
            {
                enddata[s] = enddata[integer];
            }

            return enddata[integer];
        }
    }
}
