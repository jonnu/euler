using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Euler
{
    class Problem18 : Problem
    {
        private List<List<int>> rows = new List<List<int>>();

        public override void Process()
        {
            List<string> lines = Regex
                .Split(ReadTextFile("Problem18.txt", false), @"\r?\n|\r")
                .ToList();

            // Break lines into lists of integers
            foreach (string line in lines)
            {
                rows.Add(line.Split(' ').Select(x => Int32.Parse(x)).ToList());
            }

            // Work from bottom to top, summing as we go. The value at the
            // apex of the pyramid should be the maxmimum possible value
            for (int row = rows.Count() - 2; row >= 0; row--)
            {
                for (int col = 0; col < rows[row].Count(); col++)
                {
                    rows[row][col] += Math.Max(rows[row + 1][col], rows[row + 1][col + 1]);
                }
            }

            Console.WriteLine("Maximum path sum: {0}", rows[0][0]);
        }
    }
}
