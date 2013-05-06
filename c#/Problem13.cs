using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem13 : Problem
    {
        public override void process()
        {
            List<BigInteger> values = readBigIntegersFromFile("Problem13.txt");

            string firstTenDigits = values
                .Aggregate((current, next) => current + next)
                .ToString()
                .Substring(0, 10);

            Console.WriteLine(firstTenDigits);
        }

        private List<BigInteger> readBigIntegersFromFile(string filename)
        {
            string raw = readTextFile(filename, false);
            List<BigInteger> data = new List<BigInteger>();

            using (StringReader reader = new StringReader(raw))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    data.Add(BigInteger.Parse(line));
                }
            }

            return data;
        }
    }
}
