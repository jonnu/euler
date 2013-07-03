using System;

namespace Euler
{
    class Problem112 : Problem
    {
        public override void Process()
        {
            double bouncy = 0;
            long current = 0;

            while (bouncy / current < 0.99 || current == 0)
            {
                current++;

                if (IsBouncy(current))
                    bouncy++;
            }

            Console.WriteLine(current);
        }

        public static bool IsBouncy(long integer)
        {
            int? current = null;
            bool decreasing = false;
            bool increasing = false;

            for (int i = (int)Math.Log10(integer); i >= 0; i--)
            {
                int digit = (int)(integer % 10);
                integer /= 10;

                if (digit > current)
                {
                    decreasing = true;
                }

                if (digit < current)
                {
                    increasing = true;
                }

                current = digit;
            }

            return increasing && decreasing;
        }
    }
}
