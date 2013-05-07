using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem8 : Problem
    {
        public override void Process()
        {
            int chunk = 5, max = 0;
            string data = ReadTextFile("Problem8.txt", true);

            for (int p = 0; p < data.Length - chunk; p++)
            {
                int product = ProductOfAllDigits(data.Substring(p, chunk));
                if (product > max) {
                    max = product;
                }
            }

            Console.WriteLine("Largest product of {0} consequtive digits: {1}", chunk, max);
        }

        private int ProductOfAllDigits(string input)
        {
            if (input.Contains("0") || input.Length == 0)
                return 0;

            return input.ToCharArray()
                .Select(x => Int32.Parse(x.ToString()))
                .Aggregate((x, y) => x * y);
        }
    }
}
