using System;

namespace Euler
{
    class Problem57 : Problem
    {
        public override void Process()
        {
            int limit = 1000, count = 0;
            RootTwoExpansion root = new RootTwoExpansion();

            while (root.Iteration < limit)
            {
                root.Next();
                if (root.OverweightNumerator())
                    count++;
            }

            Console.WriteLine("Where n <= {0}, numerator has more digits than denominator {1} times.", limit, count);
        }

    }

    class RootTwoExpansion
    {
        public int Iteration { get; private set; }
        public LargeInt Numerator { get; private set; }
        public LargeInt Denominator { get; private set; }

        public RootTwoExpansion()
        {
            Iteration = 0;
            Numerator = 1;
            Denominator = 2;
        }

        public void Next()
        {
            Iteration++;

            if (Iteration > 1)
            {
                // Add 1
                Numerator += Denominator;

                // Flip
                LargeInt temporary = Numerator;
                Numerator = Denominator;
                Denominator = temporary;
            }

            // Add 1
            Numerator += Denominator;
        }

        public bool OverweightNumerator()
        {
            return Numerator.Length > Denominator.Length;
        }
    }
}
