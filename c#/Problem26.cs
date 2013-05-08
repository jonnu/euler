using System;

namespace Euler
{
    class Problem26 : Problem
    {
        public override void Process()
        {
            int limit = 1000;
            int longest = FindLongestReciprocalCycle(limit);

            Console.WriteLine("Integer with longest reciprocal cycle <= {0} = {1}", limit, longest);
        }

        private int FindLongestReciprocalCycle(int limit)
        {
            int longest = 0, sampled = limit;
            for (int i = limit; i > 1; i--)
            {
                if (i - 1 < longest)
                    break;

                int j = 1, place = 0;
                int[] remainders = new int[i];

                while (remainders[j] == 0)
                {
                    remainders[j] = place;
                    j = (j * 10) % i;
                    place++;
                }

                // Did this result in a new maximum?
                if (longest < (place - remainders[j]))
                {
                    longest = place - remainders[j];
                    sampled = i;
                }
            }

            return sampled;
        }
    }
}
