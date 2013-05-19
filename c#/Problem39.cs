using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem39 : Problem
    {
        static public int[] Powers;

        public override void Process()
        {
            int limit = 1000;
            Powers = GeneratePowers(limit);

            PythagoreanSolution ps = Enumerable.Range(1, limit)
                .Where(x => x % 2 == 0)
                .Select(x => new PythagoreanSolution(x))
                .OrderByDescending(x => x.GetCount())
                .First();

            ps.Debug();
        }

        private int[] GeneratePowers(int limit)
        {
            return Enumerable.Range(0, limit)
                .Select(x => x * x)
                .ToArray();
        }
    }

    class PythagoreanSolution
    {
        private int limit;
        private List<Tuple<int, int, int>> solutions;

        public PythagoreanSolution(int solution)
        {
            limit = solution;
            solutions = new List<Tuple<int, int, int>>();
            FindSolutions();
        }

        private void FindSolutions()
        {
            for (int a = 1; a < limit; a++)
            {
                for (int b = a + 1; b < limit; b++)
                {
                    int c = limit - (a + b);
                    if (c <= b)
                        break;

                    if (Problem39.Powers[a] + Problem39.Powers[b] == Problem39.Powers[c])
                    {
                        solutions.Add(new Tuple<int, int, int>(a, b, c));
                    }
                }
            }
        }

        public void Debug()
        {
            Console.WriteLine("Solutions a+b+c = {0}{1}", limit, Environment.NewLine);
            foreach (Tuple<int, int, int> triangle in solutions)
            {
                Console.WriteLine("({0,3}, {1,3}, {2,3})", triangle.Item1, triangle.Item2, triangle.Item3);
            }
            Console.WriteLine("{0}Solutions: {1}", Environment.NewLine, GetCount());
        }

        public int GetCount()
        {
            return solutions.Count();
        }
    }
}
