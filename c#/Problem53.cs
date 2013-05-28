using System;

namespace Euler
{
    class Problem53 : Problem
    {
        public override void Process()
        {
            int matching = 0, limit = 1000000, selections = 100;

            PascalsTriangle triangle = new PascalsTriangle(selections);
            matching = triangle.FindSatisfying(x => x >= (ulong)limit);

            Console.WriteLine("Combinatoric selections greater than {0}: {1}", limit, matching);
        }
    }

    class PascalsTriangle
    {
        private ulong[,] triangle;
        public int Length { get; private set; }

        public PascalsTriangle(int size)
        {
            Length = size;

            triangle = new ulong[Length + 1, Length + 1];
            Generate();          
        }

        private void Generate()
        {
            // Fill initial column
            for (int i = 0; i <= Length; i++)
            {
                triangle[i, 0] = 1;
            }

            // Calculate based on previous
            for (int i = 1; i <= Length; i++)
            {
                for (int j = 1; j <= Length; j++)
                {
                    triangle[i, j] = triangle[i - 1, j] + triangle[i - 1, j - 1];
                }
            }
        }

        public int FindSatisfying(Func<ulong, bool> booleanFunction)
        {
            int matching = 0;
            for (int i = 0; i <= Length; i++)
            {
                for (int j = 0; j <= Length; j++)
                {
                    if (booleanFunction(triangle[i, j]))
                        matching++;
                }
            }

            return matching;
        }
    }
}
