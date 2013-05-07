using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem13 : Problem
    {
        public override void Process()
        {
            string firstTenDigits = ReadBigIntegersFromFile("Problem13.txt")
                .Aggregate((current, next) => current + next)
                .ToString()
                .Substring(0, 10);

            Console.WriteLine("First 10 digits: {0}", firstTenDigits);
        }

        private IEnumerable<BigInteger> ReadBigIntegersFromFile(string filename)
        {
            string raw = ReadTextFile(filename, false);
            List<BigInteger> data = new List<BigInteger>();

            using (StringReader reader = new StringReader(raw))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return BigInteger.Parse(line);
                }
            }
        }
    }
}
