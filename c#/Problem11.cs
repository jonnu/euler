using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem11 : Problem
    {
        private Int32[][] matrix;
        private List<Int64> iterations;
        private Int32 valuesToTake = 4;

        public override void process()
        {
            string data = readTextFile("Problem11.txt", false);
            matrix = convertToIntegerMatrix(data);

            iterations = new List<Int64>();
            // displayIntegerMatrix(matrix);

            for (Int32 row = 0; row < matrix.Length; row++)
            {
                for (Int32 col = 0; col < matrix[row].Length; col++)
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

            Console.WriteLine(iterations.Max());
        }

        private void displayIntegerMatrix(Int32[][] matrix)
        {
            for (Int32 x = 0; x < matrix.Length; x++)
            {
                for (Int32 y = 0; y < matrix[x].Length; y++)
                {
                    Console.Write("{0, 2}{1}", matrix[x][y], y == (matrix[x].Length - 1) ? "" : " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private Int32[][] convertToIntegerMatrix(String data)
        {
            Int32 size = data.Count(c => c == '\n') + 1;
            Int32[][] matrix = new Int32[size][];
            using (StringReader reader = new StringReader(data))
            {
                string chunk;
                Int32 i = 0;
                while ((chunk = reader.ReadLine()) != null)
                {
                    Int32[] thisLine = chunk.Split(' ').Select(j => Int32.Parse(j)).ToArray();
                    matrix.SetValue(thisLine, i);
                    i++;
                }
            }

            return matrix;
        }
    }
}
