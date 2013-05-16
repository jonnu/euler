using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem38 : Problem
    {
        public override void Process()
        {
            int limit = 10000;
            PandigitalMultipleCheck maximumPandigital = Enumerable.Range(1, limit)
                .Select(x => new PandigitalMultipleCheck(x))
                .Where(x => x.IsPandigital)
                .OrderBy(x => x.Pandigital)
                .Last();

            Console.WriteLine("Maximum Pandigital is {0}, Where n = {1} (using {2} as a base)", maximumPandigital.Pandigital, maximumPandigital.Multiple, maximumPandigital.Value);
        }
    }

    class PandigitalMultipleCheck
    {
        private BitArray bits = new BitArray(9, false);
        private StringBuilder pandigitalStringBuilder = new StringBuilder();

        public int Value { get; private set; }
        public bool IsPandigital { get; private set; }
        public int Multiple { get; private set; }
        public long Pandigital
        {
            get
            {
                return Convert.ToInt64(pandigitalStringBuilder.ToString());
            }
        }

        public PandigitalMultipleCheck(int multiplicand)
        {
            Value = multiplicand;
            IsPandigital = false;
            Multiple = 1;

            if (SetBits(Value))
                FindLimit();
        }

        public void Debug(int digitSet)
        {
            Console.WriteLine("1 2 3 4 5 6 7 8 9 |");
            for (int i = 0; i < 9; i++)
            {
                Console.Write("{0} ", bits[i] ? "X" : " ");
            }

            Console.WriteLine("| {0}", digitSet);
        }

        public bool CheckPandigital()
        {
            for (int i = 0; i < 9; i++)
            {
                if (!bits[i])
                    return false;
            }

            return true;
        }

        private void FindLimit()
        {
            int value = Value;
            bool complete = false;

            while (!complete)
            {
                Multiple++;
                value = Value * Multiple;
                if (!SetBits(value))
                {
                    IsPandigital = false;
                    complete = true;
                    break;
                }

                if (CheckPandigital())
                {
                    IsPandigital = true;
                    complete = true;
                }
            }
        }

        private bool SetBits(int value)
        {
            int length = (int)Math.Floor(Math.Log10(value)) + 1;
            string chunk = value.ToString();

            // Loop over the number, taking one digit at a time
            for (int i = 0, digit = 0; i < length; i++)
            {
                digit = value % 10;
                if (digit == 0)
                    return false;

                if (bits[digit - 1])
                    return false;

                bits[digit - 1] = true;
                value = value / 10;
            }

            // All digits were unique. Append.
            pandigitalStringBuilder.Append(chunk);

            return true;
        }
    }
}
