using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem89 : Problem
    {
        private Dictionary<char, int> romanNumerals = new Dictionary<char, int>() {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public override void Process()
        {
            int characters = ReadNumeralsFromFile()
               .Select(roman => roman.Length - IntegerToRoman(RomanToInteger(roman)).Length)
               .Sum();

            Console.WriteLine("Saved characters: {0}", characters);
        }

        public int RomanToInteger(string input)
        {
            int value = 0, previous = 0;
            char[] numerals = input.ToCharArray();

            for (int i = numerals.Length - 1; i >= 0; i--)
            {
                int current = romanNumerals[numerals[i]];
                if (current < previous) {
                    current *= -1;
                }
                value += current;
                previous = Math.Abs(current);
            }

            return value;
        }

        public string IntegerToRoman(int integer)
        {
            StringBuilder sb = new StringBuilder();
            KeyValuePair<char, int> current, modifier;

            int charPosition = romanNumerals.Count() - 1;
            int modIndex = 0, modPower = 0;

            while (integer > 0)
            {
                current = romanNumerals.ElementAt(charPosition);
                while (current.Value > integer)
                {
                    modIndex = charPosition - 2 + (charPosition % 2);
                    modifier = modIndex < 0 ? default(KeyValuePair<char, int>) : romanNumerals.ElementAt(modIndex);
                    modPower = (int)Math.Pow(10, Math.Floor(Math.Log10(modifier.Value)));

                    // Check to see if we can use modifier here, e.g. IV for 4, IX for 9...
                    if (current.Value > integer && current.Value - modPower <= integer)
                    {                        
                        sb.Append(modifier.Key);
                        sb.Append(current.Key);
                        integer -= (current.Value - modPower);
                    }

                    if (integer == 0)
                        return sb.ToString();

                    current = romanNumerals.ElementAt(--charPosition);
                }

                sb.Append(current.Key);
                integer -= current.Value;
            }

            return sb.ToString();
        }

        private IEnumerable<string> ReadNumeralsFromFile()
        {
            string raw = ReadTextFile("Problem89.txt", false);
            using (StringReader reader = new StringReader(raw))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
