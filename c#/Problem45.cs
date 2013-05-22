using System;

namespace Euler
{
    class Problem45 : Problem
    {
        private long triangle = 285;
        private long pentagon = 165;
        private long hexagon = 143;

        private long currentTriangle;
        private long currentPentagonal;
        private long currentHexagonal;

        public override void Process()
        {
            long nextSatisfyingInteger = 40756;

            while (!IsSatisfyingInteger(nextSatisfyingInteger))
            {
                hexagon++;
                nextSatisfyingInteger = GetHexagonal();
            }
            
            Console.WriteLine(
                "Next triangular, pentagonal and hexagonal number is {0}\n(T: {1}, P: {2}, H: {3})",
                nextSatisfyingInteger,
                triangle,
                pentagon,
                hexagon
            );
        }

        private bool IsSatisfyingInteger(long integer)
        {
            return IsPentagonal(integer) && IsTriangular(integer);
        }

        private bool IsTriangular(long integer)
        {
            currentTriangle = GetTriangle();
            if (integer < currentTriangle)
                return false;

            while (currentTriangle < integer) {
                triangle++;
                currentTriangle = GetTriangle();
            }

            return integer == currentTriangle;
        }

        private bool IsPentagonal(long integer)
        {
            currentPentagonal = GetPentagonal();
            if (integer < currentPentagonal)
                return false;

            while (currentPentagonal < integer) {
                pentagon++;
                currentPentagonal = GetPentagonal();
            }

            return integer == currentPentagonal;
        }

        private bool IsHexagonal(long integer)
        {
            currentHexagonal = GetHexagonal();
            if (integer < currentHexagonal)
                return false;

            while (currentHexagonal < integer) {
                hexagon++;
                currentHexagonal = GetHexagonal();
            }

            return integer == currentHexagonal;
        }

        private long GetTriangle()
        {
            return (long)(triangle * (triangle + 1) / 2);
        }

        private long GetPentagonal()
        {
            return (long)(pentagon * ((3 * pentagon) - 1)) / 2;
        }

        private long GetHexagonal()
        {
            return hexagon * ((2 * hexagon) - 1);
        }
    }
}