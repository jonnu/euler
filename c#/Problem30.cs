using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem30 : Problem
    {
        public override void Process()
        {
            Console.WriteLine("Sum of all digit fifth powers: {0}", GetDigitFifthPowers().Sum());
        }

        private IEnumerable<long> GetDigitFifthPowers()
        {
            // Largest digit is 9, thus limit is 5(9^5)
            long limit = (long)Math.Pow(9, 5) * 5;

            for (long i = 2; i <= limit; i++)
            {
                if (i == i.ToString().ToCharArray().Select(x => (long)Math.Pow(Int32.Parse(x.ToString()), 5)).Sum())
                {
                    yield return i;
                }
            }
        }
    }
}
