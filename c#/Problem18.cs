using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem18 : Problem
    {
        private List<List<Int32>> rows = new List<List<Int32>>();

        public override void process()
        {
            List<String> lines = Regex
                .Split(readTextFile("Problem18.txt", false), @"\r?\n|\r")
                .ToList();

            // Break lines into lists of integers
            foreach (string line in lines)
            {
                rows.Add(line.Split(' ').Select(x => Int32.Parse(x)).ToList());
            }

            // Work from bottom to top, summing as we go. The value at the
            // apex of the pyramid should be the maxmimum possible value
            for (Int32 row = rows.Count() - 2; row >= 0; row--)
            {
                for (Int32 col = 0; col < rows[row].Count(); col++)
                {
                    rows[row][col] += Math.Max(rows[row + 1][col], rows[row + 1][col + 1]);
                }
            }

            Console.WriteLine("Maximum path sum: {0}", rows[0][0]);
            Console.ReadKey();
        }
    }
}
