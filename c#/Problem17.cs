using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem17 : Problem
    {
        List<string> englishNumbers;
        List<int> englishKeys;

        public override void Process()
        {
            Dictionary<int, string> english = new Dictionary<int, string>() {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" },
                { 20, "twenty" },
                { 30, "thirty" },
                { 40, "forty" },
                { 50, "fifty" },
                { 60, "sixty" },
                { 70, "seventy" },
                { 80, "eighty" },
                { 90, "ninety" },
                { 100, "one hundred" },
                { 200, "two hundred" },
                { 300, "three hundred" },
                { 400, "four hundred" },
                { 500, "five hundred" },
                { 600, "six hundred" },
                { 700, "seven hundred" },
                { 800, "eight hundred" },
                { 900, "nine hundred" },
                { 1000, "one thousand" }
            };

            englishNumbers = new List<string>();
            englishKeys = english.Keys.ToList();

            for (int i = 1; i <= 1000; i++)
            {
                // Exact match?
                if (english.ContainsKey(i)) {
                    englishNumbers.Add(english[i]);
                    continue;
                }

                int remainder = i, amount = 0;
                string newNumber = "";
                while (remainder > 0)
                {
                    int largest = englishKeys.FindAll(x => x <= remainder).Last();

                    amount = (int)Math.Floor((double)(remainder / largest));
                    newNumber += String.Format("{0}{1}{2}", (amount > 100) ? english[amount] + " " : "", (remainder > 100 ? " and " : " "), english[largest]);
                    remainder = remainder % largest;
                }

                englishNumbers.Add(newNumber);
            }

            int countOfLetters = englishNumbers.Select(a => a.Replace(" ", "").Length).ToList().Sum();

            Console.WriteLine("Letters used: {0}", countOfLetters);
        }
    }
}
