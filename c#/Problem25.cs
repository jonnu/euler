using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem25 : Problem
    {
        public override void process()
        {
            int n = 0, limit = 1000;
            BigInteger current = 0, previous = 1;

            while (current.ToString().Length != limit)
            {
                n++;

                BigInteger temporary = current;
                current += previous;
                previous = temporary;
            }

            Console.WriteLine("F({0}) contains {1} digits.", n, limit);
            Console.ReadKey();
        }
    }
}
