using System;
using System.Linq;

namespace Euler
{
    class Problem55 : Problem
    {
        public override void Process()
        {
            int lychrelLimit = 10000;
            int lychrelCount = Enumerable
                .Range(1, lychrelLimit)
                .Where(x => IsLychrelNumber(new LargeInt(x), 50))
                .Count();

            Console.WriteLine("{0} Lychrel numbers below {1}", lychrelCount, lychrelLimit);
        }

        private bool IsLychrelNumber(LargeInt value, int loopLimit)
        {
            while (loopLimit > 0)
            {
                value += new LargeInt(value).Reverse();
                if (value.Palindrome())
                    return false;

                loopLimit--;
            }

            return true;
        }
    }
}
