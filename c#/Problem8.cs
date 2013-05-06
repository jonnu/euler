using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem8 : Problem
    {
        public override void process()
        {
            Int32 chunk = 5, max = 0;
            String data = readTextFile("Problem8.txt");

            for (Int32 p = 0; p < data.Length - chunk; p++)
            {
                Int32 product = productOfAllDigits(data.Substring(p, chunk));
                if (product > max) {
                    max = product;
                }
            }

            Console.WriteLine(max);
        }

        private Int32 productOfAllDigits(String input)
        {
            if (input.Contains("0") || input.Length == 0)
                return 0;

            return input.ToCharArray()
                .Select(x => Int32.Parse(x.ToString()))
                .Aggregate((x, y) => x * y);
        }
    }
}
