using System;
using System.Collections.Generic;

namespace Euler
{
    class Problem28 : Problem
    {
        private int[,] spiral;

        private enum Axis { X, Y };

        public override void Process()
        {
            int size = 1001;
            GenerateSpiral(size);

            Console.WriteLine("Sum of Diagonals in {0}x{0} grid: {1}", size, SumOfDiagonals());
        }

        private void GenerateSpiral(int size, bool debug = false)
        {
            if (size % 2 == 0)
                throw new ArgumentException(String.Format("Cannot generate a spiral with even size. Try size = {0}", size + 1));

            int x, y;
            spiral = new int[size, size];
            x = y = (int)Math.Floor((double)size / 2);
            Axis axis = Axis.X;

            for (int n = 1, v = 1, s = 2, r = 0; n <= Math.Pow(size, 2); n++)
            {
                spiral[y, x] = n;

                switch (axis)
                {
                    case Axis.X:
                        x += v;
                        break;

                    case Axis.Y:
                        y += v;
                        break;
                }

                if (debug)
                {
                    DebugSpiral(x, y, n, v, axis, s);
                }

                if (n % s == 0)
                {
                    s += (r * 2) + 4;
                    v *= -1;
                    r++;
                }

                if (n % (1 + r) == 0)
                {
                    axis = axis == Axis.X ? Axis.Y : Axis.X;
                }
            }
        }

        private void DebugSpiral(int x, int y, int n, int v, Axis axis, int s)
        {
            Console.Clear();
            Console.WriteLine("Current : {0}", n);
            Console.WriteLine("Position: [{0,2},{1,2}]", y, x);
            Console.WriteLine("Movement: {1}{0} ({2})", v == 1 ? "++" : "--", axis, s);
            Console.WriteLine("");

            PrintSpiral();
            Console.ReadKey();
        }

        private void PrintSpiral()
        {
            ConsoleColor colour;
            Console.Write("\n");

            for (int row = 0; row < spiral.GetLength(0); row++)
            {
                for (int col = 0; col < spiral.GetLength(1); col++)
                {
                    colour = (row == col || (spiral.GetLength(1) - 1) - col == row) ? ConsoleColor.White : ConsoleColor.DarkGray;
                    Console.ForegroundColor = colour;
                    Console.Write("{0,5}", spiral[row, col]);
                }

                Console.Write("\n");
            }

            Console.Write("\n");
            Console.ResetColor();
        }

        private long SumOfDiagonals()
        {
            long sum = 0;

            for (int row = 0; row < spiral.GetLength(0); row++)
            {
                for (int col = 0; col < spiral.GetLength(1); col++)
                {
                    if (row == col || (spiral.GetLength(1) - 1) - col == row)
                    {
                        sum += spiral[row, col];
                    }
                }
            }

            return sum;
        }
    }
}
