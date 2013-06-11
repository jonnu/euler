using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem59 : Problem
    {
        public override void Process()
        {
            string valid = null;
            char[] dData = null;
            char[] alpha = Enumerable.Range(97, 26).Select(x => (char)x).ToArray();
            char[] xData = ReadAsciiData();
            
            // Generate all 3-letter 'passwords'
            List<string> keys = (
                from a in alpha
                from b in alpha
                from c in alpha
                select new String(new char[] { a, b, c })
            ).ToList();

            // Apply each password, search for a valid decode
            foreach (string key in keys)
            {
                dData = ApplyXor(xData, key);
                if (!ValidXorDecryption(dData))
                    continue;

                valid = key;
                break;
            }

            int asciiSum = dData.Select(x => (int)x).Sum();
            Console.WriteLine("Key: {0}, ASCII sum of decrypted data: {1}", valid, asciiSum);
        }

        private char[] ApplyXor(char[] input, string key)
        {
            int[] keyArray = key.ToCharArray().Select(x => (int)x).ToArray();
            int[] inputArr = input.Select(x => (int)x).ToArray();

            for (int i = 0, k = 0; i < input.Length; i++, k++)
            {
                inputArr[i] ^= keyArray[k % key.Length];
            }

            return inputArr.Select(x => (char)x).ToArray();
        }

        private bool ValidXorDecryption(char[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!ValidAscii((int)input[i]))
                    return false;
            }

            return true;
        }

        private bool ValidAscii(int i)
        {
            bool isNumeric = (i >= 48 && i <= 57);
            bool isAlphabetical = (i >= 65 && i <= 90) || (i >= 97 && i <= 122);
            bool isPunctuation = i == 33 || i == 34 || (i >= 39 && i <= 41) || (i >= 44 && i <= 46) || i == 58 || i == 59 || i == 63;
            bool isWhitespace = i == 10 || i == 13 || i == 32;

            return isAlphabetical || isNumeric || isPunctuation || isWhitespace;
        }

        private char[] ReadAsciiData()
        {
            string raw = ReadTextFile("Problem59.txt", true);
            using (StringReader reader = new StringReader(raw))
            {
                string line = reader.ReadToEnd();
                return line.Split(',').Select(x => Convert.ToChar(Int32.Parse(x))).ToArray();
            }
        }
    }
}
