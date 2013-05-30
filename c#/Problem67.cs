using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Euler
{
    class Problem67 : Problem
    {
        public override void Process()
        {
            // Split the text file up by line, and then by space
            List<List<int>> data = Regex.Split(ReadTextFile("Problem67.txt", false), @"\r?\n|\r")
                .Where(line => line.Length > 0)
                .Select(line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(integer => Int32.Parse(integer))
                    .ToList()
                ).ToList();

            // Work from bottom to top, summing as we go. The value at the
            // apex of the pyramid should be the maxmimum possible value
            for (int row = data.Count() - 2; row >= 0; row--)
            {
                for (int col = 0; col < data[row].Count(); col++)
                {
                    data[row][col] += Math.Max(data[row + 1][col], data[row + 1][col + 1]);
                }
            }

            Console.WriteLine("Maximum path sum: {0}", data[0][0]);
        }
    }
}
