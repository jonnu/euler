using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem11 : Problem
    {
        private int[][] matrix;
        private List<long> iterations;
        private int valuesToTake = 4;

        public override void Process()
        {
            string data = ReadTextFile("Problem11.txt", false);
            matrix = ConvertToIntegerMatrix(data);

            iterations = new List<long>();
            // DisplayIntegerMatrix(matrix);

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    // Which directions are feasable at this position?
                    bool d_n = row >= 3;
                    bool d_s = row <= matrix.Length - valuesToTake - 1;
                    bool d_e = col <= matrix[row].Length - valuesToTake - 1;
                    bool d_w = col >= 3;

                    if (d_n)
                    {
                        iterations.Add(matrix[row][col] * matrix[row - 1][col] * matrix[row - 2][col] * matrix[row - 3][col]);
                    }

                    if (d_s)
                    {
                        iterations.Add(matrix[row][col] * matrix[row + 1][col] * matrix[row + 2][col] * matrix[row + 3][col]);
                    }

                    if (d_e)
                    {
                        iterations.Add(matrix[row][col] * matrix[row][col + 1] * matrix[row][col + 2] * matrix[row][col + 3]);
                    }

                    if (d_w)
                    {
                        iterations.Add(matrix[row][col] * matrix[row][col - 1] * matrix[row][col - 2] * matrix[row][col - 3]);
                    }

                    if (d_n && d_w)
                    {
                        iterations.Add(matrix[row][col] * matrix[row - 1][col - 1] * matrix[row - 2][col - 2] * matrix[row - 3][col - 3]);
                    }

                    if (d_n && d_e)
                    {
                        iterations.Add(matrix[row][col] * matrix[row - 1][col + 1] * matrix[row - 2][col + 2] * matrix[row - 3][col + 3]);
                    }

                    if (d_s && d_w)
                    {
                        iterations.Add(matrix[row][col] * matrix[row + 1][col - 1] * matrix[row + 2][col - 2] * matrix[row + 3][col - 3]);
                    }

                    if (d_s && d_e)
                    {
                        iterations.Add(matrix[row][col] * matrix[row + 1][col + 1] * matrix[row + 2][col + 2] * matrix[row + 3][col + 3]);
                    }
                }

            }

            Console.WriteLine("Greatest product of {0} adjacent numbers: {1}", valuesToTake, iterations.Max());
        }

        private void DisplayIntegerMatrix(int[][] matrix)
        {
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[x].Length; y++)
                {
                    Console.Write("{0,2}{1}", matrix[x][y], y == (matrix[x].Length - 1) ? "" : " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private int[][] ConvertToIntegerMatrix(String data)
        {
            int size = data.Count(c => c == '\n') + 1;
            int[][] matrix = new int[size][];
            using (StringReader reader = new StringReader(data))
            {
                string chunk;
                int i = 0;
                while ((chunk = reader.ReadLine()) != null)
                {
                    int[] thisLine = chunk.Split(' ').Select(j => Int32.Parse(j)).ToArray();
                    matrix.SetValue(thisLine, i);
                    i++;
                }
            }

            return matrix;
        }
    }
}
